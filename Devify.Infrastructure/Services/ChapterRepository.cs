﻿using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Infrastructure.Services
{
    public class ChapterRepository : GenericRepository<SqlChapter>, IChapterRepository
    {
        private readonly DataContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public ChapterRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = context;
            _unitOfWork = unitOfWork;
        }
    }
}