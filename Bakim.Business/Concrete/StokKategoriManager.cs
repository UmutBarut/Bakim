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
    public class StokKategoriManager : IStokKategoriService
    {
        private readonly IStokKategoriDal _stokKategoriDal;

        public StokKategoriManager(IStokKategoriDal stokKategoriDal)
        {
            _stokKategoriDal = stokKategoriDal;
        }
        public IResult Add(StokKategori StokKategori)
        {
            _stokKategoriDal.InsertAsync(StokKategori);
            return new SuccessResult();
        }

        public IResult Delete(StokKategori StokKategori)
        {
            _stokKategoriDal.Delete(StokKategori);
            return new SuccessResult();
        }

        public IDataResult<List<StokKategori>> GetAll(Expression<Func<StokKategori, bool>> expression = null)
        {
           if(expression == null)
            {
                return new SuccessDataResult<List<StokKategori>>(_stokKategoriDal.GetAll());
            }
            else
            {
                return new SuccessDataResult<List<StokKategori>>(_stokKategoriDal.GetAll(expression));
            }
        }

        public IDataResult<StokKategori> GetById(int stokKategoriId)
        {
            return new SuccessDataResult<StokKategori>(_stokKategoriDal.GetAll(c => c.StokKategoriId == stokKategoriId).FirstOrDefault());
        }

        public IResult Update(StokKategori StokKategori)
        {
            _stokKategoriDal.Update(StokKategori);
            return new SuccessResult();
        }
    }
}