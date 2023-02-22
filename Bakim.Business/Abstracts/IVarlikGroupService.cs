using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface IVarlikGroupService
    {
        public IResult Add(VarlikGroup varlikgroup);
        public IResult Delete(VarlikGroup varlikgroup);
        public IResult Update(VarlikGroup varlikgroup);
        public IDataResult<List<VarlikGroup>>GetAll(Expression<Func<VarlikGroup,bool>> expression = null);
    }
}