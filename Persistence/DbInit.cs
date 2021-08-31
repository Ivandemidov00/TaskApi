namespace Persistence
{
    public class DbInit
    {
        public static void init(TaskDbContext taskDbContext)
        {
            taskDbContext.Database.EnsureCreated();
        }
    }
}