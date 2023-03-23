using API1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API1.UserRepository;

public class UserRepo: IUserRepo
{
   private readonly ContextDB _contextDb;

   public UserRepo(ContextDB contextDb)
   {
       _contextDb = contextDb;
   }

  public async Task<IEnumerable<User>> Get_Users()
  {
      return await _contextDb.Users.ToListAsync();
  }

  public async Task<User?> Get_UserById(int id)
  {
      return await _contextDb.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
      
  }
  
      public async Task<List<User>> Get_UserByName(string name)
      {
          return await _contextDb.Users.Where(c => c.Name == name).ToListAsync();
          
      }

      public async Task<User> CreateUser( User user)
      {
          _contextDb.Users?.Add(user);
          await _contextDb.SaveChangesAsync();
          return user;
      }

      

   public async Task UpdateUser( int id,User user)
   {
       var record = await _contextDb.Users.FindAsync(id);

       if (record != null)
       {
           record.Name = user.Name;
           record.Surname = user.Surname;
           record.Age = user.Age;
           record.Email = user.Email;
           await _contextDb.SaveChangesAsync();
       }
   }

   public  async Task Delete_User(int id)
   {
       var userDelete = await _contextDb.Users.FindAsync(id);

       if (userDelete != null)
       {
           _contextDb.Users.Remove(userDelete);
           await _contextDb.SaveChangesAsync();
       }
   }


}