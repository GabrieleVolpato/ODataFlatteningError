using System.Collections.Generic;

namespace ODataFlattening.Models
{
    public class Parent
    {
        public Parent()
        {
            Children = new HashSet<Child>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DbOnly { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
