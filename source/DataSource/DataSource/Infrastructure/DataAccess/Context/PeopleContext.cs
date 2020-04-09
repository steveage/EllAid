using Microsoft.EntityFrameworkCore;

namespace EllAid.DataSource.DataAccess.Context
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }
    }
}