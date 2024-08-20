using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Data.Access.Repository.IRepository
{
   public interface ITableRepository:IRepository<Tables>
    {

        void Update(Tables table);
    }
}
