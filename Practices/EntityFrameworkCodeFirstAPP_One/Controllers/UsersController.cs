using EntityFrameworkCodeFirstAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirstAPP_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UsersController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return _userContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUsersById")]
        public Users GetUsersById(int id)
        {
            return _userContext.Users.Where(i => i.Id == id).FirstOrDefault();
        }


        [HttpPost]
        [Route("CreateUser")] 
        public string CreateUser(Users users)
        {
            _userContext.Users.Add(users);
            _userContext.SaveChanges();

            return "User Added";
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(Users users)
        {
            _userContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _userContext.SaveChanges();

            return "User Updated";
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(int id)
        {
            var user = _userContext.Users.FirstOrDefault(i => i.Id == id);
            if (user != null)
            {
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();

                return "User Remove";
            }
            else { return "User Not Found"; }
        }
    }
}
