namespace ODataFlattening.DTOs
{
    public class ParentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ChildDTO Child { get; set; }
    }
}
