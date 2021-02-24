using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainEntity.Db;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore
{
    public class TopicRepository : ITopicRepository
    {

        private readonly IDbConnection _db = default;

        public TopicRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Topic> CreateAsync(Topic item)
        {
            var query = "INSERT INTO Topics(Name,Id) VALUES (@Name,@Id)";
            try
            {
                var id = await _db.ExecuteAsync(query, new
                {
                    Name = item.Name,
                    Id = item.Id
                });

                item.TopicId = id;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var query = "delete from Topics where Id = @Id";
                await _db.ExecuteAsync(query, new { id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            var query = "select * from Topics where Id = @Id";
            var element = _db.QueryAsync<Topic>(query, new { id }).Result.Single();

            return element;
        }

        public async Task<IEnumerable<Topic>> ReadAsync()
        {
            var query = "select * from Topics";
            var data = await _db.QueryAsync<Topic>(query);

            return data;
        }

        public async Task<Topic> UpdateAsync(Topic item)
        {
            var query = "update Topics set Name = @Name, Id = @Id where TopicId = @TopicId";
            await _db.ExecuteAsync(query, item);
            return item;
        }
    }
}
