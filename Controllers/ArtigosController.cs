using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Xml.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BlogSemedo.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ArtigosController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            string xmlFilePath = Path.Combine(webRootPath, "dados", "25-04-2023_Primeiro-Poste.xml");

            return View();
        }
    }
}
