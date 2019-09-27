using MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using MVC.DataAccess;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AmigoDataService _dataService;

        public HomeController()
        {
            var connectionString = System.Configuration.ConfigurationManager.
                ConnectionStrings["SQLConnection"].ConnectionString;
            _dataService = new AmigoDataService(connectionString);
        }

        public ActionResult Index()
        {
            var amigos = _dataService.GetAmigos();
            return View(amigos);
        }

        public ActionResult AddView()
        {
            var amigo = new Amigo();
            return View(amigo);
        }

        public ActionResult Delete(int i)
        {
            var result = _dataService.DeleteAmigo(i);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddView(Amigo amigo)
        {
            if (!ModelState.IsValid) return View(amigo);

            var result = _dataService.AddAmigo(amigo);

            if (result)
                return RedirectToAction("Index");

            return View(amigo);
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ModificarAmigo(Amigo amigo)
        {
            if (!ModelState.IsValid) return View(amigo);

            var result = _dataService.UpdateAmigo(amigo.idamigo, amigo);

            if (result)
                return RedirectToAction("Index");

            return View(amigo);
        }

        public ActionResult ModificarAmigo()
        {
            var amigo = new Amigo();
            return View(amigo);
        }

    }
}