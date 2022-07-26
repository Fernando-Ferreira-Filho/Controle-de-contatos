using ControleDeContatos.Models;
using System.Linq;
namespace ControleDeContatos.Data {
    public class SeedingService {

        private readonly BancoContext _bancoContext;

        public SeedingService(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public bool Seed() {
            if (_bancoContext.Contacts.Any() == false) {
                return false;
            }
            Contact c11 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c12 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c13 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c14 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c15 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c16 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c17 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c18 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c19 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };
            Contact c20 = new Contact { Name = "Fernando Ferreira", Email = "Fernando.ferreira@gmail.com", Phone = "62987469" };

        }
    }
}
