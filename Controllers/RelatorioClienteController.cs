using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApiFastReport.Data;
using ApiFastReport.Entity;
using ApiFastReport.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ApiFastReport.Controllers
{
    [Route("[controller]")]
    public class RelatorioClienteController : ControllerBase
    {
        private readonly MyContext _context;

        public RelatorioClienteController(MyContext context)
        {
            _context = context;
        }
        
        ///Cliente
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