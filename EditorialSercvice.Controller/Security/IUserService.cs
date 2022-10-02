using EditorialService.BL.Domain.Model.Entities;

namespace EditorialService.Controller.Security
{
    public interface IUserService
    {
        User isUser(string username, string password);
    }
}
