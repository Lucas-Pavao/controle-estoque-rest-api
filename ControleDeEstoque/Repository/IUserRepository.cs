using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Model;

namespace ControleDeEstoque.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        void AddUser(User produto);
        void UpdateUser(User produto);
        void DeleteUser(User id);

        Task<bool> SaveChangesAsync();
    }
}