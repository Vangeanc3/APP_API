using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP_API.Models
{
    [PrimaryKey(nameof(Id))]
    public class Usuario
    {
        public int Id { get; set; } // PK
        public string Nome { get; set; }
        public int Telefone { get; set; }
        [Key]
        public string Email { get; set; } // Unica 
        public string Senha { get; set; }
        public Role Role { get; set; } // Profissao
        public string? Cpf { get; set; }  // Pode ser null
        public bool Status { get; set; } = true;
        public int EnderecoId { get; set; } // Endereço FK
        [JsonIgnore]
        public virtual Endereco? Endereco { get; set; } // Endereço
        [JsonIgnore]
        public virtual List<Orcamento>? Orcamentos { get; set; } // O Usuario pode criar um orcamento
        [JsonIgnore]
        public virtual List<Pedido>? Pedidos { get; set; } // O Usuario Instalador pode fazer um pedido
    }

    public enum Role
    {
        Cliente,
        Vendedor,
        Instalador,
        Administrador
    }
}