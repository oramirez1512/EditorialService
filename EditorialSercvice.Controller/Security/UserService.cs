using EditorialService.BL.Common;
using EditorialService.BL.Domain.Model.Entities;

namespace EditorialService.Controller.Security
{
    public class UserService : IUserService
    {
        public readonly EditorialDbContext db;

        public UserService(EditorialDbContext db)
        {
            this.db = db;
        }

        public User isUser(string username, string password) => db.users.Where(x=>x.UserName == username && x.Password==password).FirstOrDefault();
    }
}
