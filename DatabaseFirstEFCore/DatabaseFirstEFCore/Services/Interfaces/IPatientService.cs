using DatabaseFirstEFCore.DBModel;
using DatabaseFirstEFCore.Model;

namespace DatabaseFirstEFCore.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDetail> GetPatientDetailByEmail(string email);
        Task<List<PatientDetailsResponse>> GetPatientDetails();
    }
}
