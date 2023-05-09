using Microsoft.EntityFrameworkCore;
using SistemaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscola.Data
{
    public class IESContext : DbContext
    {
        //permite configurar o acesso ao banco de dados.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=NT-NTI\\NTI; Database = IESUtfpr; Trusted_Connection = True; MultipleActiveResultSets = true");
        //}

        //implementa o contexto do acesso ao banco de dados
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Instituicao> Instituicoes { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }



    }
}
