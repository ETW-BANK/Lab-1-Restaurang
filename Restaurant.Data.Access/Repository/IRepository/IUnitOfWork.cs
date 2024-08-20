using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.IRepository
{
   public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        ITableRepository Table { get; }

        IMenuRepository Menu { get; }

        Task SaveAsync();
    }
}
