using Capitulo04.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitulo04.Services
{
    public class ServicoDataStore : IDataStore<Servico>
    {
        private static List<Servico> servicos = new List<Servico>()
        {
            new Servico(){ServicoID = 1, Nome = "Freios", Valor = 100},
            new Servico(){ServicoID = 2, Nome = "Suspenção", Valor = 200},
            new Servico(){ServicoID = 3, Nome = "Caixa de direção", Valor = 300},
            new Servico(){ServicoID = 4, Nome = "Caixa de câmbio", Valor = 400},
            new Servico(){ServicoID = 5, Nome = "Alinhamento/Balanceamento", Valor = 25}
        };

        public IEnumerable<Servico> GetAll()
        {
            return servicos;
        }
        public void Add(Servico servico)
        {
            throw new System.NotImplementedException();
        }
        public void Delete(Servico servico)
        {
            throw new System.NotImplementedException();
        }
        public Servico GetById(long? id)
        {
            throw new System.NotImplementedException();
        }
        public void Update(Servico servico)
        {
            throw new System.NotImplementedException();
        }
    }
}
