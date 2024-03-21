
using DOTNET_ASSIGNMENT_1.Data;
using DOTNET_ASSIGNMENT_1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DOTNET_ASSIGNMENT_1.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddorUdateAsync(string key, string value)
        {
           var existingItem= await _context.Items.FirstOrDefaultAsync(i =>i.key == key);
            if (existingItem == null)
            {
                _context.Items.Add(new Item { key=key, value=value });
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ConflictExcetion("key already exists");
            }

        }

        public async Task DeleteAsync(string key)
        {
            var keyvalue = await _context.Items.FirstOrDefaultAsync(i => i.key == key);
            if (keyvalue != null)
            {
                _context.Items.Remove(keyvalue);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("Not found excetion");
            }

        }

        public Task<Item> GetByIdAsync(string key)
        {
            var item=_context.Items.FirstOrDefaultAsync(i=>i.key == key);
            if(item == null)
            {
                throw new NotFoundException("Item not found");
            }
            return item;
            
        }

        public Task<bool> IsExistAsync(string key)
        {
            return _context.Items.AnyAsync(i=>i.key == key);
        }

        public async Task UpdateAsync(string key, string value)
        {
           var existingItem= _context.Items.FirstOrDefault(i=>i.key == key);
            if (existingItem != null)
            {
                existingItem.value = value;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("Item not found");
            }
        }
    }

    
}
