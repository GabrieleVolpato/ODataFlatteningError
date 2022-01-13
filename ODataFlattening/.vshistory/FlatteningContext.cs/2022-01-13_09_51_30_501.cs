using Microsoft.EntityFrameworkCore;
using ODataFlattening.Models;

namespace ODataFlattening
{
    public class FlatteningContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }

        public DbSet<Child> Children { get; set; }

        public FlatteningContext(DbContextOptions<FlatteningContext> options) : base(options)
        { }

        public async Task InitData()
        {
            Parent firstParent = new Parent()
            {
                Id = 1,
                Name = "Parent1",
                DbOnly = "I will be hidden"
            };
            Parent secondParent = new Parent()
            {
                Id = 2,
                Name = "Parent2",
                DbOnly = "I will be hidden"
            };

            Child firstChild = new Child()
            {
                Id = 1,
                ParentId = 1,
                Code = "C01",
                DbOnly = "I will be hidden"
            };
            Child secondChild = new Child()
            {
                Id = 2,
                ParentId = 1,
                Code = "C02",
                DbOnly = "I will be hidden"
            };
            Child thirdChild = new Child()
            {
                Id = 3,
                ParentId = 2,
                Code = "C03",
                DbOnly = "I will be hidden"
            };
            Child fourthChild = new Child()
            {
                Id = 4,
                ParentId = 2,
                Code = "C04",
                DbOnly = "I will be hidden"
            };

            //firstParent.Children.Add(firstChild);
            //firstParent.Children.Add(secondChild);
            //secondParent.Children.Add(thirdChild);
            //secondParent.Children.Add(fourthChild);

            Parents.Add(firstParent);
            Parents.Add(secondParent);

            Children.Add(firstChild);
            Children.Add(secondChild);
            Children.Add(thirdChild);
            Children.Add(fourthChild);

            await SaveChangesAsync();
        }
    }
}
