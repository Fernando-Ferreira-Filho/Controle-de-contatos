using ControleDeContatos.Models;
using ControleDeContatos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControleDeContatos.Controllers {
    public class ContactController : Controller {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService) {
            _contactService = contactService;
        }

        public IActionResult Index() {
            var list = _contactService.ListAll();
            return View(list);
        }
        public IActionResult Create() {
            return View();
        }


        public IActionResult Edit(int? id) {
            if (id == null) {
                return RedirectToAction("Index");
            }
            var obj = _contactService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return RedirectToAction("Index");
            }
            var obj = _contactService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contato) {
            try {

                if (!ModelState.IsValid) {
                    return View(contato);
                }

                TempData["SuccessMessage"] = "Contato cadastrado com sucesso";
                _contactService.Add(contato);
                return RedirectToAction("Index");
            }
            catch (System.Exception e) {

                TempData["ErrorMessage"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact) {
            try {
                if (!ModelState.IsValid) {
                    return View(contact);
                }
                TempData["SuccessMessage"] = "Contato alterado com sucesso";
                _contactService.Update(contact);
                return RedirectToAction("Index");
            }
            catch (System.Exception e) {
                TempData["ErrorMessage"] = $"Ops, não conseguimos alterar seu contato, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            try {
                TempData["SuccessMessage"] = "Contato apagado com sucesso";
                bool apagado = _contactService.Delete(id);
                if (apagado) {
                    TempData["SuccessMessage"] = "Contato apagado com sucesso";
                }
                else { TempData["ErrorMessage"] = $"Ops, não conseguimos excluir seu contato"; }
                return RedirectToAction("Index");

            }
            catch (System.Exception e) {
                TempData["ErrorMessage"] = $"Ops, não conseguimos excluir seu contato, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
