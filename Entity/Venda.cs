using System;
using System.Collections;
using System.Collections.Generic;

namespace ApiFastReport.Entity
{
    public class Venda : BaseEntity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal TotalVenda { get; set; }
        public IEnumerable<VendaItem> VendaItens { get; set; }
    }
}