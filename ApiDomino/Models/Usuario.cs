namespace ApiDomino.Models
{
    //clase usuario para manejar la autenticación
    public class Usuario
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int Id { get; set; }
    }
}
