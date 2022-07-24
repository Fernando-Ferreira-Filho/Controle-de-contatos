using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Services {
    public class ContactService : IContactService {

        private readonly BancoContext _bancoContext;

        public ContactService(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public Contact Add(Contact contato) {
            //gravar no banco de dados
            _bancoContext.Contacts.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public Contact FindById(int id) {
            return _bancoContext.Contacts.FirstOrDefault(obj => obj.Id == id);
        }


        public List<Contact> ListAll() {
            return _bancoContext.Contacts.ToList();
        }

        public Contact Update(Contact contact) {
            var contactDb = FindById(contact.Id);

            if (contactDb == null) {
                throw new System.Exception("Houve um erro na Atualização do contato");
            }

            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Phone = contact.Phone;

            _bancoContext.Update(contactDb);
            _bancoContext.SaveChanges();

            return contactDb;
        }

        public Contact Delete(Contact contact) {
            var obj = FindById(contact.Id);
            if (obj == null) {
                throw new System.Exception("Falha ao apagar");
            }
            _bancoContext.Contacts.Remove(obj);
            _bancoContext.SaveChanges();
            return obj;
        }



    }
}
