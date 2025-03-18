using AutoMapper;
using DatabaseFirstEFCore.DBModel;
using DatabaseFirstEFCore.Model;
using DatabaseFirstEFCore.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DatabaseFirstEFCore.Services.Implementations
{
    public class PatientService : IPatientService
    {

        private readonly DbfirstEfcoreContext _appDbContextService;

        private readonly IMapper _mapper;

        public PatientService(DbfirstEfcoreContext applicationContext, IMapper mapper)
        {
            _appDbContextService = applicationContext;
            _mapper = mapper;
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

        public Task<List<PatientDetailsResponse>> GetPatientDetails()
        {
            List <PatientDetailsResponse> response = new List<PatientDetailsResponse>();
            try
            {
                var patientInfo = _appDbContextService.PatientDetails.ToList();
                if (patientInfo.Count > 0)
                {
                    response = _mapper.Map<List<PatientDetailsResponse>>(patientInfo);
                }
            }
            catch (Exception ex) {
                throw new Exception("Exception at GetPatientDetails");
                
            }
            return Task.FromResult(response);
        }
    }
}
