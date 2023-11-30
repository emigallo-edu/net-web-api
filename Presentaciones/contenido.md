# WebAPI

## Introducción

### ¿Qué es la programación orientada a objetos (POO)?
Es un paradigma de programación. En el que los objetos se utilizan como metáfora para
representar las entidades reales de lo que queremos modelar.<br>
Una clase representa una "plantilla" o "molde" y el objeto es un ejemplar de esa plantilla. Tiene las siguientes bases o conceptos:

- Abstracción
- Encapsulación
- Modularización
- Jerarquización

### Abstracción
Es el proceso de extracción de las características esenciales de algo (lo que queremos modelar), ignorando los detalles superficiales.<br>
Diferentes posibles abstracciones para un coche:

| Alquilado  | Particular | Flete    |
|------------|------------|----------|
| Tarifa     | Consumo          | Consumo   |
| Limite kms | Color            | Carga soportada   |
| Consumo    | Valor de reventa | Garantía   |
|            | Durabilidad      |            |

### Encapsulación
Es el proceso en el cual se ocultan los detalles del soporte de las características de una
abstracción.<br>
No se trata de ocultar las características en sí, sino de no mostrar cómo guardo o maneja
internamente esas características.<br>
Por ej, de la clase fecha nos interesa obtener el día, mes y año. Y no como esta guardado internamente.

### Modularización
Es el proceso de descomposición de un sistema en un conjunto de módulos o piezas.
Que esten poco acopladas (independientes) y cohesivas (con significado propio).<br>
Se entiende por sistema al conjunto de piezas que colaboran entre sí.
Por ej, el módulo de cierre centralizado con el módulo de la alarma del auto.

### Jerarquización
Es el proceso de estructuración por el que se produce una organización de un conjunto de
elementos en niveles de responsabilidad.<br>

