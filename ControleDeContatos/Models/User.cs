using ControleDeContatos.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models {
    public class User {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail do informado não é valido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        [Display(Name = "Perfil")]
        public ProfileEnum? Profile { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Display(Name = "Data de adição")]
        public DateTime AddDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool passwordValid(string password) {
            return Password == password;
        }
    }
}
