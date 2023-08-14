﻿using AutoMapper;
using Devify.Entity;
using Devify.Models;

namespace Devify.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() {
            CreateMap<CreateCategoryModel, Category>();
            CreateMap<UpdateCategoryModel, Category>();
        }
    }
}
