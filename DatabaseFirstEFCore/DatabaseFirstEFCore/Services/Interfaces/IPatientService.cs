using DatabaseFirstEFCore.DBModel;

namespace DatabaseFirstEFCore.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDetail> GetPatientDetailByEmail(string email);
    }
}
