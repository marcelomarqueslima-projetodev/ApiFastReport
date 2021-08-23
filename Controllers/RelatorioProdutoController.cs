using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApiFastReport.Data;
using ApiFastReport.Entity;
using ApiFastReport.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ApiFastReport.Controllers
{
    [Route("[controller]")]
    public class RelatorioProdutoController : ControllerBase
    {
        private readonly MyContext _context;

        public RelatorioProdutoController(MyContext context)
        {
            _context = context;
        }

        ////Produtos
        [HttpGet("ListagemProdutos")]
        public ActionResult GetListagemProdutos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemProdutos.frx");

            var produtosList = _context.Produtos.ToList();
            var empresaList = _context.Empresas.ToList();

            var produtos = HelperFastReport.GetTable<Produto>(produtosList,"produtos");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(produtos, "produtos");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeProdutos.pdf");
        }

        [HttpGet("FichaProduto/{EAN}")]
        public ActionResult GetFichaProdutos([FromRoute][Required]string EAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("FichaProduto.frx");
            var produtosList = _context.Produtos.Where(p => p.Ean.Equals(EAN)).ToList();
            var empresaList = _context.Empresas.ToList();

            var produtos = HelperFastReport.GetTable<Produto>(produtosList,"produtos");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(produtos, "produtos");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", $"FichaDeProdutosPorEan{EAN}.pdf");
        }

        [HttpGet("FichaProdutoPorId/{Id}")]
        public ActionResult GetFichaProdutosPorId([FromRoute][Required]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("FichaProduto.frx");
            var produtosList = _context.Produtos.Where(p => p.Id.Equals(Id)).ToList();
            var empresaList = _context.Empresas.ToList();

            var produtos = HelperFastReport.GetTable<Produto>(produtosList,"produtos");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(produtos, "produtos");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", $"FichaDeProdutosPorId_{Id.ToString()}.pdf");
        }
    }
}