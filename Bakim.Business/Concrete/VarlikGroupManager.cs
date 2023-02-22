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
    public class VarlikGroupManager : IVarlikGroupService
    {
         private readonly IVarlikGroupDal _varlikGroupDal;

         public VarlikGroupManager(IVarlikGroupDal varlikGroupDal)
        {
            _varlikGroupDal = varlikGroupDal;
        }

        public IResult Add(VarlikGroup varlikgroup)
        {
            _varlikGroupDal.InsertAsync(varlikgroup);
             return new SuccessResult();
        }

        public IResult Delete(VarlikGroup varlikgroup)
        {
             _varlikGroupDal.Delete(varlikgroup);
            return new SuccessResult();
        }

        public IDataResult<List<VarlikGroup>>GetAll(Expression<Func<VarlikGroup, bool>> expression = null)
        {
            if(expression==null)
           {
            return new SuccessDataResult<List<VarlikGroup>>(_varlikGroupDal.GetAll());
           }
            return new SuccessDataResult<List<VarlikGroup>>(_varlikGroupDal.GetAll(expression));

        }

        public IResult Update(VarlikGroup varlikgroup)
        {
            _varlikGroupDal.Update(varlikgroup);
            return new SuccessResult();
        }
    }
}