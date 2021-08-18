namespace ApiFastReport.Entity
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }                
        public decimal Preco { get; set; }
        public string Ean { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}