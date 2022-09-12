using Luftborn.API.Repositories;
using Luftborn.API.Models;
using System.Runtime;

namespace Luftborn.API.BLL.Items
{
    public class ItemBLL : Repository<Item>, IitemBLL
    {
        private readonly IRepository<Item> _repo;
        
        public ItemBLL(IRepository<Item> repo)
        {
            _repo = repo;
        }
        public Item GetById(int Id)
        {
            return _repo.GetAll().Where(z => z.ItemId == Id).FirstOrDefault();
        }
        public List<Item> GetAll()
        {
            return _repo.GetAll().Where(z => z.Status==true).ToList();
        }
       
        public bool IsValid(string name, int? id, out string message)
        {
            message = string.Empty;
            if (GetAll().Any(z => z.ItemName.ToLower().Equals(name.ToLower()) && (id == null || z.ItemId != id)))
            {
                message ="Name Exists Before";
                return false;
            }
            else
                return true;
        }
        public async Task<int> SaveItem(Item item)
        {
            if(item.ItemId == 0)
            {
               return await _repo.AddAsync(item);
            }
            else
            {
                return await _repo.UpdateAsync(item);

            }
        }
       
        public async Task<int> Delete(int id)
        {
            Item item = _repo.GetAll().Where(z => z.ItemId == id).FirstOrDefault();
               item.Status = false;
                return await _repo.UpdateAsync(item);

            
        }

    }
}
