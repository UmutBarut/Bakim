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
    public class RutinBakimKategorisiManager : IRutinBakimKategorisiService
    {
        private readonly IRutinBakimKategorisiDal _rutinBakimKategoriDal;

        public RutinBakimKategorisiManager(IRutinBakimKategorisiDal rutinBakimKategoriDal)
        {
            _rutinBakimKategoriDal = rutinBakimKategoriDal;
        }

        public IResult Add(RutinBakimKategorisi rutinBakimKategorisi)
        {
           _rutinBakimKategoriDal.InsertAsync(rutinBakimKategorisi);
           return new SuccessResult();
        }

        public IResult Delete(RutinBakimKategorisi rutinBakimKategorisi)
        {
            _rutinBakimKategoriDal.Delete(rutinBakimKategorisi);
           return new SuccessResult();
        }

        public IDataResult<List<RutinBakimKategorisi>> GetAll(Expression<Func<RutinBakimKategorisi, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<RutinBakimKategorisi>>(_rutinBakimKategoriDal.GetAll());
            }
            return new SuccessDataResult<List<RutinBakimKategorisi>>(_rutinBakimKategoriDal.GetAll(expression));
        }

        public IDataResult<RutinBakimKategorisi> GetById(Expression<Func<RutinBakimKategorisi, bool>> expression)
        {
            return new SuccessDataResult<RutinBakimKategorisi>(_rutinBakimKategoriDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(RutinBakimKategorisi rutinBakimKategorisi)
        {
            _rutinBakimKategoriDal.Update(rutinBakimKategorisi);
           return new SuccessResult();
        }
    }
}