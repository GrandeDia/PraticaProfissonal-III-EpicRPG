using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEpicRPGAPI.Models
{
    public class Usuario
    {
        [Key]
        public int cod_usuario { get; set; }
        public string email { get; set; } 
        public string senha { get; set; } 
    }
}