using Bakim.Core.DataAccess.EntityFramework;
using Bakim.Dataaccess.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Dataaccess.Concrete
{
    public class CorporationDal : EfEntityRepositoryBase<Corporation, ApplicationDbContext>, ICorporationDal
    {
    }
}