![](/PPT's/jerarquia.JPG)

### Elementos de la POO
- Clase: descripción de los datos y de las operaciones de un elemento modelado.
- Objeto: instancia de una clase, ejemplar concreto.
- Mensaje: invocación de una operación sobre un objeto.
- Método: definición de una operación de una clase.
- Atributo: los datos de una clase, y por tanto, presente en todos los objetos de esa clase.
- Estado: conjunto de los valores de los atributos que tiene un objeto.

Una clase, es la definición de los atributos y métodos que describen el comportamiento
de un objeto.<br>
Un objeto, es un ejemplar concreto de una clase que responde a los mensajes
correspondientes a sus métodos, adecuándose al estado de sus atributos. 

[Documentación](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/tutorials/oop)

### Palabras claves
Son identificadores reservados predefinidos que tienen significados especiales para el
compilador.<br>
Estos no se pueden utilizar como identificadores en nuestro programa.<br>
Algunos ejemplos:
- abstract
- break
- continue

[Documentación](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

### Modificadores de visibilidad
Todos los tipos y miembros de tipo (clase, método, atributo) tienen un nivel de accesibilidad.
Controla si se pueden usar desde otro código en su ensamblado o en otros ensamblados.
- public: puede ser accedido desde cualquier código.
- private: puede ser accedido desde la misma clase.
- internal: puede ser accedido desde el mismo ‘assembly’.

[Documentación](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

### Sentencias de flujo de ejecución
Son aquellas sentencias que nos permiten manipular nuestro código. Que, dependiendo determinado criterio, nuestro flujo salte a una u otra línea.
- if
- switch
- for
- foreach
- while
- do while
- try-catch

### Arquitectura Model-View-Controller
Se utiliza para desacoplar la interfaz de usuario (vista), los datos (modelo) y la lógica de la
aplicación (controlador).<br>
Separa una aplicación en tres grupos de componentes principales: modelos, vistas y
controladores.<br>
Permite lograr la separación de intereses.<br>
Las solicitudes del usuario se enrutan a un controlador que se encarga de trabajar con el
modelo para realizar las acciones del usuario o recuperar los resultados de consultas.<br>
El controlador elige la vista para mostrar al usuario y proporciona cualquier dato de modelo
que sea necesario.<br>
Se entiende por vista un HTML o un JSON con información.


## ¿Qué es una API?

### Application Programming Interface
Es una interfaz que permite la comunicación entre 2 aplicaciones.
Podemos decir que es un sitio que en vez de responder algo visual, como HTML y CSS, nos responde información.<br>
Los usuarios probablemente no van a ingresar a este tipo de sitios, pero sí una aplicación que necesite abastecerse de cierta información.
Por ejemplo, una aplicación que necesite un listado completo de todos los países del mundo
podría consumir una API que le otorgue esa información.

Otra importancia de los APIs a nivel general, es que permite realizar abstracciones. La idea de una abstracción es que nos permite facilitar el uso de un software sin necesitar conocer cómo funciona internamente, basta con utilizar las funciones que el Api expone.

### ¿Qué es HTTP?
Es un protocolo de transferencia de hipertexto (Hypertext Transfer Protocol) es el protocolo de comunicación que permite las transferencias de información a través de archivos (XML, HTML…) en la World Wide Web.<br>
HTTP define la sintaxis y la semántica que utilizan los elementos de software de la arquitectura web para comunicarse.

HTTP es un protocolo sin estado, por lo que no guarda ninguna información sobre conexiones anteriores.

Es un protocolo orientado a transacciones y sigue el esquema petición-respuesta entre un cliente y un servidor. El cliente realiza una petición enviando un mensaje (request), con cierto formato al servidor. El servidor le envía un mensaje de respuesta (response).

#### Métodos HTTP
Los métodos son usados para manipular los diferentes recursos que conforman una API.<br>
Los principales métodos soportados por HTTP son:
- POST: crear un recurso nuevo.
- PUT: modificar un recurso existente.
- GET: consultar información de un recurso.
- DELETE: eliminar un recurso determinado.
- PATCH: modificar solamente un atributo de un recurso.

Con estos métodos (o acciones) podemos realizar el CRUD (Create, Read, Update, Delete) de una entidad.

Estos métodos, junto con la URI, nos proporciona una interfaz uniforme que nos permite la transferencia de datos aplicando operaciones concretas sobre un recurso determinado.<br>
Aunque la mayoría de las operaciones que componen una API REST podrían llevarse a cabo mediante métodos GET y POST, el abuso de ellos para operaciones que nada tienen que ver con el propósito con el que se concibieron, puede provocar un mal uso.

#### Respuestas HTTP
Los códigos de estado de respuesta HTTP indican si se ha completado satisfactoriamente una solicitud HTTP específica.
<br>Las respuestas se agrupan en cinco clases:

- Respuestas informativas (100–199)
- Respuestas satisfactorias (200–299)
- Redirecciones (300–399)
- Errores de los clientes (400–499)
- Errores de los servidores (500–599)

[Documentación](https://developer.mozilla.org/es/docs/Web/HTTP/Status)

### REpresentational State Transfer (REST)
Es un tipo de arquitectura de desarrollo web que se apoya totalmente en el estándar HTTP.<br>
Proporciona un fuerte aislamiento con quien la consume.<br>
Los objetos REST son manipulados a través de una URI (Uniform Resource Identifier).<br>
Esta URI (endpoint) hace de identificador único de cada recurso del sistema REST, por lo que no puede ser compartida por más de un recurso.

La estructura básica de una URI es la siguiente:<br>
- {protocolo}://{hostname}:{puerto}/{ruta del recurso}?{parámetros de filtrado (opcional)}

El nombre de la URI no debe contener palabras que impliquen acciones, por lo que deben
evitarse los verbos en su construcción.<br>
Además, las URI siguen una jerarquía lógica de capas que permite ordenar los recursos y
englobar las distintas funcionalidades entre sí.

### RESTFul

#### Arquitectura cliente-servidor
Habla de la separación entre un cliente y un proveedor o servidor. El cliente puede ser cualquier software capaz de comunicarse utilizando el protocolo HTTP con el servidor web.<br>
Con este principio aseguramos la separación de responsabilidades entre nuestros servicios Web y los clientes que consumen dicho servicio.

#### Interfaz uniforme
El objetivo es tener una forma estandarizada de transmisión de la información. Con esta condición tenemos una manera universal de utilizar web APIs comunes, es decir, si sabes consumir un Web API, se pueden consumir otros APIs sin mucha dificultad.<br>
Para cumplir con la condición de interfaz uniforme, hay que cumplir con cuatro subcondiciones.

- GET: http://web.com/car -> devuelve todos los autos
- GET: http://web.com/car/nhz493 -> devuelve el auto con patente 'nhz493'
- POST: http://web.com/car -> crea un nuevo auto con la información enviada en la petición
- DELETE: http://web.com/car/nhz493 -> elimina el auto con patente 'nhz493'
- PUT: http://web.com/car/nhz493 - actualiza el auto con patente 'nhz493' según la información enviada en la petición

#### Protocolos sin estado
Cada una de las peticiones realizadas al web API tienen toda la información necesaria para que la petición sea resuelta de manera satisfactoria. Sí el web API requiere que el cliente esté debidamente identificado para acceder y manipular un recurso entonces el cliente debe de enviarnos algún tipo de información que identifique al cliente que está haciendo la petición cada vez que se haga una petición HTTP al servidor.

#### Caché
Las respuestas del Web API deben indicar cuándo se deben guardar en caché, es decir nos referimos a que el cliente puede guardar el recurso dado por la URL de manera local en su dispositivo, para que en subsiguientes peticiones HTTP dichos recursos no tengan que ser pedidos nuevamente al
Web API, sino que se pueda consumir la versión local.

#### Sistema en capas
El servicio del servidor debe tener una arquitectura de capas donde su evolución sea completamente transparente para el cliente.<br>
Por ej, si el servicio web va a utilizar un balanceo de carga, los clientes no tienen por qué tener presente ese detalle pues esto debe ser algo completamente transparente para ellos.

## ASP.NET Core MVC
Es un marco web de código abierto, creado por Microsoft, para crear servicios y aplicaciones web .NET. Es multiplataforma y se ejecuta en Windows, Linux, macOS, y Docker.

[Documentación](https://learn.microsoft.com/es-es/aspnet/core/mvc/overview?view=aspnetcore-8.0&WT.mc_id=dotnet-35129-website)