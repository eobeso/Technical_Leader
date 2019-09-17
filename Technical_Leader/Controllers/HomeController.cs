using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technical_Leader.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;

namespace Technical_Leader.Controllers
{
    public class HomeController : Controller
    {
        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = ConfigurationManager.AppSettings["KeyAuthSecret"],
            BasePath = ConfigurationManager.AppSettings["KeyBasePath"]
        };
        IFirebaseClient client;
        public ActionResult Index()
        {           
            return View();
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

        public ActionResult SignUp()
        {
            ViewBag.Message = "Clientes";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(ClienteModels oClienteModels)
        {
            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse resp = await client.GetTaskAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class>();
            get.cnt = get.cnt + 1;
            var vClienteModels = new ClienteModels
            {
                Id = (int)get.cnt,
                Nombre = oClienteModels.Nombre,
                Apellido = oClienteModels.Apellido,
                Edad = oClienteModels.Edad,
                FNacimiento = oClienteModels.FNacimiento
            };

            SetResponse response = await client.SetTaskAsync("Cliente/" + vClienteModels.Id.ToString(), vClienteModels);
            ClienteModels result = response.ResultAs<ClienteModels>();



            var obj = new Counter_class
            {
                cnt = vClienteModels.Id
            };

            SetResponse response1 = await client.SetTaskAsync("Counter/node", obj);

            Response.Write(@"<script language='javascript'>alert('Message: \n" + "Datos Grabados." + " .');</script>");

            return View(vClienteModels);
        }

        public ActionResult Grid()
        {
            ViewBag.Message = "ListaClientes";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Grid(ClienteModels oClienteModels)
        {
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnt = Convert.ToInt32(obj1.cnt);
            var lista = new List<ClienteModels>();
            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Clientes/" + i);
                    ClienteModels obj2 = resp2.ResultAs<ClienteModels>();
                    ClienteModels vClienteModels = new ClienteModels
                    {
                        Id = obj2.Id,
                        Nombre = obj2.Nombre,
                        Apellido = obj2.Apellido,
                        Edad = obj2.Edad,
                        FNacimiento = obj2.FNacimiento
                    };
                    lista.Add(vClienteModels);
                }
                catch (Exception ex)
                {

                }
            }
                return View(lista);
        }

        public ActionResult Grilla()
        {
            ViewBag.Message = "ListaClientes";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Grilla(ClienteModels oClienteModels)
        {

            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnt = Convert.ToInt32(obj1.cnt);
            var lista = new List<ClienteModels>();
            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Clientes/" + i);
                    ClienteModels obj2 = resp2.ResultAs<ClienteModels>();
                    ClienteModels vClienteModels = new ClienteModels
                    {
                        Id = obj2.Id,
                        Nombre = obj2.Nombre,
                        Apellido = obj2.Apellido,
                        Edad = obj2.Edad,
                        FNacimiento = obj2.FNacimiento
                    };
                    lista.Add(vClienteModels);
                }
                catch (Exception ex)
                {

                }
            }
            return View(lista);
        }



        public ActionResult Grilla2()
        {
            ViewBag.Message = "ListaClientes";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Grilla2(ClienteModels oClienteModels)
        {

            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnt = Convert.ToInt32(obj1.cnt);
            var lista = new List<ClienteModels>();
            while (true)
            {
                if (i == cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Clientes/" + i);
                    ClienteModels obj2 = resp2.ResultAs<ClienteModels>();
                    ClienteModels vClienteModels = new ClienteModels
                    {
                        Id = obj2.Id,
                        Nombre = obj2.Nombre,
                        Apellido = obj2.Apellido,
                        Edad = obj2.Edad,
                        FNacimiento = obj2.FNacimiento
                    };
                    lista.Add(vClienteModels);
                }
                catch (Exception ex)
                {

                }
            }
            return View(lista);
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            ViewBag.Message = "Clientes";
            return View();
        }
    }
}