using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Validations;
using FluentValidation;

namespace ClientesApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponseDto Incluir(ClienteRequestDto dto)
        {
            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Cpf = dto.Cpf,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
                Ativo = true
            };

            var clienteValidator = new ClienteValidator();
            var validationResult = clienteValidator.Validate(cliente);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (_clienteRepository.VerifyEmail(cliente.Email, cliente.Id))
            {
                throw new ApplicationException("O e-mail informado já está cadastrado para outro cliente.");
            }

            if (_clienteRepository.VerifyCpf(cliente.Cpf, cliente.Id))
            {
                throw new ApplicationException("O CPF informado já está cadastrado para outro cliente.");
            }

            _clienteRepository.Add(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };
        }

        public ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Cpf = dto.Cpf;
            cliente.DataUltimaAlteracao = DateTime.Now;

            var clienteValidator = new ClienteValidator();
            var validationResult = clienteValidator.Validate(cliente);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (_clienteRepository.VerifyEmail(cliente.Email, cliente.Id))
            {
                throw new ApplicationException("O e-mail informado já está cadastrado para outro cliente.");
            }

            if (_clienteRepository.VerifyCpf(cliente.Cpf, cliente.Id))
            {
                throw new ApplicationException("O CPF informado já está cadastrado para outro cliente.");
            }

            _clienteRepository.Update(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };
        }

        public ClienteResponseDto Excluir(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            cliente.Ativo = false;
            cliente.DataUltimaAlteracao = DateTime.Now;

            _clienteRepository.Update(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };
        }

        public List<ClienteResponseDto> Consultar()
        {
            var response = new List<ClienteResponseDto>();

            var clientes = _clienteRepository.GetAll();

            foreach (var cliente in clientes)
            {
                response.Add(new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataInclusao = cliente.DataInclusao,
                    DataUltimaAlteracao = cliente.DataUltimaAlteracao
                });
            }

            return response;
        }

        public ClienteResponseDto ObterPorId(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };
        }
    }
}