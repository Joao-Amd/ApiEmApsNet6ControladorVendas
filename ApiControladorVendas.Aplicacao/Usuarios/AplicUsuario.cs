using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Aplicacao.Usuarios.Views;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;

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

            usuario.Alterar(dto.Nome, dto.Email, dto.Senha, dto.NivelAcesso);

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

        public void Inserir(UsuarioDto dto)
        {
            try
            {
                var usuario = Usuario.Novo(dto.Nome, dto.Email, dto.Senha);

                _repUsuario.Inserir(usuario);

                _unitOfWork.Persistir();
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
