﻿using Bakim.Core.DataAccess.EntityFramework;
using Bakim.Dataaccess.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;

namespace Bakim.Dataaccess.Concrete
{
    public class SectionDal : EfEntityRepositoryBase<Section, ApplicationDbContext>, ISectionDal
    {

    }
}
