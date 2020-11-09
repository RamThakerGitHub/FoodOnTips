using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Data
{
    public class UnitOfWork : IDisposable
    {
        FoodOnTipsContext context = new FoodOnTipsContext();

        private GenericRepository<ItemMaster> itemRepository;

        public GenericRepository<ItemMaster> ItemRepository
        {
            get
            {
                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<ItemMaster>(context);
                }
                return itemRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
