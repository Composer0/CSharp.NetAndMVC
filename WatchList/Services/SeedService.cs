// Purpose is to add records to specific database tables so that a limited amount of information is synced up at the time of startup.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using WatchList.Data;
using WatchList.Models.Database;
using WatchList.Models.Settings;


namespace WatchList.Services
{
    public class SeedService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(IOptions<AppSettings> appSettings, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task ManageDataAsync()
        {
            await UpdataDatabaseAsync();
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedCollection();
        }

        private async Task UpdataDatabaseAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }

        private async Task SeedRolesAsync() //adds roles to users.
        {
            if (_dbContext.Roles.Any()) return; //If we don't find any roles... return

            var adminRole = _appSettings.WatchListSettings.DefaultCredentials.Role;

            await _roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        private async Task SeedUsersAsync()
        {
            if (_userManager.Users.Any()) return;


            var credentials = _appSettings.WatchListSettings.DefaultCredentials;
            var newUser = new IdentityUser()
            {
                Email = credentials.Email,
                UserName = credentials.Email,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(newUser, credentials.Password);
            await _userManager.AddToRoleAsync(newUser, credentials.Role);
        }

        private async Task SeedCollection()
        {
            if (_dbContext.Collection.Any()) return;

            _dbContext.Add(new Collection()
            {
                Name = _appSettings.WatchListSettings.DefaultCollection.Name,
                Description = _appSettings.WatchListSettings.DefaultCollection.Description
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
