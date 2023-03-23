using API1.Models;

namespace API1.UserRepository;

public interface IUserRepo
{
    Task<IEnumerable<User>> Get_Users();
    Task<User?> Get_UserById(int id);
    Task <List<User>> Get_UserByName(string name);
    Task<User> CreateUser(User user);
    Task UpdateUser( int id,User user);
    Task Delete_User(int id);

}