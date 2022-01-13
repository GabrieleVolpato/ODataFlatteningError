namespace ODataFlattening.Models
{
    public class Child
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Code { get; set; }

        public string DbOnly { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
