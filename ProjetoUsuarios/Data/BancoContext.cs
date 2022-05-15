using Microsoft.EntityFrameworkCore;
using ProjetoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
