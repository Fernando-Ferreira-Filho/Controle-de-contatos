using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models {
    public class Contact {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Display(Name = "Celular")]
        [Phone(ErrorMessage = "O celular informado não é valido")]
        public string Phone { get; set; }
    }
}
