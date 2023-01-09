using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Key]
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Role { get; set; }
        public string Endereco { get; set; }
        public string? Cpf { get; set; } 
        public bool Status { get; set; } = true;
    }
}