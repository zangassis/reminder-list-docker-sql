using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ReminderList.Data
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TodoContext>();

                if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
