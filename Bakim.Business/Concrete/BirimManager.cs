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
    public class BirimManager : IBirimService
    {
        private readonly IBirimDal _birimDal;

        public BirimManager(IBirimDal birimDal)
        {
            _birimDal = birimDal;
        }

        public IResult Add(Birim birim)
        {
           _birimDal.InsertAsync(birim);
           return new SuccessResult();
        }

        public IResult Delete(Birim birim)
        {
            _birimDal.Delete(birim);
           return new SuccessResult();
        }

        public IDataResult<List<Birim>> GetAll(Expression<Func<Birim, bool>> expression = null)
        {
            if (expression == null)
            {

                return new SuccessDataResult<List<Birim>>(_birimDal.GetAll());
            }
            return new SuccessDataResult<List<Birim>>(_birimDal.GetAll(expression));
        }

         public IDataResult<Birim> GetById(Expression<Func<Birim, bool>> expression = null)
        {
            return new SuccessDataResult<Birim>(_birimDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Birim birim)
        {
            _birimDal.Update(birim);
           return new SuccessResult();
        }
    }
}