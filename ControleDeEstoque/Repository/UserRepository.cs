
using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext context;

        public UserRepository(UserDbContext context)
        {
            this.context = context;
        }


        public void AddUser(User user)
        {
            context.Add(user);
        }

        public void DeleteUser(User user)
        {
            context.Remove(user);
        }

        public async Task<User> GetUser(int id)
        {
            return await context.Users.Where(p => p.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
        }
    }
}