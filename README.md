 

El enfoque que se ha dado al proyecto es cuantitativo y de tipo experimental, pues, se busca, a través de un software optimizar tiempo y costos a la hora de realizar el dimensionamiento de las válvulas dentro del sector hidráulico. 

Para creación de la aplicación web se decidió un entorno completo de desarrollo proporcionado por Microsoft, todas las herramientas de la plataforma Microsoft se soportan entre sí ya que la compañía ofrece soluciones completas en el campo del desarrollo de aplicaciones de escritorio y de aplicaciones web, por ello todo el desarrollo se enfocará solo en tecnologías de la compañía. El entorno de desarrollo de Microsoft se conoce como ASP.NET CORE, utilizando para el BackEnd C# y para el FrontEnd HTML5, CSS3 y JavaScript. Estas tecnologías fueron escogidas por el equipo de desarrollo ya que todos tienen experiencia con el lenguaje principal que se utilizará que es C# y para el diseño su gran mayoría conoce HTML y CSS. 

La aplicación tendrá entonces, apartir del patrón de aquitectura MVC, una clase para representar cada concepto. Las vistas estarán ubicadas en la carpeta ‘Views’, dentro de esta carpeta se contendran otras carpetas que son las vistas de cada controlador,  es decir para cada controlador habra una carpeta dentro de vistas con un nombre igual a la clase que se especifique; por ejemplo: para HomeController.cs, estarán dentro de la carpeta Views y la carpeta Home, ubicados los archivos y de esta extensión .cshtml (que son las páginas Blazor mencionadas anteriormente) y estos archivos son Index, Error, Privacy. En la ilustración 11 se muestra un ejemplo de esta convención del patrón de diseño MVC. mismo tiempo esta carpeta contendra una carpeta llamada ‘Shared’, esta carpeta contiene dos archivos uno llamado _Layout.cshtml, que dentro de este archivo existe otro llamado de manera identica a este, siguiendo la convención de ASP.NET CORE y su extesión es .cshtml.css, esta hoja de estilos estará en todos los archivos como plantilla y al igual que la clase _Layout.cshtml, estos seran el diseño estandar que tendrán todas las páginas que se añadan al aplicativo web. Por último el otro llamado _ValidationScriptPartials.cshtml, en este se añaden scripts para frameworks como lo son JQuery.  

Dentro de la carpeta ‘Pages’ es necesario crear las vistas que se estarán utilizando en este caso, en este aplicativo será necesario generar una carpeta donde se contengan las vistas del programa en este caso se llamó 'Valvulas’, dentro de esta se creo una CRUD (Create, Read, Update, Delete), para poder generar válvulas nuevas, leer sus datos, editarlas y eliminarlas de ser necesario. 

 
Las hoja de estilos general deberan ser creadas dentro de la carpeta wwwroot y dentro de esta crear una carpeta llamada css, para generar código JavaScript es necesario que dentro de la carpeta wwwroot se cree una carpeta llamada llamada js, para agregar las librerias y el ícono que tendran las paginas en la pestaña en el momento de ser abierta la aplicación es necesario que dentro de la misma carpeta wwwroot para las librerias se cree una carpeta llamada lib y el ícono debe estar dentro de la carpeta wwwroot, pero no estar dentro de ninguna otra carperta, todas estas reglas son parte de las buenas prácticas al desarrollar aplicaciones web con ASP.NET CORE. 
 
Para entender el desarrollo de la aplicación es necesario comprender las distintas etapas que el desarrollo de la aplicación se divide en los siguientes puntos: 

Desarrollo de la base de datos. 

Plantilla de creación del patron de aplicaciones web con C# utilizando MVC. 

Creación del modelo de la base de datos. 

Creación del controlador. 

Diseño de interfaces. 
 

10.1	Desarrollo de la base de datos 

Para el desarrollo de las bases de datos se utilizó la herramienta Microsoft SQL Server (SQL Server), que permite utilizar bases de datos relacionales que no son más que un conjunto de tablas que se separan por filas y columnas. 
 
Para diseñar la base de datos es necesario generar un query (Consulta) en SQL Server, como se ve en la Ilustración 7, es necesario oprimir el botón subrayado de amarillo donde dice “New Query”. 

