using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IRutinBakimGrubuService
    {
        public IDataResult<List<RutinBakimGrubu>> GetAll(Expression<Func<RutinBakimGrubu, bool>> expression = null);
        public IDataResult<RutinBakimGrubu> GetById(Expression<Func<RutinBakimGrubu,bool>> expression);
        public IResult Add(RutinBakimGrubu rutinBakimGrubu);
        public IResult Delete(RutinBakimGrubu rutinBakimGrubu);
        public IResult Update(RutinBakimGrubu rutinBakimGrubu);
    }
}