using Microsoft.EntityFrameworkCore;
using ReminderList.Models;

namespace ReminderList.Data;
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
}