Ilustración 7:Creación de un Query 

 

Fuente: Ilustración propia 

En el 'query’ se procederá a generar la base de datos y dentro de esta se crearán las tablas que terminarán siendo el modelo del aplicativo web, como se muestra en la Ilustración 8. 

Ilustración 8: Creación base de datos. 

 

Fuente: Ilustración propia 

10.2 Plantilla de creación del patrón de aplicaciones web con C# utilizando MVC. 

La plantilla es generada directamente del IDE (Entorno de Desarrollo Integrado) Visual Studio, desde que se ingresa a generar un nuevo proyecto, este IDE permite generar diversas soluciones web enfocadas al desarrollo con distintos leguajes de programación como lo son JavaScript, Python, C++, C#, herramientas como Unity2D, React.JS, Windows Presentation Foundation (WPF), entre otros sin fin de opciones que brinda Visual Studio. 

Para generar la plantilla desde Visual Studio basta con seleccionar la plantilla llamada “Aplicación web desde ASP.NET Core (Modelo-Vista-Controlador)”, en la Ilustración 9, en área resaltada se muestra la plantilla un vistazo a la interfaz de creación de proyectos de Visual Studio: 

Ilustración 9: Plantilla de Creación de Proyectos Visual Studio 

 

Fuente: Ilustración propia 

10.3	Creación del modelo de la base de datos 

A partir de las tablas indexadas en la base de datos se deben traslapar las columnas hacia las clases de la carpeta modelo, esta acción se realiza a partir de ciertas librerías que Microsoft brinda a los usuarios de .NET, pero para utilizar estas librerías es necesario instalar dichas librerías desde la carpeta de dependencia y luego en Administrar paquetes de NuGet, que no es más que un instalador que brinda Visual Studio para sus librerías. Estas librerías corresponden al nombre de Microsoft.EntityFrameworkCore.SqlServer y Microsoft.EntityFramework.Tools, que son las que hacen posible la migración de los datos a una clase modelo de C# con la cual con la que se trabajará en el proyecto. 

Desde la consola de administración de Paquetes se debe escribir siempre que la base de datos se crea y se actualiza el siguiente comando:  

Scaffold-DbContext "Server='DESKTOP-LCIMTLI'; Database=Valvulas; Trusted_Connection=True;"Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models –force 
 
Nótese que se empieza con un comando único de la consola, seguido de un paréntesis que es la conexión a la base de datos, donde se escoge el server (en este caso práctico es el server de un computador, por lo cual tiene nombre DESKTOP-LCIMTLI), el nombre de la base de datos previamente generada y aceptar un certificado de confianza. Luego de esto se utiliza la librería Microsoft.EntityFrameworkCore.SqlServer y sus comandos –OutputDir que es para que su salida sea en la carpeta especificada que en este caso es Models y –force es opcional la primera vez que se hace el traslape de las columnas, cuando se necesite una actualización de la base de datos siempre debe estar ese comando.  En algunos casos es necesario que después de Trusted_Connection=True; se escriba el comando Encrypt=False que evita que la base de datos rechace la petición de Visual Studio para traer los datos hacia el modelo. 

10.4 Creación del Controlador 

Para la creación del controlador es necesario en la carpeta crear desde la plantilla dada por Visual Studio el controlador simplemente pulsando clic derecho sobre la carpeta Controllers y añadiendo un Controlador vacío, desde el controlador vacío al mismo tiempo es necesario generar una vista que acompañe a este, por lo tanto, son buenas prácticas llamar a los controladores como se guste, pero que seguido de su nombre este la palabra Controller, como se muestra en la Ilustración 10. 

Ilustración 10: Nombre de los controladores. 

 

Fuente: Ilustración propia 

El controlador es la clase que realiza la magia de la aplicación, quien distribuye las vistas que solicita el cliente o usuario del aplicativo y al mismo tiempo es la herramienta que realiza los cálculos y exporta los datos del modelo. Pero es el desarrollador quien debe generar las funciones que permiten que esta magia suceda, por ejemplo: Para generar un cálculo nuevo de una válvula es necesario que el controlador tenga una función que le permita realizar esta acción y luego de esto desde la misma función se genere una vista, como se muestra en la Ilustración 11. 

 

 

 

