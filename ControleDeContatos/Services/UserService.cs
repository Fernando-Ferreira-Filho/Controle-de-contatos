using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Services {
    public class UserService : IUserService {
        private readonly BancoContext _bancoContext;

        public UserService(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public User Add(User user) {
            //gravar no banco de dados
            user.AddDate = DateTime.Now;
            _bancoContext.User.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public User FindById(int id) {
            return _bancoContext.User.FirstOrDefault(obj => obj.Id == id);
        }


        public List<User> ListAll() {
            return _bancoContext.User.ToList();
        }

        public User Update(User user) {
            var userDb = FindById(user.Id);

            if (userDb == null) {
                throw new System.Exception("Houve um erro na atualização do usuario");
            }

            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.Login = user.Login;
            userDb.Profile = user.Profile;
            userDb.UpdateDate = DateTime.Now;

            _bancoContext.Update(userDb);
            _bancoContext.SaveChanges();

            return userDb;
        }

        public bool Delete(int id) {
            try {
                var obj = FindById(id);
                if (obj == null) {
                    throw new System.Exception("Falha ao apagar");
                }
                _bancoContext.User.Remove(obj);
                _bancoContext.SaveChanges();
                return true;
            }
            catch (System.Exception e) {
                throw new System.Exception("Falha ao apagar");
            }
        }

        public User FindByLogin(string login) {
            return _bancoContext.User.FirstOrDefault(obj => obj.Login.ToUpper() == login.ToUpper());
        }
    }
}
