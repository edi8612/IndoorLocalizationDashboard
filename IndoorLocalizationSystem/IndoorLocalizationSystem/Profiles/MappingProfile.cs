using AutoMapper;
using IndoorLocalizationSystem.DTOs;
using IndoorLocalizationSystem.Models;

namespace IndoorLocalizationSystem.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Professor -> ProfessorDTO
            CreateMap<Professor, ProfessorDTO>()
                .ForMember(dest => dest.CourseNames,
                    opt => opt.MapFrom(src => src.Courses.Select(c => c.Name).ToList()));

            // Student -> StudentDTO
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.Name))
                .ForMember(dest => dest.DeviceMacAddress, opt => opt.MapFrom(src => src.Device.MACAddress))
                .ForMember(dest => dest.PositionX, opt => opt.MapFrom(src => src.Device.PositionX))
                .ForMember(dest => dest.PositionY, opt => opt.MapFrom(src => src.Device.PositionY));

            // Course -> CourseDTO
            CreateMap<Course, CourseDTO>()
                .ForMember(dest => dest.ProfessorName,
                    opt => opt.MapFrom(src => src.Professor.Name))
                .ForMember(dest => dest.StudentCount,
                    opt => opt.MapFrom(src => src.Students.Count));

            // Device -> DeviceDTO
            CreateMap<Device, DeviceDTO>()
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src => src.Student.Name));
        }

    }
}
