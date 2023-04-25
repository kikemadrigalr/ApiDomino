namespace ApiDomino.Models
{
    //Clase que define ficha de dominó
    public class Ficha
    {
        public int PuntosIzquierda { get; set; }

        public int PuntosDerecha { get; set; }

        public bool Jugada { get; set; }

        public Ficha()
        {
            
        }

        //Constructor para crear objetos del tipo ficha resiviendo como parametros
        //numeros que representan los puntos de cada lado de la ficha
        //y asignando false a la propiedad jugada, para saber si ya la ficha
        //fue colocada en la cadena o no
        public Ficha(int pIzquierda, int pDerecha)
        {
            PuntosIzquierda = pIzquierda;
            PuntosDerecha = pDerecha;
            Jugada = false;
        }

        //sobreescritura del metodo ToString para un objeto Ficha
        //para mostrarlo con el formato [N|N]
        public override string ToString()
        {
            return $"[{PuntosIzquierda}|{PuntosDerecha}]";
        }
    }
}
