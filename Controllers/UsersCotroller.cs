using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_Example.Repos;
using Restful_Example.ViewModels;

namespace Restful_Example.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersCotroller : ControllerBase
    {
        private readonly IUserRepo Repo;
        public UsersCotroller(IUserRepo repo)
        {
            Repo = repo;  
        }
       
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(Repo.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(Guid Id)
        {
            try
            {   
                var user = Repo.GetById(((Id)));
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddNewUser(UserViewModel userViewModel)
        {
            try
            {
                Repo.Add(userViewModel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid Id)
        {
            try
            {
                Repo.Delete(Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
