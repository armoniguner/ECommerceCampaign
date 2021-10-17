using ECommerceCampaign.Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerceCampaign.Entity.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        #region context
        private DbContext _ctx;
        #endregion contexts

        #region repository
        public ICampaignRepo CampaignRepo { get; set; }
        public ICampaignInfoRepo CampaignInfoRepo { get; set; }
        public IProductRepo ProductRepo { get; set; }
        public IOrderRepo OrderRepo { get; set; }
        #endregion repositories

        public UnitOfWork()
        {

        }
        public UnitOfWork(DbContext ctx)
        {
            _ctx = ctx;
            InitiateContext();
        }

        protected void InitiateContext()
        {
            CampaignRepo = new CampaignRepo(_ctx);
            CampaignInfoRepo = new CampaignInfoRepo(_ctx);
            ProductRepo = new ProductRepo(_ctx);
            OrderRepo = new OrderRepo(_ctx);
        }

        public int SaveChanges()
        {
            try
            {
                return _ctx.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
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
