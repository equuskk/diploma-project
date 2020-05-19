﻿using System.Threading.Tasks;
using DiplomaProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DiplomaProject.WebApp
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly SignInManager<Employee> _signInManager;

        public SecurityController(SignInManager<Employee> signInManager)
        {
            _signInManager = signInManager;
            _logger = Log.ForContext<SecurityController>();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string userName, [FromForm] string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true,
                                                                  true);

            if(result.Succeeded)
            {
                _logger.Debug("Пользователь {0} вошёл в аккаунт", userName);
                return LocalRedirect("/");
            }

            return BadRequest();
        }
    }
}