Ilustración 11: Diseño de Función Create. 

 

Fuente: Ilustración propia 

Desde la línea 51 hasta la línea 63, se realiza la función, en este caso una función POST, que no es más un método que utiliza la web moderna para publicar data en el navegador. Por ello en la línea 52 existe un comando [HttpPost], el cual indica a la aplicación que no se va a obtener nada, sino más bien que se piensa generar nueva información a partir de la función que se está generando. 
 
Ahora bien, para editar y eliminar las funciones que se realizan tienen el mismo proceso de creación, y para cada una de las páginas es necesario realizar las vista. 

 

 

 

 

 

 

 

 

Ilustración 12: Páginas del Modelo 

 

Fuente: Ilustración propia 

 

En la Ilustración 12, se puede apreciar código HTML, pero aquellas partes del código que tienen un color verde azulado son ‘ayudas’ que el framework ASP .NET CORE de desarrollo web en el que se basa el prototipo, permiten que el realizar las aplicaciones sea muy sencillo y no se facilite de esta manera el traer los datos que usuario, ya que este realiza la lectura de los datos ingresados por el cliente y los escribe al servidor permitiendo que sea mucho más sencillo de entender al momento de programar hace que la aplicación sea mucho más legible por otros desarrolladores y al mismo tiempo permite la escalabilidad de la misma. 

La Ilustración 13 presenta la página de crear desde la vista del cliente 

 

10.5 Diseño de Interfaces 

Según (Microsoft, 2022) para la primera etapa del desarrollo de la aplicación es necesario desarrollar las interfaces, que no son más que el “diseño” que tendrá el usuario final del aplicativo. 
ASP.NET CORE tiene tres enfoques generales en la construcción de la interfaz de usuario: 

Aplicaciones que representan la interfaz de usuario desde el servidor. 

Aplicaciones que representan la interfaz de usuario en el cliente en el explorador. 

Aplicaciones híbridas que aprovechan los enfoques de representación de la interfaz de usuario de servidor y cliente. Por ejemplo, la mayor parte de la interfaz de usuario web se representa en el servidor, y los componentes representados del cliente se agregan según sea necesario. 

 

En esta aplicación se estará usando una interfaz de usuario representada en el servidor, ya que esto permitirá que la página que llega al cliente desde el servidor tenga dinamismo y esté lista para mostrarse, esto facilita el desarrollo de la aplicación web y además permite que el desarrollo y los recursos necesarios para poder utilizar la aplicación sean mínimos entre otras ventajas, pero existen desventajas con el desarrollo enfocado al servidor ya que el costo del uso de proceso y memoria se centra en el servidor, en lugar de en cada cliente y las interacciones del usuario requieren un recorrido de ida y vuelta al servidor para generar actualizaciones de la interfaz de usuario. (Microsoft, 2022) 
 

Se ha decidido que la solución de interfaz de usuario de ASP.NET CORE sea representada desde el servidor, ya que el desarrollo es mucho más veloz y fácil de entender para el desarrollador. ASP.NET CORE ofrece tecnologías que facilitan el proceso de creación de interfaces de usuario que se basan en el servidor, una de estas tecnologías es Blazor Pages, que no es más que un entorno de desarrollo de HTML, pero en el cual se puede ejecutar código de C#. 
 

En el modelo se ingresaran las fórmulas a las funciones que permiten que esta aplicación cobre vida, por lo cual es necesario entender estas. 
Se tienen en cuenta las siguientes variables: 

Tabla 2 Formulas uilizadas para el dimensionamineto de valvulas 

Texto

Descripción generada automáticamente 

Fuente: Tabla propia 

En la tabla 2 se puede apreciar las fórmulas necesarias para el cálculo y desarrollo del dimensionamiento de válvulas junto con sus especificaciones. 

En este punto del desarrollo es donde brillan las cualidades del software, ya que ahora la fórmula debe repetirse un sin número de veces hasta que se halle el tamaño de válvula ideal para las condiciones suficientes presentadas por la red de acueducto, lo cual hace que el tiempo se alarge el error humano sea mayor y no exista una confianza absoluta en quien desarrolla las fórmulas. 
 
