using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artilectBigBro.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Boolean IsAccomplished { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual Machine Machine { get; set; }
    }
}