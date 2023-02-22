
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using System.Linq.Expressions;

namespace Bakim.Business.Abstracts
{
    public interface IMachineService
    {
        public IDataResult<List<Machine>> GetMachines(Expression<Func<Machine, bool>> expression = null);
        public IDataResult<List<Machine>> GetMachinesByGroup(int machineGroupId);
        public IResult Add(Machine machine);
        public IResult Update(Machine machine);
    }
}
