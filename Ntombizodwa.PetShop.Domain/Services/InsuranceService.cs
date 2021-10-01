using System;
using System.Collections.Generic;
using Ntombizodwa.PetShop.Core.Filtering;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.IRepositories;

namespace Ntombizodwa.PetShop.Domain.Services
{
    public class InsuranceService : IInsurance
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public int TotalCount()
        {
            return _insuranceRepository.TotalCount();
        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public List<Insurance> ReadAll(Filter filter)
        {
            if (filter is not {Limit: > 0} || filter.Limit > 100)
            {
                throw new ArgumentException("Filter limit must be between 1 and 100");
            }
            int totalCount = TotalCount();
            double maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException("Page must be above 0");
            }
            return _insuranceRepository.ReadAll(filter);
        }
        
        public Insurance Create(Insurance insurance)
        {
            return _insuranceRepository.Create(insurance);
        }

        public Insurance Remove(int id)
        {
            return _insuranceRepository.Remove(id);
        }

        public Insurance Update(Insurance insurance)
        {
            return _insuranceRepository.Update(insurance);
        }
    }
}