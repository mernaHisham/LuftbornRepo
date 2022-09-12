using Luftborn.API.Models;
using System.Runtime;

namespace Luftborn.API.BLL.Items
{
    public interface IitemBLL
    {
        bool IsValid(string name, int? id, out string message);
        Item GetById(int Id);
        List<Item> GetAll();
         Task<int> SaveItem(Item item);
        Task<int> Delete(int id);
    }
}
