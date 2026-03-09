using CreditUnionPortal.Models;
namespace CreditUnionPortal.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context) {

            if (context.Members.Any())
                return;
            
            context.Members.AddRange(
                new Member { FirstName = "John", LastName = "Smith", Email = "john@email.com", Status = "Active", CreatedDate = DateTime.Now },
                new Member { FirstName = "King", LastName = "steve", Email = "king@email.com", Status = "Active", CreatedDate = DateTime.Now },
                new Member { FirstName = "Singh", LastName = "Harman", Email = "singh@email.com", Status = "Flagged", CreatedDate = DateTime.Now }
                );

            context.SaveChanges();
        }

    }
}
