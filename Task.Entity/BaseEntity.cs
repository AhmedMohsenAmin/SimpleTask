using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Entity
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
