using BussinesObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using ClaseDatos.ConexionBase;

namespace ServiceApi.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados 
        public ActionResult Index()
        {

            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.GetAsync("api/Empleado").Result;
           
            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<List<SpConsultaEmpleados_Result>>(cadena);
                return View(lista);
              
            }

            return View();
        }

        [HttpGet]
        public ActionResult AgregaEmpl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregaEmpl(BussinesObjects.Empleados empl)
        {
            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.PostAsync("api/Empleado",empl,new JsonMediaTypeFormatter()).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<bool>(cadena);

                if(lista)
                {
                    return RedirectToAction("Index");
                }
                 return View(empl);


            }

            return View(empl);
        }

        [HttpGet]
        public ActionResult ActualizaEmp(int id)
        {
            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.GetAsync("api/Empleado?id=" + id).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<BussinesObjects.Empleados>(cadena);
                return View(lista);


            }

              return View();
        }

        [HttpPost]
        public ActionResult ActualizaEmp(SpConsultaEmpleados_Result empl)
        {
            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.PutAsync("api/Empleado", empl, new JsonMediaTypeFormatter()).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<bool>(cadena);

                if (lista)
                {
                    return RedirectToAction("Index");
                }
                return View(empl);


            }

            return View(empl);
        }

        [HttpGet]
        public ActionResult EliminaEmpl(int id)
        {
            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.DeleteAsync("api/Empleado?id=" + id).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<bool>(cadena);

                if(lista)
                {
                    return RedirectToAction("Index");



                }
              
            }

            return View();
        }


        // GET: Empleados 
        [HttpGet]
        public ActionResult Vista(int id)
        {

            HttpClient Cliente = new HttpClient();

            Cliente.BaseAddress = new Uri("https://localhost:44345/");

            var resultado = Cliente.GetAsync("api/Empleado?id=" + id).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var cadena = resultado.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<BussinesObjects.Empleados>(cadena);
                return View(lista);


            }

            return View();
        }

    }
}