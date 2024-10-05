using MongoDB.Driver;
using SistemaDeReservas.Models;
using Microsoft.Extensions.Options;

namespace SistemaDeReservas.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _users = mongoDatabase.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllUsers() =>
            await _users.Find(user => true).ToListAsync();

        public async Task<User> GetUserById(string id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task CreateUser(User user) =>
            await _users.InsertOneAsync(user);

        public async Task UpdateUser(string id, User updatedUser) =>
            await _users.ReplaceOneAsync(user => user.Id == id, updatedUser);

        public async Task DeleteUser(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);
    }
}
