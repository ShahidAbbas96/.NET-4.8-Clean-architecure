using CleanApp.Application.Services.Users;
using CleanApp.Infrastructure;
using CleanApp.Infrastructure.DTOs.Users;
using System.Threading.Tasks;
using System.Web.Http;

namespace CleanApp.API.Controllers
{
    [RoutePrefix("api/users")] // RoutePrefix for the entire controller
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController()
        {
            this.userService =new UserService();
        }
        [HttpGet]
        [Route("GetAllUsers")]         
        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
            return await userService.GetAllUsers(pageNo, pageSize, searchString, includeDeleted);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<ResponseDto> AddUser(AddUserDto userDto)
        {
            return await userService.CreateUser(userDto);
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<ResponseDto> GetUser(int id)
        {
            return await this.userService.GetUserById(id);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ResponseDto> UpdateUser(EditUserDto editUserDto)
        {
            return await userService.UpdateUser(editUserDto);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ResponseDto> DeleteUser(int id)
        {
            return await userService.DeleteUser(id);
        }

        [HttpPut]
        [Route("RestoreUser")]
        public async Task<ResponseDto> RestoreUser(int id)
        {
            return await userService.RestoreUser(id);
        }
    }
}
