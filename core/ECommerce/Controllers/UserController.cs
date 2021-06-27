using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Extensions;
using ECommerce.Resources.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("/api/ecommerce/users")]
    [EnableCors("ecommerce-policy")]
    [Authorize]
    public class UserController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resource;
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _service.FindByIdAsync(id);
            if (user == null) return NoContent();
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _service.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(user);
            
            return Ok(userResource);

        }
        
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _service.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest();

            var userResource = _mapper.Map<User, UserResource>(result.User);
            
            return Ok(userResource);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<User, UserResource>(result.User);

            return Ok(resource);
        }
        
    }
}