using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Enums {
    public enum ProfileEnum {
        [Display(Name = "Administrador")]
        Admin = 1,
        [Display(Name = "Padrão")]
        Standard = 2
    }
}
