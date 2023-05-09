using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscola.Models
{
    public class Instituicao
    {
        [Key]
        
        public long? InstituicaoID { get; set; }

        [Required]
        [StringLength(100)]
       
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        
        public string Endereco { get; set; }

      
        public virtual ICollection<Departamento> Departamentos { get; set; }
       

    }
}
