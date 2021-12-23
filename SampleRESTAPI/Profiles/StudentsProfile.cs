using AutoMapper;

namespace SampleRESTAPI.Profiles
{
    // Instance with Auto Mapper Class
    public class StudentsProfile : Profile
    {
        // BIkin Mapping nya dari Students ke Student DTO
        public StudentsProfile()
        {

            // For Get All 
            // Name = Firstname + LastName
            CreateMap<Models.Student, Dtos.StudentDto>()
                .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // For Post Map berdasarkan dari Dto Post dimasukin ke Model Database
            CreateMap<Dtos.StudentForCreateDto, Models.Student>();
            
        }
    }
}
