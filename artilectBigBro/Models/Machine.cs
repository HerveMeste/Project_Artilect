using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artilectBigBro.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
