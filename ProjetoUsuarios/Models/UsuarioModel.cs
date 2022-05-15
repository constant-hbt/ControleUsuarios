using ProjetoUsuarios.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadatro { get; set;  }
        public DateTime? DataAltualizacao { get; set;  }
    }
}
