using Core.Entities;
using Core.Interfases;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GovermentService
    {
        private readonly IGovermentRepository _govermentRepository;

        public GovermentService(IGovermentRepository govermentRepository)
        {
            _govermentRepository = govermentRepository;
        }

        public async Task<Goverment> GetGovermentById(int id)
        { 
            var goverment = await _govermentRepository.GetByIdAsync(id);

            if (goverment is null)
                throw new KeyNotFoundException("Goverment not found");

            return goverment;
        }

        public async Task<IEnumerable<Goverment>> GetAllGoverments()
        {
            return await _govermentRepository.GetAllAsync();
        }

        public void AddGoverment(Goverment goverment) 
        { 
            _govermentRepository.Add(goverment); 
        }

        public void AddGoverments(IEnumerable<Goverment> goverments)
        {
            _govermentRepository.AddRange(goverments);
        }

        public void UpdateGoverment(Goverment goverment)
        {
            var existingGoverment = _govermentRepository.GetByIdAsync(goverment.Id).Result;

            if (existingGoverment is null)
                throw new KeyNotFoundException("Goverment to update not found");

            _govermentRepository.Update(goverment);
        }

        public void DeleteGoverment(Goverment goverment)
        {
            var existingGoverment = _govermentRepository.GetByIdAsync(goverment.Id).Result;

            if (existingGoverment is null)
                throw new KeyNotFoundException("Goverment to delete not found");

            _govermentRepository.Remove(goverment);
        }
    }
}
