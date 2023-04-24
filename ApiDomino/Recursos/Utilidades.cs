using ApiDomino.Models;

namespace ApiDomino.Recursos
{
    public class Utilidades
    {
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
                //verificar si la cadena resultante es correcta.
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
