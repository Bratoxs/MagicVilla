namespace MagicVilla_API.Modelos.DTO
{
    public class LoginResponseDTO
    {
        public UsuarioDto Usuario { get; set; }

        public string Token { get; set; }
        //public string Rol { get; set; }
    }
}
