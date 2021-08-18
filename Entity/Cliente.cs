using System.Collections;
using System.Collections.Generic;

namespace ApiFastReport.Entity
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerable<Venda> Vendas { get; set; }
    }
}