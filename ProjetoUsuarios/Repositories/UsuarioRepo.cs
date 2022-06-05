using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoUsuarios.Data;
using ProjetoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepo(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadatro = DateTime.Now;
            usuario.SetSenhaHash();
            await _bancoContext.Usuarios.AddAsync(usuario);
            await _bancoContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id).Result;
            if (usuarioDb == null) throw new Exception("Houve uma deleção do usuário");
            _bancoContext.Usuarios.Remove(usuarioDb);
            await _bancoContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id).Result;
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.DataAltualizacao = DateTime.Now;
            usuarioDb.Perfil = usuario.Perfil;

            _bancoContext.Usuarios.Update(usuarioDb);
            await _bancoContext.SaveChangesAsync();

            return usuarioDb;
        }

        public async Task<UsuarioModel> BuscarPorEmail(string email)
        {
            return await _bancoContext.Usuarios.FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            var usuarios = await _bancoContext.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<UsuarioModel> ListarPorId(int id)
        {
            return await _bancoContext.Usuarios.FirstOrDefaultAsync((x => x.Id == id));
        }
    }
}
