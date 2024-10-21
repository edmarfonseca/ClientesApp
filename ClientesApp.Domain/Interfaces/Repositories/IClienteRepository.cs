using ClientesApp.Domain.Entities;

namespace ClientesApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Definição dos métodos abstratos para o repositório de clientes
    /// </summary>
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        List<Cliente> GetAll();
        Cliente GetById(Guid id);
        bool VerifyEmail(string email);
        bool VerifyCpf(string cpf);
    }
}