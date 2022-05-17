using ProjetoUsuarios.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Selecione o perfil do usuário!")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadatro { get; set;  }
        public DateTime? DataAltualizacao { get; set;  }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
