using Microsoft.AspNetCore.Mvc;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //lista todos los usuarios
        [HttpGet]
        public IEnumerable< User > UserList()
        {
            var userList = _userService.GetUserList();
            return userList;
        }

        //buscar por id de usuario
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        //agrega usuario
        [HttpPost]
        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }

        //modificar usuario
        [HttpPut]
        public User updateUser(User user)
        {
            return _userService.UpdateUser(user);
        }

        //borra usuario
        [HttpDelete("{id}")]
        public bool Deleteuser(int id)
        {
            return _userService.DeleteUser(id);
        }

        //agrega migracion
    }
}
