using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-0715ENT;Database=MLGProjectManagerDBNew;Integrated Security=sspi;AttachDbFilename=C:\\Users\\AylaE\\Desktop\\EC kurser\\Datalagring\\MLGProjectManager\\Data\\Databases\\MLGProjectManagerDB.mdf;Encrypt=false");

        return new DataContext(optionsBuilder.Options);
    }
}