using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bakim.Business.Abstracts
{
    public interface IRoutineBakimDetayService
    {
        public IDataResult<List<RoutineBakimDetay>> RoutineBakimDetay(int routineBakimId);
    }
}