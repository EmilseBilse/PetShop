using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Filtering;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        List<Insurance> ReadAll(Filter filter);
        Insurance Create(Insurance insurance);
        Insurance Remove(int id);
        Insurance Update(Insurance insurance);
        int TotalCount();
    }
}