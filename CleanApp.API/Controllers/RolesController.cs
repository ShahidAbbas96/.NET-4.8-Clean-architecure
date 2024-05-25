using CleanApp.Application.Services.Roles;
using CleanApp.Infrastructure;
using CleanApp.Infrastructure.DTOs.Roles;
using CleanApplication.Application.Services.Roles;
using System.Threading.Tasks;
using System.Web.Http;

namespace CleanApp.API.Controllers
{
    [RoutePrefix("api/roles")] // RoutePrefix for the entire controller
    public class RolesController : ApiController
    {
        private readonly IRoleService roleService;
        public RolesController()
        {
            this.roleService = new RoleService();
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<ResponseDto> CreateRole(AddRoleDto addRoleDto)
        {
            return await this.roleService.CreateRole(addRoleDto);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<ResponseDto> UpdateRole(EditRoleDto editRoleDto)
        {
            return await this.roleService.UpdateRole(editRoleDto);
        }


        [HttpGet]
        [Route("GetRoleById")]
        public async Task<ResponseDto> GetRoleById(int id)
        {
            return await this.roleService.GetRoleById(id);
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<ResponseDto> GetAllRoles(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
            return await this.roleService.GetAllRole(pageNo, pageSize, searchString, includeDeleted);
        }
        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<ResponseDto> DeleteRole(int id)
        {
            return await this.roleService.DeleteRole(id);
        }

        [HttpPut]
        [Route("RestoreRole")]
        public async Task<ResponseDto> RestoreRole(int id)
        {
            return await this.roleService.RestoreRole(id);
        }
    }
}