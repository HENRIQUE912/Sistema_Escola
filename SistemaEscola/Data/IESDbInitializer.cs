using SistemaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscola.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();
            if (context.Instituicoes.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao{ Nome="UniParana", Endereco="Paraná"},
                 new Instituicao{ Nome="UniAcre", Endereco="Acre"}
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();


            if (context.Departamentos.Any())
            {
                return;
            }
          
            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação",InstituicaoID=1},
                new Departamento { Nome="Ciência de Alimentos",InstituicaoID=2}
            };
            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();
        }

    }
}
