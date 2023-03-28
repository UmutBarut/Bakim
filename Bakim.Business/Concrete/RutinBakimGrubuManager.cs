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
    public class RutinBakimGrubuManager  : IRutinBakimGrubuService
    {
        private readonly IRutinBakimGrubuDal _rutinBakimGrubuDal;
        
        public RutinBakimGrubuManager(IRutinBakimGrubuDal rutinBakimGrubuDal)
        {
            _rutinBakimGrubuDal = rutinBakimGrubuDal;
        }

        public IResult Add(RutinBakimGrubu rutinBakimGrubu)
        {
            
            _rutinBakimGrubuDal.InsertAsync(rutinBakimGrubu);
            return new SuccessResult();
        }

        public IResult Delete(RutinBakimGrubu rutinBakimGrubu)
        {
            _rutinBakimGrubuDal.Delete(rutinBakimGrubu);
            return new SuccessResult();
        }

        public IDataResult<List<RutinBakimGrubu>> GetAll(Expression<Func<RutinBakimGrubu, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<RutinBakimGrubu>>(_rutinBakimGrubuDal.GetAll());
            }
            return new SuccessDataResult<List<RutinBakimGrubu>>(_rutinBakimGrubuDal.GetAll(expression));
        }

        public IDataResult<RutinBakimGrubu> GetById(Expression<Func<RutinBakimGrubu, bool>> expression = null)
        {
            return new SuccessDataResult<RutinBakimGrubu>(_rutinBakimGrubuDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(RutinBakimGrubu rutinBakimGrubu)
        {
           _rutinBakimGrubuDal.Update(rutinBakimGrubu);
            return new SuccessResult();
        }
    }
}