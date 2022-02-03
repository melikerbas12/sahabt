using AutoMapper;
using SahaBT.Shared;
using SahaBT.Shared.Model.ViewModel;

namespace SahaBT.Service.AutoMapper.Profiles
{
    public class StudentLessonProfile : Profile
    {
        public StudentLessonProfile()
        {
            CreateMap<StudentLessonUpdateModel, Student>().ReverseMap();
        }
    }
}
