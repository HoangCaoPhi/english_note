﻿using EnglishNote.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EnglishNote.Api.Infrastructure.Extensions;

public static class MigrationExtensions
{
    public static void MigrationDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationWriteDbContext>();
        dbContext.Database.Migrate();
    }
}
