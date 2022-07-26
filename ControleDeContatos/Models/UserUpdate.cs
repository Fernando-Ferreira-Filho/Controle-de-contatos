using ControleDeContatos.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models {
    public class UserUpdate {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail do informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public ProfileEnum? Profile { get; set; }

    }
}
