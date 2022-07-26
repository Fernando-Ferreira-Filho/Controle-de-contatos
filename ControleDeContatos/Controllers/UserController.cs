using ControleDeContatos.Models;
using ControleDeContatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers {
    public class UserController : Controller {

        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }
        public IActionResult Index() {
            var list = _userService.ListAll();
            return View(list);
        }

        public IActionResult Create() {
            return View();
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return RedirectToAction("Index");
            }
            var obj = _userService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id) {
            if (id == null) {
                return RedirectToAction("Index");
            }
            var obj = _userService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user) {
            try {

                if (!ModelState.IsValid) {
                    return View(user);
                }

                TempData["SuccessMessage"] = "Usuario cadastrado com sucesso";
                _userService.Add(user);
                return RedirectToAction("Index");
            }
            catch (System.Exception e) {

                TempData["ErrorMessage"] = $"Ops, não conseguimos cadastrar seu user, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            try {
                bool apagado = _userService.Delete(id);
                if (apagado) {
                    TempData["SuccessMessage"] = "Usuario apagado com sucesso";
                }
                else { TempData["ErrorMessage"] = $"Ops, não conseguimos excluir o usuario"; }
                return RedirectToAction("Index");

            }
            catch (System.Exception e) {
                TempData["ErrorMessage"] = $"Ops, não conseguimos excluir o usuario, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserUpdate user) {
            try {
                User userModel = null;
                if (!ModelState.IsValid) {
                    return View(user);
                }

                userModel = new User { Id = user.Id, Name = user.Name, Email = user.Email, Profile = user.Profile, Login = user.Login };

                TempData["SuccessMessage"] = "Contato alterado com sucesso";
                userModel = _userService.Update(userModel);
                return RedirectToAction("Index");
            }
            catch (System.Exception e) {
                TempData["ErrorMessage"] = $"Ops, não conseguimos alterar seu contato, tente novamente, detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
