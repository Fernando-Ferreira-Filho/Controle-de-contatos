using ControleDeContatos.Models;
using ControleDeContatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers {
    public class LoginController : Controller {

        private readonly IUserService _userService;

        public LoginController(IUserService userService) {
            _userService = userService;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login) {
            try {
                if (ModelState.IsValid) {
                    var user = _userService.FindByLogin(login.UserLogin);

                    if (user != null) {
                        if (user.passwordValid(login.Password)) {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["ErrorMessage"] = "Usuario ou senha invalido(s). Por favor tente novamente. ";
                    return View("Index");
                }
                return View("Index");

            }
            catch (System.Exception e) {
                TempData["ErrorMessage"] = "Ops não conseguimos relaizar o seu login, tente novamente";
                return RedirectToAction("Index");
            }

        }
    }
}
