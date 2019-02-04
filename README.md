# EjemploCodigoEspagueti

Código ejemplo para el blog Desde las horas extras http://desdelashorasextras.blogspot.com/

## ACERCA DE ESTE EJEMPLO

Este código es un ejemplo del llamado "Código Espagueti", y muestra paso a paso como eliminarlo, se puede encontrar mas información en la entrada del blog:



El código Espagueti es aquel que tiene un control de flujo demasiado complicado para entenderlo claramente, además de que son prácticamente imposibles de modificar por miedo a que mientras cambiamos algo se estropee otra cosa. El código esta enredado tal como un plato de espagueti, se llega a esta situación (en la actualidad), a base de agregar sentencias "if" encadenas, grandes y complejas. Ya de por sí, tener dos "if" encadenados aumenta la complejidad del código y la dificultad de mantenerlo.

## Ejemplo uno de Código Espagueti

Imaginemos el siguiente ejemplo, queremos crear una API que guarda un mensaje (una simple cadena de texto que nos informe de algún suceso). Las opciones para guardar un mensaje son:

*	En base de datos.
*	en un archivo de texto plano.
*	En el log de eventos de Windows.

En un primer acercamiento ponernos definir una clase de nombre GestorMensajes, con un métodos que se llame Guardar, que recibirá dos parámetros, uno  es el cómo va a guarda,r dos el mensaje a guardar.


## Ejemplo dos de Código Espagueti (Simplificación del código espagueti)

Mejoremos el código anterior. Lo primero que podemos hacer es separa el método en funciones más pequeñas que solo realizan una tarea, así tendremos una para guardar archivos planos, otra para base de datos y otra para el visor de eventos, adicionalmente separaremos cualquier función necesaria para configurar los destinos del mensaje.
Convertiremos la estructura de if, en un switch, que se lee mas fácilmente


## Ejemplo tres de Código Espagueti (Eliminación del código espagueti con orientación a objetos)

Cambiaremos la solución a un enfoque basado en objetos, con esto esperamos conseguir:

*	Eliminar el cogido espagueti al evitar usar condicionales de ningún tipo.
*	Aumentar la cohesión (cada clase solo tendrá métodos relacionados entre sí).
*	Se disminuirá el acoplamiento, cada clase podrá ser cambiada e incluso modificada sin afecta al resto del código.

Para ello la clase GestorMensajes, pasara a ser una clase abstracta con un método, también abstracto llamado "Guardar". Es abstracta por que no tiene sentido instanciarla por si misma (siempre se guardar de alguna "forma" y dicha forma no ni tiene que estar especificada directamente en la clase GestorMensajes).

