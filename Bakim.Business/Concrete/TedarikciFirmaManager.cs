using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;

namespace Bakim.Business.Concrete
{
    public class TedarikciFirmaManager : ITedarikciFirmaService
    {
        private readonly ITedarikciFirmaDal _tedarikciFirmaDal;
        public TedarikciFirmaManager(ITedarikciFirmaDal tedarikciFirmaDal)
        {
            _tedarikciFirmaDal = tedarikciFirmaDal;
        }
        public IResult Add(TedarikciFirma tedarikciFirma)
        {
            _tedarikciFirmaDal.InsertAsync(tedarikciFirma);
            return new SuccessResult();
        }

        public IResult Delete(TedarikciFirma tedarikciFirma)
        {
            _tedarikciFirmaDal.Delete(tedarikciFirma);
            return new SuccessResult();
        }

        public IDataResult<List<TedarikciFirma>> GetAll(Expression<Func<TedarikciFirma, bool>> expression = null)
        {
           if(expression == null)
           {
            return new SuccessDataResult<List<TedarikciFirma>>(_tedarikciFirmaDal.GetAll());
           }
           else
           {
            return new SuccessDataResult <List<TedarikciFirma>>(_tedarikciFirmaDal.GetAll(expression));
           }
        }

        public IDataResult<TedarikciFirma> GetById(int tedarikciFirmaId)
        {
            return new SuccessDataResult<TedarikciFirma>(_tedarikciFirmaDal.GetAll(c=> c.FirmaId == tedarikciFirmaId).First());
        }

        public IResult Update(TedarikciFirma tedarikciFirma)
        {
            _tedarikciFirmaDal.Update(tedarikciFirma);
            return new SuccessResult();
        }
    }
}