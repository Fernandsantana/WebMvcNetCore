using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMvcNetCore.Models;
using WebMvcNetCore.Models.ViewModels;
using WebMvcNetCore.Serviços;
using WebMvcNetCore.Serviços.Excecao;

namespace WebMvcNetCore.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public IActionResult Index()
        {
            var list = _servicoVendedor.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _servicoDepartamento.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };

                return View(viewModel);
            }

            _servicoVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido!"});
            }

            var obj = _servicoVendedor.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido!" });
            }

            var obj = _servicoVendedor.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido!" });
            }

            var obj = _servicoVendedor.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            List<Departamento> departamentos = _servicoDepartamento.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = _servicoDepartamento.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };

                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível!" });
            }

            try
            {
                _servicoVendedor.Update(vendedor);

                return RedirectToAction(nameof(Index));
            }  
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
