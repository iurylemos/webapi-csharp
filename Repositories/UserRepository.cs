using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly SystemTaskDBContext _dbContext;

        public UserRepository(SystemTaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User by ID: {id} does not found.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User by ID: {id} does not found.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
    }
}