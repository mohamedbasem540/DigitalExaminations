using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.StudentModels;
using Entities.DBModels.UserModels;

namespace StudentPortal.MappingProfileCls
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });


            _ = CreateMap<StudentCreateModel, User>();
            _ = CreateMap<StudentCreateModel, Student>();

            _ = CreateMap<StudentModel, StudentEditModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.User.EmailAddress))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber));

            _ = CreateMap<StudentEditModel, User>();
            _ = CreateMap<StudentEditModel, Student>();

        }
    }
}
