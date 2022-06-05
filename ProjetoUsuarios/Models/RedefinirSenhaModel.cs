using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage ="Informe o e-mail de cadastro")]
        public string Email { get; set; }
    }
}
