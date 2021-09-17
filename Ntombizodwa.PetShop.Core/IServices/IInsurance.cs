using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.Core.IServices
{
    public interface IInsurance
    {
        Insurance GetById(int id);
        List<Insurance> ReadAll();
        Insurance Create(Insurance insurance);
    }
}