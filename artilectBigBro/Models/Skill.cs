﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artilectBigBro.Models
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}