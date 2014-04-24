CallCenter
==========
Implementado en ASP.NET y C# con Microsoft Visual Web Developer 2010 Express.

La aplicación consiste en un sistema donde los usuarios dan de alta sus equipos y pueden abrir incidencias sobre ellos. 
Los administradores revisan las incidencias y se comunican mediante mensajes en la incidencia para poder solucionar
el problema. 
La seguridad está implementada mediante directorios, donde los usuarios sólo tendrán acceso a los WebForms del directorio 
User y los Administrados al directorio Admin.

Hay 4 capas:
  - La capa CORE donde están las clases que se han utilizado.
  - La capa DAO donde se encuentra la clase encargada de crear el contexto de datos.
  - La capa APPLICATION donde se implementan las clases de servicios a la base de datos.
  - La capa WEB donde se encuentran los WebForms con los que interactua el usuario.


