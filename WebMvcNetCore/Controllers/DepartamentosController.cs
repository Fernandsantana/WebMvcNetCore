using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebMvcNetCore.Models;

namespace WebMvcNetCore.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
            list.Add(new Departamento { Id = 2, Nome = "Moda" });

            return View(list);
        }
    }
}
