using Bakim.Core.DataAccess;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Dataaccess.Abstracts
{
    public interface IStockDal : IEntityRepository<Stock>
    {

    }
}