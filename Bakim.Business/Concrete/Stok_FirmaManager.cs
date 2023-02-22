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
    public class Stok_FirmaManager : IStok_FirmaService
    {
        private readonly IStok_FirmaDal _stokFirmaDal;

        public Stok_FirmaManager(IStok_FirmaDal stok_FirmaDal)
        {
            _stokFirmaDal = stok_FirmaDal;
        }



        public IResult Add(Stok_Firma stok_Firma)
        {
            _stokFirmaDal.InsertAsync(stok_Firma);
            return new SuccessResult();
        }

        public IResult Delete(Stok_Firma stok_Firma)
        {
           _stokFirmaDal.Delete(stok_Firma);
            return new SuccessResult();
        }

        public IDataResult<List<Stok_Firma>> GetAll(Expression<Func<Stok_Firma, bool>> expression = null)
        {
            if(expression == null)
            {
                return new SuccessDataResult<List<Stok_Firma>>(_stokFirmaDal.GetAll());
            }
            else
            {
                return new SuccessDataResult<List<Stok_Firma>>(_stokFirmaDal.GetAll(expression));
            }
        }

        public IDataResult<Stok_Firma> GetById(int stokFirmaId)
        {
            return new SuccessDataResult<Stok_Firma>(_stokFirmaDal.GetAll(c=> c.StokFirmaId == stokFirmaId).FirstOrDefault());
        }

        public IResult Update(Stok_Firma stok_Firma)
        {
            _stokFirmaDal.Update(stok_Firma);
            return new SuccessResult();
        }
    }
}