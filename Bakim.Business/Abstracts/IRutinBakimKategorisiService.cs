using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRutinBakimKategorisiService
    {
        public IDataResult<List<RutinBakimKategorisi>> GetAll(Expression<Func<RutinBakimKategorisi,bool>> expression = null);
        public IDataResult<RutinBakimKategorisi> GetById(Expression<Func<RutinBakimKategorisi, bool>> expression);
        public IResult Add(RutinBakimKategorisi rutinBakimKategorisi);
        public IResult Update(RutinBakimKategorisi rutinBakimKategorisi);
        public IResult Delete(RutinBakimKategorisi rutinBakimKategorisi);

    }
}