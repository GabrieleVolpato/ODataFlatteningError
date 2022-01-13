namespace ODataFlattening.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DbOnly { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
