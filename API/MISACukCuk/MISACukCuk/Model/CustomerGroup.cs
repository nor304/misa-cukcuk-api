using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Model
{
    public class CustomerGroup
    {
        public Guid? CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public Guid? ParentId { get; set; }
    }
}
