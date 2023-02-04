using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeeLink.Models;

namespace WeeLink.Services
{
    public class DBServices
    {
        private readonly IMongoCollection<UserLink> _userLinkCollection;

        public DBServices(IOptions<DBSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userLinkCollection = mongoDB.GetCollection<UserLink>(dbSettings.Value.UserLinkCollection);
        }

        public async Task<UserLink> GetUserLinkAsync(string shortLink) => await _userLinkCollection.Find(x => x.userLinkShorted == shortLink).FirstAsync();

        public async Task SaveUserLinkAsync(UserLink userLink) => await _userLinkCollection.InsertOneAsync(userLink);

        public async Task<bool> AlreadyHasLinkInDB(string shortLink) {
            var itens = await _userLinkCollection.CountAsync(x => x.userLinkShorted == shortLink);
            return itens > 0;
        }
    }
}
