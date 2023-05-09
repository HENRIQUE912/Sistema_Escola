using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscola.Models
{
    public class Departamento
    {
        [Key]
        
        public long? DepartamentoID { get; set; }

        [Required]
        [StringLength(100)]
       
        public string Nome { get; set; }



        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }

    }

}
