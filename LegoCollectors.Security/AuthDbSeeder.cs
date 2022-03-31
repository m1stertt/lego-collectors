

using LegoCollectors.Security.Model;
using LegoCollectors.Security.Services;

namespace LegoCollectors.Security
{
    public class AuthDbSeeder : IAuthDbSeeder
    {
        private readonly AuthDbContext authDbContext;

        public AuthDbSeeder(AuthDbContext ctx)
        {
            authDbContext = ctx;
        }

        public void SeedDevelopment()
        {
            authDbContext.Database.EnsureDeleted();
            authDbContext.Database.EnsureCreated();
            AuthService.CreateHashAndSalt("123456", out var passwordHash, out var salt);

            authDbContext.LoginUsers.Add(new LoginUser
            {
                Email = "admin@admin.dk",
                HashedPassword = passwordHash,
                PasswordSalt = salt,
                DbUserId = 1,
            });
            AuthService.CreateHashAndSalt("123456", out passwordHash, out salt);
            authDbContext.LoginUsers.Add(new LoginUser
            {
                Email = "user@user.dk",
                HashedPassword = passwordHash,
                PasswordSalt = salt,
                DbUserId = 2,
            });
            authDbContext.Permissions.AddRange(new Permission()
            {
                Name = "Admin"
            });
            authDbContext.UserPermissions.Add(new UserPermission {PermissionId = 1, UserId = 1});
            authDbContext.SaveChanges();
        }

        public void SeedProduction()
        {
            // // For now. Should be fixed for production ready code.
            // authDbContext.Database.EnsureDeleted();
            //
            authDbContext.Database.EnsureCreated();
            // AuthService.CreateHashAndSalt("123456", out var passwordHash, out var salt);
            //
            // authDbContext.LoginUsers.Add(new LoginUser
            // {
            //     Email = "admin@admin.dk",
            //     HashedPassword = passwordHash,
            //     PasswordSalt = salt,
            //     DbUserId = 1,
            // });
            // AuthService.CreateHashAndSalt("123456", out passwordHash, out salt);
            // authDbContext.LoginUsers.Add(new LoginUser
            // {
            //     Email = "user@user.dk",
            //     HashedPassword = passwordHash,
            //     PasswordSalt = salt,
            //     DbUserId = 2,
            // });
            // authDbContext.Permissions.AddRange(new Permission()
            // {
            //     Name = "Admin"
            // });
            // authDbContext.UserPermissions.Add(new UserPermission {PermissionId = 1, UserId = 1});
            // authDbContext.SaveChanges();
        }
    }
}