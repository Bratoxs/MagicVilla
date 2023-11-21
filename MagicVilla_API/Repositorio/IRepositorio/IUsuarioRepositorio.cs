using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.DTO;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        //Métodos
        bool IsUsuarioUnico(string userName);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<Usuario> Registrar(RegistroRequestDTO registroRequestDTO);
    }
}
