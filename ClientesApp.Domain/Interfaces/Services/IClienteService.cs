using ClientesApp.Domain.Dtos;

namespace ClientesApp.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        ClienteResponseDto Incluir(ClienteRequestDto dto);
        ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto);
        ClienteResponseDto Excluir(Guid id);
        List<ClienteResponseDto> Consultar();
        ClienteResponseDto ObterPorId(Guid id);
    }
}