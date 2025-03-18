using AutoMapper;
using DatabaseFirstEFCore.DBModel;
using DatabaseFirstEFCore.Model;

namespace DatabaseFirstEFCore.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<PatientDetail, PatientDetailsResponse>();
        
        }
    }
}
