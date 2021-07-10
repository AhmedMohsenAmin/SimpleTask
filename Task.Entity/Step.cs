using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Entity
{
    public class Step : BaseEntity
    {
        public Step()
        {
            Items = new List<Item>();
        }

        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }

    }
}
