using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IStokKategoriService
    {
        public IDataResult<List<StokKategori>> GetAll(Expression<Func<StokKategori, bool>> expression = null);
        public IDataResult<StokKategori> GetById(int stokKategoriId);
        public IResult Add(StokKategori StokKategori);
        public IResult Delete(StokKategori StokKategori);
        public IResult Update(StokKategori StokKategori);
    }
}