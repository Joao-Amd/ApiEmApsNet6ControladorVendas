using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Aplicacao.Usuarios.Views;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;
using System.Security.Cryptography;
using System.Text;

namespace ApiControladorVendas.Aplicacao.Usuarios
{
    public class AplicUsuario : IAplicUsuario
    {
        private readonly IRepCad<Usuario> _repUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public AplicUsuario(IRepCad<Usuario> repUsuario, IUnitOfWork unitOfWork)
        {
            _repUsuario = repUsuario;
            _unitOfWork = unitOfWork;
        }
        public UsuarioViewModel Alterar(int id, UsuarioDto dto)
        {
            var usuario = _repUsuario.GetById(id);

            if (usuario == null)
                throw new Exception("Erro: Usuario não encontrado!");

            byte[] senhaHash = Encoding.UTF8.GetBytes(dto.Senha);

            usuario.Alterar(dto.Nome, dto.Email, senhaHash);

            _unitOfWork.Persistir();

            return UsuarioViewModel.Novo(usuario);
        }

        public void Deletar(int id)
        {
            var usuario = _repUsuario.GetById(id);

            if (usuario == null)
                throw new Exception("Erro: Usuario não encontrado!");

            _repUsuario.Delete(id);

            _unitOfWork.Persistir();
        }

        public UsuarioViewModel Inserir(UsuarioDto dto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                byte[] senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Senha));
                byte[] senhaSalt = hmac.Key;

                var usuario = Usuario.Novo(dto.Nome, dto.Email);

                usuario.AlterarSenha(senhaHash, senhaSalt);

                _repUsuario.Inserir(usuario);

                _unitOfWork.Persistir();

                return UsuarioViewModel.Novo(usuario);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public UsuarioViewModel Recuperar(int id)
        {
            var usuario = _repUsuario.GetById(id);
            return UsuarioViewModel.Novo(usuario);
        }

        public List<UsuarioViewModel> RecuperarTodos()
        {
            var usuario = _repUsuario.Get();

            return usuario.Select(x => UsuarioViewModel.Novo(x)).ToList();
        }
    }
}
