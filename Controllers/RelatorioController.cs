using System.Data;
using System.Linq;
using ApiFastReport.Data;
using ApiFastReport.Helpers;
using Microsoft.AspNetCore.Mvc;
using ApiFastReport.Entity;
using System.ComponentModel.DataAnnotations;

namespace ApiFastReport.Controllers
{
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly MyContext _context;

        public RelatorioController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("ListagemUsuarioSimples")]
        public ActionResult GetListagemUsuarioSimples()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemUsuarios.frx");

            var usuarioList = _context.Users.Where(u => u.Nome != "").ToList();

            /*var usuarios= new DataTable();

            usuarios.Columns.Add("Id", typeof(string));
            usuarios.Columns.Add("Nome", typeof(string));
            usuarios.Columns.Add("Email", typeof(string));
            usuarios.Columns.Add("CreateAt", typeof(DateTime));

            foreach (var item in usuarioList)
            {
                usuarios.Rows.Add(item.Id, item.Nome, item.Email, item.CreateAt);
            }*/

            var usuarios = HelperFastReport.GetTable<User>(usuarioList,"users");
            webReport.Report.RegisterData(usuarios, "users");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeUsuario.pdf");
        }

        [HttpGet("ListagemUsuarioComCabecalho")]
        public ActionResult GetListagemUsuarioCabecalho()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemUsuariosCabecalho.frx");

            var usuarioList = _context.Users.Where(u => u.Nome != "").ToList();
            var empresaList = _context.Empresas.ToList();

            var usuarios = HelperFastReport.GetTable<User>(usuarioList,"users");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(usuarios, "users");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeUsuarioComCabecalho.pdf");
        }

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

        [HttpGet("ListagemClientes")]
        public ActionResult GetListagemClientes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemClientes.frx");

            var clientesList = _context.Clientes.ToList();
            var empresaList = _context.Empresas.ToList();

            var clientes = HelperFastReport.GetTable<Cliente>(clientesList,"clientes");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(clientes, "clientes");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeClientes.pdf");
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

        [HttpGet("FichaClientePorId/{Id}")]
        public ActionResult GetFichaClientePorId([FromRoute][Required]int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("FichaCliente.frx");

            var clientesList = _context.Clientes.Where(p => p.Id.Equals(Id)).ToList();
            var empresaList = _context.Empresas.ToList();

            var clientes = HelperFastReport.GetTable<Cliente>(clientesList,"clientes");
            var empresa = HelperFastReport.GetTable<Empresa>(empresaList,"Empresas");
            webReport.Report.RegisterData(clientes, "clientes");
            webReport.Report.RegisterData(empresa, "Empresas");
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "FichaDoClientePorId_{Id.ToString()}.pdf");
        }
    }
}