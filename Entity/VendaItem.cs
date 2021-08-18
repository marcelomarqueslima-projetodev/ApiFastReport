namespace ApiFastReport.Entity
{
    public class VendaItem : BaseEntity
    {
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal TotalProduto { get; set; }
    }
}