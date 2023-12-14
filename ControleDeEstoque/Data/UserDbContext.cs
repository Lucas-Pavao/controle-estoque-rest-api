using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var user = modelBuilder.Entity<User>();
            user.ToTable("tb_user");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            user.Property(x => x.Email).HasColumnName("email").IsRequired();
            user.Property(x => x.Senha).HasColumnName("senha").IsRequired();

        }
    }
}