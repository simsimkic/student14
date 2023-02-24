using Service.ServiceDean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controller.ControllerDean
{
    public class ItemController
    {
        private ItemServices _itemService;

        public ItemController(ItemServices iser)
        {
            this._itemService = iser;
        }

        public bool Add(Item item)
        {
            return this._itemService.Add(item);
        }

        public bool Remove(string id)
        {
            return this._itemService.Remove(id);
        }

        public bool Set(Item item)
        {
            return this._itemService.Set(item);
        }

        public Item Get(string id)
        {
            return this._itemService.Get(id);
        }

        public List<Item> GetAll()
        {
            return this._itemService.GetAll();
        }

        public void Move(Room fromRoom, Room toRoom, Item item)
        {
            this._itemService.Move(fromRoom, toRoom, item);
        }
    }
}
