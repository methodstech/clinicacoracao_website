using AppServices.Filters;
using AppServices.Interfaces;
using OfficeOpenXml;
using System;
using System.Data;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebSite.Helper;

namespace WebSite.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LaudoExcelController : ApiController
    {
        private readonly ILaudoAppService _appService;

        public LaudoExcelController(ILaudoAppService appService)
        {
            _appService = appService;
        }

        public void Get(int? pacienteId, string dtInicial, string dtFinal)
        {
            LaudoFilterDto filter = new LaudoFilterDto
            {
                LaudoPacienteId = pacienteId ?? null
            };
            if (!string.IsNullOrEmpty(dtInicial))
            {
                filter.LaudoDtInicial = DateTime.ParseExact(dtInicial + " 00:01", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(dtFinal))
            {
                filter.LaudoDtFinal = DateTime.ParseExact(dtFinal + " 23:59", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }

            string filename = "bmedcardio-" + Util.HrBrasilia().ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

            DataTable dataTable = _appService.ListDataTable(filter);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            using (ExcelPackage pack = new ExcelPackage())
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("file.xlsx");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                var ms = new System.IO.MemoryStream();
                pack.SaveAs(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }
}
