using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data {
    public class BancoContext : DbContext {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> User { get; set; }
    }
}
