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
    public class TalepManager : ITalepService

    {
        private readonly ITalepDal _talepDal;

        public TalepManager(ITalepDal talepDal)
        {
            _talepDal = talepDal;
        }

        public IResult Add(Talep talep)
        {
            _talepDal.InsertAsync(talep);
            return new SuccessResult();
        }

        public IResult Delete(Talep talep)
        {
            _talepDal.Delete(talep);
            return new SuccessResult();
        }

        public IDataResult<List<Talep>> GetAll(Expression<Func<Talep, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Talep>>(_talepDal.GetAll());
            }
            return new SuccessDataResult<List<Talep>>(_talepDal.GetAll(expression));

        }

        public IDataResult<Talep> GetById(Expression<Func<Talep, bool>> expression)
        {
            return new SuccessDataResult<Talep>(_talepDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Talep talep)
        {
            _talepDal.Update(talep);
            return new SuccessResult();
        }
    }
}