using AutoMapper;
using StudentManagement.Models.Entities;
using StudentManagement.Models.ViewModels;

namespace StudentManagement.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add your mapping configurations here
            // For example:
            // CreateMap<SourceModel, DestinationModel>();
            // CreateMap<DestinationModel, SourceModel>();

            CreateMap<Student, StudentListViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.DOB.Year))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<StudentCreateViewModel, Student>().ReverseMap();
            CreateMap<StudentEditViewModel, Student>().ReverseMap()
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => DateTime.Now.Year - src.DOB.Year))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Add other mappings as needed
        }
    }
}
