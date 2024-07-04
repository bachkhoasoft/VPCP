
using WebApplication1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplication1.Services
{
    public class VPCPService

    {
        private readonly IMongoCollection<vpcp> _vpcpCollection;
        

        public VPCPService(IOptions<VpcpDatabaseSettings> _VpcpDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                _VpcpDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                _VpcpDatabaseSettings.Value.DatabaseName);

                _vpcpCollection = mongoDatabase.GetCollection<vpcp>(
                _VpcpDatabaseSettings.Value.vpcpCollectionName);
        }

        public async Task<List<vpcp>> GetAsync() => 
            await _vpcpCollection.Find(_ => true).ToListAsync();

        public async Task<vpcp?> GetAsync (string id) =>
            await _vpcpCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(vpcp newvpcp) =>
            await _vpcpCollection.InsertOneAsync(newvpcp);

        public async Task UpdateAsync(string id, vpcp upvpcp) =>
            await _vpcpCollection.ReplaceOneAsync(x => x.Id == id, upvpcp);

        public async Task RemoveAsync(string id) =>
            await _vpcpCollection.DeleteOneAsync(x => x.Id == id);


    }
}
