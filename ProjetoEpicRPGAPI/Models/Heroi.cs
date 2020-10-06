using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEpicRPGAPI.Models
{
    public class Heroi
    {
        [Key]
        public int IdHeroi { get; set; }
        public string nome { get; set; }
        public int nivel { get; set;}
        public int xp { get; set;}
        public int cod_usuario {get; set;}
    }
}