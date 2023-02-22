using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;

namespace Bakim.Business.Abstracts
{
    public interface ICalendarService
    {
       public IResult Add(Calendar calendar);
        public IResult Delete(Calendar calendar);
        public IResult Update(Calendar calendar);

        public IDataResult<List<Calendar>> CalendarList(Expression<Func<Calendar,bool>> expression = null);
    }
}