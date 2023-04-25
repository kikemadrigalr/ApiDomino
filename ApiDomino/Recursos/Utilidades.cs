using ApiDomino.Models;

namespace ApiDomino.Recursos
{
    public class Utilidades
    {
        //metodo que se encarga de crear una cadena valida de fichas de domino
        //en base a las fichas recibidas como json en el endpoint api/Ficha/Fichas
        public static bool BuildDominoChain(List<Ficha> fichas, List<Ficha> cadena)
        {
            int contadorFichas = 0;
            bool cadenaValida = false;

            //validar que los numeros de la ficha esten entre 0 y 6
            //0 representa el blanco
            if (fichas.All(f => ((f.PuntosIzquierda >= 0 && f.PuntosIzquierda <= 6) && (f.PuntosDerecha >= 0 && f.PuntosDerecha <= 6))))
            {
                for (int i = 0; i < fichas.Count; i++)
                {
                    var pieza = fichas[i];

                    //Intentar ingresar al final de la lista
                    //si el lado derecho de la ficha ya jugada coincide con alguno de los lados de la proxima ficha
                    if (cadena.Count == 0 || (cadena.Last().PuntosDerecha == pieza.PuntosIzquierda && pieza.Jugada == false))
                    {
                        pieza.Jugada = true;
                        cadena.Add(pieza);
                        contadorFichas++;
                    }
                    else if (cadena.Count == 0 || (cadena.Last().PuntosDerecha == pieza.PuntosDerecha && pieza.Jugada == false))
                    {
                        CambiarPosicion(pieza);
                        pieza.Jugada = true;
                        cadena.Add(pieza);
                        contadorFichas++;
                    }

                    //Intentar Ingresar al inicio de la Lista
                    //Si el lado izquierdo de la ficha ya jugada coincide con alguno de los lados de la proxima ficha
                    if (cadena.Count == 0 || (cadena.First().PuntosIzquierda == pieza.PuntosDerecha && pieza.Jugada == false))
                    {
                        pieza.Jugada = true;
                        cadena.Insert(0, pieza);
                        contadorFichas++;
                    }
                    else if (cadena.Count == 0 || (cadena.First().PuntosIzquierda == pieza.PuntosIzquierda && pieza.Jugada == false))
                    {
                        CambiarPosicion(pieza);
                        pieza.Jugada = true;
                        cadena.Insert(0, pieza);
                        contadorFichas++;
                    }
                }
            }
            else
            {
                //Alguna ficha contiene un numero distinto del rango 0 - 6
                // se retorna false por lo cual no se puede generar la cadena
                return false;
            }

            //Verificar si ya se han jugado todas las fichas
            if (contadorFichas == fichas.Count)
            {
                //verificar si la cadena resultante es válida.
                //La cadena es válida si  los puntos de las mitades de aquellas fichas que no tengan vecino(fichas primera y última) concuerden uno con el otro
                cadenaValida = (cadena.First().PuntosIzquierda == cadena.Last().PuntosDerecha) ? true : false;
            }

            return cadenaValida;
        }

        //cambiar de posicion los digitos de la ficha
        public static Ficha CambiarPosicion(Ficha ficha)
        {
            int auxD, auxI;
            auxI = ficha.PuntosIzquierda;
            auxD = ficha.PuntosDerecha;
            ficha.PuntosDerecha = auxI;
            ficha.PuntosIzquierda = auxD;

            return ficha;
        }
    }
}
