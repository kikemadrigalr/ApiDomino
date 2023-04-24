namespace ApiDomino.Models
{
    //Clase para definir ficha de dominó
    public class Ficha
    {
        public int PuntosIzquierda { get; set; }

        public int PuntosDerecha { get; set; }

        public bool Jugada { get; set; }

        public Ficha()
        {
            
        }

        public Ficha(int pIzquierda, int pDerecha)
        {
            PuntosIzquierda = pIzquierda;
            PuntosDerecha = pDerecha;
            Jugada = false;
        }

        public override string ToString()
        {
            return $"[{PuntosIzquierda}|{PuntosDerecha}]";
        }
    }
}
