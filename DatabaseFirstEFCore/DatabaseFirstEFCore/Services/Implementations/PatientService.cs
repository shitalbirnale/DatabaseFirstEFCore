using DatabaseFirstEFCore.DBModel;
using DatabaseFirstEFCore.Services.Interfaces;

namespace DatabaseFirstEFCore.Services.Implementations
{
    public class PatientService : IPatientService
    {

        private readonly DbfirstEfcoreContext _appDbContextService;

        public PatientService(DbfirstEfcoreContext applicationContext)
        {
            _appDbContextService = applicationContext;
        }
        /// <summary>
        /// GetPatientDetailByEmail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<PatientDetail> GetPatientDetailByEmail(string email)
        {
            var patientInfo = new PatientDetail();
            try
            {
                patientInfo = _appDbContextService.PatientDetails.Where(x => x.EmailAddress == email).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(patientInfo);
        }
    }
}
