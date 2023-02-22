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
    public class CalendarManager : ICalendarService
    {
        private readonly ICalendarDal _calendardal;

        public CalendarManager(ICalendarDal calendarDal)
        {
            _calendardal = calendarDal;
        }

         public IResult Add(Calendar calendar)
        {
            _calendardal.InsertAsync(calendar);
            return new SuccessResult();
        }

        public IDataResult<List<Calendar>> CalendarList(Expression<Func<Calendar, bool>> expression = null)
        {
            if(expression == null){
                return new SuccessDataResult<List<Calendar>>(_calendardal.GetAll());
            }
                return new SuccessDataResult<List<Calendar>>(_calendardal.GetAll(expression));

        }

        public IResult Delete(Calendar calendar)
        {
            _calendardal.Delete(calendar);
            return new SuccessResult();
        }

        public IResult Update(Calendar calendar)
        {
            _calendardal.Update(calendar);
            return new SuccessResult();
        }

    }
}