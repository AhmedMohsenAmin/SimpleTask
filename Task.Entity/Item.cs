using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Entity
{
    public class Item : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Step Step { get; set; }
    }
}
