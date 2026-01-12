using System.Net.Mail;
using deskord_server.Data;
using deskord_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
public static class DbInterface
{
    public static async Task Initialize(AppDbContext context)
    {
        // Check if the database already exists
        if (await context.desks.AnyAsync<Desk>()) return; // DB has been seeded

        var desks = new[]
        {
            new Desk { deskid = "Desk 1", room = "OTP", occupiedby = null },
            new Desk { deskid = "Desk 2", room = "Management", occupiedby = null },
            new Desk { deskid = "Desk 3", room = "Administration", occupiedby = null },
        };

        await context.desks.AddRangeAsync(desks);
        await context.SaveChangesAsync();
        return;
    }

    public static async Task Save(AppDbContext context, List<Desk> desks_to_save)
    {
        context.desks.UpdateRange(desks_to_save);
        await context.SaveChangesAndNotifyAsync();
        return;
    }
    public static Task<List<Desk>> GetAllDesks(AppDbContext context)
    {
        return context.desks.ToListAsync<Desk>();
    }

    public static async Task<User> FindUser(AppDbContext context, string input_email)
    {
        // var user = from u in context.users
        //             where u.email == input_email
        //             select u;
        return await context.users
                        .Where(u => u.email == input_email)
                        .FirstOrDefaultAsync();
    }
}
