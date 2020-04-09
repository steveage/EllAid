using Microsoft.EntityFrameworkCore;

namespace EllAid.DataSource.Context
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }
    }
}