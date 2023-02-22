using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System.Linq.Expressions;

namespace Bakim.Business.Abstracts
{
    public interface ITedarikciFirmaService
    {
        public IDataResult<List<TedarikciFirma>> GetAll(Expression<Func<TedarikciFirma, bool>> expression = null);
        public IDataResult<TedarikciFirma> GetById(int tedarikciFirmaId);
        public IResult Add(TedarikciFirma tedarikciFirma);
        public IResult Delete(TedarikciFirma tedarikciFirma);
        public IResult Update(TedarikciFirma tedarikciFirma);
    }
}