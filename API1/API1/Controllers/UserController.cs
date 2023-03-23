using API1.Models;
using API1.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers;
[Route("Api/Users")]
[ApiController]
public class UserController : Controller       
{
    private readonly IUserRepo _userRepo;
    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet]

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepo.Get_Users();
    }
   // [HttpGet("{userid}")]
   // public  async Task<ActionResult<User?>>GetUserById(int userid)
    //{

       // return await _userRepo.Get_UserById(userid);
  //  }

    [HttpGet("{userName}")]

    public async  Task<List<User>> GetUserByName(string userName)
    {
        return await _userRepo.Get_UserByName(userName);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        var newUser = await _userRepo.CreateUser(user);
        return CreatedAtAction(nameof(GetUsers), new { userid = newUser.Id }, newUser);

    }

    [HttpPut("{userid}")]
    public async Task<ActionResult> UpdateUser([FromRoute]int userid, [FromBody] User user)
    {

         await _userRepo.UpdateUser(userid,user);
         return Ok();

    }
    [HttpDelete("{userid}")]
    
    public async Task<ActionResult>Delete(int userid)
    {
        var userToDelete = await _userRepo.Get_UserById(userid);
        if (userToDelete == null)
        {
            return NotFound();
            
        }

        await _userRepo.Delete_User(userToDelete.Id);
        return NoContent();
    }


} 