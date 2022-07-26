using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Services {
    public interface
        IUserService {
        public User Add(User contato);
        public User Update(User contact);
        public List<User> ListAll();
        public User FindById(int id);
        public bool Delete(int id);

        public User FindByLogin(string login);
    }
}
