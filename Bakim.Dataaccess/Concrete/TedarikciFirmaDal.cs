using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Core.DataAccess.EntityFramework;
using Bakim.Dataaccess.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;

namespace Bakim.Dataaccess.Concrete
{
    public class TedarikciFirmaDal : EfEntityRepositoryBase<TedarikciFirma,ApplicationDbContext>, ITedarikciFirmaDal
    {
        
    }
}