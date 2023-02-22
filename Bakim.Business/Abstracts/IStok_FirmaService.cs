using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IStok_FirmaService
    {
        public IDataResult<List<Stok_Firma>> GetAll(Expression<Func<Stok_Firma, bool>> expression = null);
        public IDataResult<Stok_Firma> GetById(int stokFirmaId);
        public IResult Add(Stok_Firma stok_Firma);
        public IResult Delete(Stok_Firma stok_Firma);
        public IResult Update(Stok_Firma stok_Firma);
    }
}