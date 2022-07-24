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
            _contactService.Add(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact) {
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Contact contact) {
            _contactService.Delete(contact);
            return RedirectToAction("Index");

        }
    }
}