Para poder determinar el tamaño de la válvula la velocidad de salida (V) cálculada previamente con las fórmulas este dato debe estar en una rango de 0.5 m/s y 3 m/s, de lo contrario la tubería por donde sale el agua conectada a la válvula, inclusive la misma válvula podría sufrir problemas a causa de las presiones y la velocidad de agua que pasa através de la válvula y la tubería en la salida. 

 

 

 

 

 

 

Ilustración 13 Diseño de interfaces 

Ilustración 13. Diseño de Interfaces 

Párrafo bloqueado por DANIEL FELIPE MARTINEZ ALZATE
Fuente: Ilustración propia 

En la Ilustración 12, se puede apreciar como las interfaces se guardan dentro de la carpeta Views, y dentro de esta carpeta el nombre del modelo es el título de la carpeta que contiene las páginas. Cada una de las páginas se diseña a partir de código HTML, por lo cual todo el diseño se realiza en base a este. 
 

Como una de las funcionalidades principales de la aplicación es poder almacenar distintos cálculos de válvulas, resulta necesario realizar una CRUD (Por sus siglas en Ingles Create, Read, Update, Delete), a partir de este concepto se almacena en la base de datos cada uno de los cálculos y se pueden tener por separado los distintos sectores o válvulas que se calculan a través del software. 
 
La intefaz inicial del programa es una pequeña presentación del proyecto que muestra el titulo de presente documento y el propósito de la generación de esta herramienta. 

 

 

 

 

 

Ilustración 14 Interfaz de bienvenida de usuario 

 

Fuente: Ilustración propia 

Para la interfaz inicial que es donde el cliente tendra la posibilidad de administrar las distintas válvulas que genere se puede apreciar la tabla con los distintos parámetros en las columnas y la información extraida de la base de datos para su presentación: 

Ilustración 15 Index de presentación de válvulas 

 

Fuente: Ilustración propia 

 

En esta tabla presentada en la Ilustración 13 es donde se verán cada una de las válvulas también estarán los menús o enlaces a la derecha de cada una de las válvulas generadas que permitirán realizar, edición, vista de detalles y eliminación de las válvulas de ser necesario. 

Para la creación de una nueva válvula basta con oprimir el botón crear presentado en la ilustración 13 y dentro se encontrará la siguiente interfaz de creación: 

Ilustración 16 Interfaz de Creación de Válvulas 
 

Fuente: Ilustración propia 

En la ilustración 14 se puede apreciar la interfaz generada para la creación que se presentarán en la tabla, esta interfaz recibe los parámetros de Fecha de Creación, Descripción, Caudal y Diámetro de la válvula que se está generando. 
 

Al acceder al botón de edición se presentará la siguiente interfaz 

Ilustración 17. Interfaz de Edición 
 
 

Fuente: Ilustración propia 

 

Esta interfaz recibirá los mismos parámetros que se reciben en la creación, pero la diferencia es que esta interfaz su propósito será el de modificar un Id específico que es uno de los parámetros de la base de datos; esta acción de modificación de la base de datos se realiza a través del método en la clase controlador Edit. 

 

Ilustración 18. Código fuente de edición de parámetros del software 
 

Fuente: Ilustración propia 

Luego estarán las interfaces de ver detalles, a esta interfaz se puede acceder mediante el enlace o título llamado detalle, ubicado al final de cada una de las válvulas generadas. Dentro de esta interfaz se pueden apreciar cada uno de los parámetros de la válvula a detalle, tal como se muestra en la siguiente Ilustración. 

Ilustración 19. Interfaz de detalles de la aplicación 

 

Fuente: Ilustración propia 

 
Por último, está el botón o en lace de borrar, el cual permite que cada una de las válvulas generadas sea eliminada de la base de datos y no se despliegue, para esta se creó una interfaz de confirmación para que el cliente no borre por error las válvulas que generó previamente, en la siguiente ilustración se muestra como se ve esta interfaz. 

 

Ilustración 20. Interfaz de confirmación de Eliminación de Válvula 
 

Fuente: Ilustración propia 

Esta interfaz mostrará los mismos datos que la interfaz de detalles, pero con la opción de eliminar la válvula que se haya seleccionado en la tabla. 

A continuación se presenta el link del repositorio en Github donde se puede ver el proyecto.
