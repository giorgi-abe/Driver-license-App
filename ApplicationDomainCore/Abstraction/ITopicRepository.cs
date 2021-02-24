using ApplicationDatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Abstraction
{
    public interface ITopicRepository
    {
        Task<Topic> CreateAsync(Topic item);
        Task<IEnumerable<Topic>> ReadAsync();
        Task<Topic> GetByIdAsync(int id);
        Task<Topic> UpdateAsync(Topic item);
        Task<bool> DeleteAsync(int id);
    }
}
