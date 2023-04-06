using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ISectionFaultCategoryService
    {
        public IDataResult<List<SectionFaultCategory>> GetAll(Expression<Func<SectionFaultCategory, bool>> expression = null);
        public IDataResult<SectionFaultCategory> GetById(Expression<Func<SectionFaultCategory, bool>>expression);
        public IResult Add(SectionFaultCategory sectionFaultCategory);
        public IResult Update(SectionFaultCategory sectionFaultCategory);
        public IResult Delete(SectionFaultCategory sectionFaultCategory);
    }
}