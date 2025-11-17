using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Service
{
    public interface IDService
    {
        // Get all doctors
        Task<List<Doctor>> GetAllDoctorsAsync();

        // Add new doctor
        Task AddDoctorAsync(Doctor doctor);

        // Get doctor by Id
        Task<Doctor> GetDoctorByIdAsync(string id);

        // Update doctor
        Task UpdateDoctorAsync(string id, Doctor doctor);

        // Delete doctor
        Task DeleteDoctorAsync(string id);
    }
}
