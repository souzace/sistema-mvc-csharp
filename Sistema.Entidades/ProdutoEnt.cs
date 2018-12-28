using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class ProdutoEnt
    {
        private int id;
        private string nome;
        private string descricao;
        private decimal valor;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Valor { get => valor; set => valor = value; }

    }
}
