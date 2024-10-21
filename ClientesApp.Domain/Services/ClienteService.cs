using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Interfaces.Services;

namespace ClientesApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        public ClienteResponseDto Incluir(ClienteRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ClienteResponseDto> Consultar()
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
