using System.Collections.Generic;

namespace ApiFastReport.Entity
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}