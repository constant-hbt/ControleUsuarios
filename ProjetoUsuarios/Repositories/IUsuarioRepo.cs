using ProjetoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Repositories
{
    public interface IUsuarioRepo
    {
        Task<UsuarioModel> BuscarPorEmail(string email);
        Task<UsuarioModel> ListarPorId(int id);
        Task<List<UsuarioModel>> BuscarTodos();
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario);
        Task<bool> Apagar(int id);
    }
}
