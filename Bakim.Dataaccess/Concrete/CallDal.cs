

using Bakim.Core.DataAccess.EntityFramework;
using Bakim.Dataaccess.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;
using Bakim.Entity.Dto;

namespace Bakim.Dataaccess.Concrete
{
    public class CallDal : EfEntityRepositoryBase<Call, ApplicationDbContext>, ICallDal
    {
        public List<CallCountsPerMachineDto> GetCountsByMachineId()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from c in context.Calls
                             join m in context.Machines
                             on c.MakineId equals m.MachineId
                             select new CallCountsPerMachineDto
                             {
                                 MachineName = m.MachineName,
                                 Count = context.Calls.Where(c => c.MakineId == m.MachineId).Count()
                             };

                return result.ToList();
            }
        }

        public CallDto GetCallDetailsById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from c in context.Calls
                             join m in context.Machines
                             on c.MakineId equals m.MachineId
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CallDto
                             {
                                 CallId = c.CallId,
                                 ComplationDate = c.ComplationDate,
                                 CreatedDate = c.CreatedDate,
                                 Description = c.Description,
                                 IsActive = c.IsActive,
                                 IsEmergency = c.IsEmergency,
                                 MachineName = m.MachineName,
                                 Machine = m,
                                 MakineId = m.MachineId,
                                 User = u,
                                 UserId = u.Id
                             };
                return result.First();
            }
        }

        public List<CallDto> GetAllCalls()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from c in context.Calls
                             join m in context.Machines
                             on c.MakineId equals m.MachineId
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CallDto
                             {
                                 CallId = c.CallId,
                                 ComplationDate = c.ComplationDate,
                                 CreatedDate = c.CreatedDate,
                                 Description = c.Description,
                                 IsActive = c.IsActive,
                                 IsEmergency = c.IsEmergency,
                                 MachineName = m.MachineName,
                                 Machine = m,
                                 MakineId = m.MachineId,
                                 User = u,
                                 UserId = u.Id
                             };
                return result.ToList();
            }
        }
    }

}
