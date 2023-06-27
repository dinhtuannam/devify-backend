using AutoMapper;
using Devify.Entity;
using Devify.Models;
using Microsoft.AspNetCore.Identity;

namespace Devify.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Course, Detail_Course>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))
                .ForMember(dest => dest.CourseLanguages, opt => opt.MapFrom(src => src.CourseLanguages.Select(cl => cl.Language).ToList()))
                .ForMember(dest => dest.CourseCategories, opt => opt.MapFrom(src => src.CourseCategories.Select(cl => cl.Category).ToList()))
                .ForMember(dest => dest.Chapters, opt => opt.MapFrom(src => src.Chapters));
            CreateMap<Course, All_Course_List>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))
                .ForMember(dest => dest.CourseLanguages, opt => opt.MapFrom(src => src.CourseLanguages.Select(cl => cl.Language).ToList()))
                .ForMember(dest => dest.CourseCategories, opt => opt.MapFrom(src => src.CourseCategories.Select(cl => cl.Category).ToList()));
            CreateMap<IdentityUser,Account_Information_VM>();
            CreateMap<Creator, Detail_Course_Creator>();
            CreateMap<Category, Detail_Course_CategoryList>();
            CreateMap<Language, Detail_Course_LanguageList>();
            CreateMap<Chapter, Detail_Course_ChapterList>();
            CreateMap<Lesson, Detail_Course_LessonList>();
        }
    }
}
