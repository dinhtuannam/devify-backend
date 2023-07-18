﻿using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    public class CourseLevel : TrackEntity
    {
        [Key]
        public string CourseLevelId { get; set; }
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
        public CommonEnum Status { get; set; }
        public ICollection<Course> Courses { get; } = new List<Course>();
    }
}