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
    public class MarkaManager : IMarkaService
    {
        private readonly IMarkaDal _markaDal;


        public MarkaManager(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public IResult Add(Marka marka)
        {
            _markaDal.InsertAsync(marka);
            return new SuccessResult();
        }

        public IResult Delete(Marka marka)
        {
            _markaDal.Delete(marka);
            return new SuccessResult();
        }

        public IDataResult<List<Marka>> GetAll(Expression<Func<Marka, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Marka>>(_markaDal.GetAll());
            }
            return new SuccessDataResult<List<Marka>>(_markaDal.GetAll(expression));
        }

        public IDataResult<Marka> GetById(Expression<Func<Marka, bool>> expression = null)
        {
            return new SuccessDataResult<Marka>(_markaDal.GetAll(expression).FirstOrDefault());
        }

        public IResult Update(Marka marka)
        {
            _markaDal.Update(marka);
            return new SuccessResult();
        }
    }

   
}