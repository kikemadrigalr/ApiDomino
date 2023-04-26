# ApiDomino
API Domino, Prueba Técnica Inalambría

Implemente una forma de ordenar un conjunto dado de fichas de dominó de tal manera que se 
construya una cadena correcta de fichas (los puntos en una de las mitades de una ficha concuerdan con 
los puntos que tiene la mitad vecina de la ficha adyacente) y que los puntos de las mitades de aquellas
fichas que no tengan vecino (fichas primera y última) concuerden uno con el otro.

>Ejemplo 1:
Dadas las fichas [2|1], [2|3] y [1|3], el resultado del computo fruto de su construcción debe retornar 
algunas de las siguientes opciones:
✓ [1|2] [2|3] [3|1] ó
✓ [3|2] [2|1] [1|3] ó
✓ [1|3] [3|2] [2|1], etc.
Como es posible observar, los números primero y último son los mismos.

>Ejemplo 2:
Dadas las fichas [1|2], [4|1] y [2|3] la cadena resultado no es válida:
o [4|1] [1|2] [2|3]
Los números primero y último no son los mismos.

Deberá construir un API que permita enviar en notación JSON el conjunto de fichas de dominó, conjunto 
que puede tener mínimo dos fichas y máximo seis fichas; así mismo el resultado debe ser retornado en 
notación JSON indicando una cadena correcta que cumpla lo informado al inicio de la descripción de
este ejercicio, o en determinado caso, informando la imposibilidad de generar una cadena que cumpla 
los criterios definidos con el conjunto de fichas de dominó enviado.

En esta API debe implementar un método de autenticación, el que sea de su agrado; así mismo debe 
implementar códigos de respuesta HTTP.

## Puedes consultarla en: [Api Domino](http://cmapidomino.somee.com/swagger/index.html)

## Uso

1. Api de Autenticación: 
/api/Autenticacion/Validar La API cuenta con autenticación por medio de Json Web Token, por lo cual debes ser autorizado para el consumo de la misma. Como se trata de una API prueba puedes utilizar las siguientes credenciales para acceder: { "email" : "usuario@inalambria.com", "password" :"1234" } ó { "email" : "usuario@email.com", "password" : "123" }. EL Api regresa en formato json un token el cual podras usar para ser autorizado. 

2. Api CadenaDomino para consultar las cadenas Validas que se han creado: 
    1. (Get) /api/CadenaDomino/CadenaValida Lista todas las cadenas validas que se han creado.
    2. (Get) /api/CadenaDomino/CadenaValida/{id} Lista una cadena valida segun un Id especificado en la ruta 
    3. (Delete) /api/CadenaDomino/CadenaValida/{id} Elimina una cadena valida existente utilizando el id que recibe en la ruta
  
3. Api Ficha 
/api/Ficha/FichasJuego Endopoint para ingresar el conjunto de fichas con as que se buscar armar una cadena valida. Tiene el siguiente formato
{
  puntosIzquierda	integer($int32)
  puntosDerecha	integer($int32)
  jugada	boolean
}

### Se recomienda la aplicacion Postman para probar los distintos endpoints

  
  
