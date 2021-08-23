using System.Data;
using System.Linq;
using ApiFastReport.Data;
using ApiFastReport.Helpers;
using Microsoft.AspNetCore.Mvc;
using ApiFastReport.Entity;

namespace ApiFastReport.Controllers
{
    [Route("[controller]")]
    public class RelatorioUserController : ControllerBase
    {
        private readonly MyContext _context;

        public RelatorioUserController(MyContext context)
        {
            _context = context;
        }

        /// Usuuário
        [HttpGet("ListagemUsuarioSimples")]
        public ActionResult GetListagemUsuarioSimples()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemUsuarios.frx");

            var usuarioList = _context.Users.Where(u => u.Nome != "").ToList();

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
    }
}