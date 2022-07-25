using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Services {
    public interface IContactService {

        public Contact Add(Contact contato);
        public List<Contact> ListAll();
        public Contact FindById(int id);
        public Contact Update(Contact contact);
        public bool Delete(int id);
    }
}
