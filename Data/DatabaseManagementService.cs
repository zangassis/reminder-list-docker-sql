using Microsoft.EntityFrameworkCore;

namespace ReminderList.Data
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TodoContext>();
                context.Database.Migrate();
            }
        }
    }
}