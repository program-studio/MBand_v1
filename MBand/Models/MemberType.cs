using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBand.Models
{
    public class MemberType
    {
        public int MemberTypeId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}