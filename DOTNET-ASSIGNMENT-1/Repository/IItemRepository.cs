using DOTNET_ASSIGNMENT_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DOTNET_ASSIGNMENT_1.Repository
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(string key);
        Task<bool> IsExistAsync(string key);
        Task AddorUdateAsync(string key,string value);
        Task UpdateAsync(string key,string value);
        Task DeleteAsync(string key);


    }
}
