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
    public class RutinBakimManager : IRutinBakimService
    {
        private readonly IRutinBakimDal _rutinBakimDal;
        
        public RutinBakimManager(IRutinBakimDal rutinBakimDal)
        {
            _rutinBakimDal = rutinBakimDal;
        }

        public IResult Add(RutinBakim rutinBakim)
        {
            _rutinBakimDal.InsertAsync(rutinBakim);
            return new SuccessResult();
        }

        public IResult Delete(RutinBakim rutinBakim)
        {
            _rutinBakimDal.Delete(rutinBakim);
            return new SuccessResult();
        }

        public IDataResult<RutinBakim> GetById(Expression<Func<RutinBakim, bool>> expression)
        {
            return new SuccessDataResult<RutinBakim>(_rutinBakimDal.GetAll(expression).FirstOrDefault());
        }

        public IDataResult<List<RutinBakim>> GetAll(Expression<Func<RutinBakim, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<RutinBakim>>(_rutinBakimDal.GetAll());
            }
            return new SuccessDataResult<List<RutinBakim>>(_rutinBakimDal.GetAll(expression));
        }

        public IResult Update(RutinBakim rutinBakim)
        {
           _rutinBakimDal.Update(rutinBakim);
            return new SuccessResult();
        }
    }
}