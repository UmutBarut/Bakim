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
    public class SectionFaultCategoryManager : ISectionFaultCategoryService
    {
        private readonly ISectionFaultCategoryDal _sectionFaultCategoryDal;
        
        public SectionFaultCategoryManager(ISectionFaultCategoryDal sectionFaultCategoryDal)
        {
            _sectionFaultCategoryDal = sectionFaultCategoryDal;
        }

        public IResult Add(SectionFaultCategory sectionFaultCategory)
        {
           _sectionFaultCategoryDal.InsertAsync(sectionFaultCategory);
           return new SuccessResult();
        }

        public IResult Delete(SectionFaultCategory sectionFaultCategory)
        {
           _sectionFaultCategoryDal.Delete(sectionFaultCategory);
           return new SuccessResult();
        }

        public IDataResult<List<SectionFaultCategory>> GetAll(Expression<Func<SectionFaultCategory, bool>> expression = null)
        {
           if(expression == null)
           {
                return new SuccessDataResult<List<SectionFaultCategory>>(_sectionFaultCategoryDal.GetAll());
           }
           return new SuccessDataResult<List<SectionFaultCategory>>(_sectionFaultCategoryDal.GetAll(expression));
        }

        public IDataResult<SectionFaultCategory> GetById(Expression<Func<SectionFaultCategory, bool>> expression)
        {
            return new SuccessDataResult<SectionFaultCategory>(_sectionFaultCategoryDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(SectionFaultCategory sectionFaultCategory)
        {
            _sectionFaultCategoryDal.Update(sectionFaultCategory);
            return new SuccessResult();
        }
    }
}