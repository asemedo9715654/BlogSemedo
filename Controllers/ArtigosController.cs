using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Xml.Linq;
using BlogSemedo.Commom;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Xml;
using BlogSemedo.Models;

namespace BlogSemedo.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ArtigosController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int? pageNumber)
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var xmlFilePath = Path.Combine(webRootPath, "dados", "artigos");
            var artigos = new List<Artigo>();

            foreach (string file in Directory.EnumerateFiles(xmlFilePath, "*.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                var artigo = XmlHelper.Deserialize<Artigo>(xmlDoc.OuterXml);
                artigos.Add(artigo);
            }

            if (pageNumber == null)
            {
                pageNumber = 1;
                ViewBag.PageNumber = 1;
            }
            int itemsPerPage = 3;
            int startIndex = (pageNumber.Value - 1) * itemsPerPage;
            var pageItems = artigos.Skip(startIndex).Take(itemsPerPage);


            Blog blog = new Blog()
            {
                Artigos = pageItems.ToList(),
                DestaqueDois = PegarArtigo("destaques", "dois.xml"),
                DestaqueUm = PegarArtigo("destaques", "um.xml"),
                Principal = PegarArtigo("principal", "principal.xml")
            };

            return View(blog);
        }


        public  Artigo PegarArtigo(string subpasta,string nomeArquivo)
        {
            //var artigo = new Artigo();

            var webRootPath = _hostingEnvironment.WebRootPath;
            var xmlFilePath = Path.Combine(webRootPath, "dados", subpasta, nomeArquivo);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            var artigo = XmlHelper.Deserialize<Artigo>(xmlDoc.OuterXml);

            return artigo;
        }
    }
}
