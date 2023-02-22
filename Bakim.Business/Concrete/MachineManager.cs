using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Results;
using Bakim.Dataaccess.Abstracts;
using Bakim.Entity;
using System.Linq.Expressions;


namespace Bakim.Business.Concrete
{
    public class MachineManager : IMachineService
    {
        private readonly IMachineDal _machineDal;

        public MachineManager(IMachineDal machineDal)
        {
            _machineDal = machineDal;
        }

        public IResult Add(Machine machine)
        {
            _machineDal.InsertAsync(machine);
            return new SuccessResult();
        }

        public IDataResult<List<Machine>> GetMachines(Expression<Func<Machine, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Machine>>(_machineDal.GetAll());
            }
            else
            {
                return new SuccessDataResult<List<Machine>>(_machineDal.GetAll(expression));
            }

        }

        public IDataResult<List<Machine>> GetMachinesByGroup(int machineGroupId)
        {
            return new SuccessDataResult<List<Machine>>(_machineDal.GetAll(m => m.ProductionSectionId == machineGroupId));
        }

        public IResult Update(Machine machine)
        {
            _machineDal.Update(machine);
            return new SuccessResult();
        }
    }
}
