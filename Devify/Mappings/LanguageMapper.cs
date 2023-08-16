﻿using AutoMapper;
using Devify.Entity;
using Devify.Models;

namespace Devify.Mappings
{
    public class LanguageMapper : Profile
    {
        public LanguageMapper()
        {
            CreateMap<CreateLanguageModel, Language>();
            CreateMap<UpdateLanguageModel, Language>();
        }
    }
}
