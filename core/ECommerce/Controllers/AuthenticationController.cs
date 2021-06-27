using System;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Extensions;
using ECommerce.Resources.User;
using ECommerce.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    [EnableCors("ecommerce-policy")]
    [Route("/api/ecommerce/auth")]
    public class AuthenticationController: ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;

        }

        [HttpPost]
        public async Task<IActionResult> LoginCredentials([FromBody] AuthUserResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var user = _mapper.Map<AuthUserResource, User>(resource);
                var result = await _userService.FirstOrDefaultAsync(user.Email, user.Password);

                if (result == null)
                    return Unauthorized();

                var token = CryptoFunction.GenerateToken(_configuration);
                return Ok(new
                {
                    error = false,
                    result = new
                    {
                        token, user = new {result.Id, result.Email}
                    }
                });

            }
            catch (Exception e)
            {
                var message = $"An error occurred in auth service {e.Message}";
                return BadRequest(new {error = true, result = new {message}});
            }
            
        }
    }
}