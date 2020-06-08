using System;
using System.Threading.Tasks;
using DiplomaProject.Application.Employees.Commands;
using DiplomaProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DiplomaProject.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly SignInManager<Employee> _signInManager;

        public SecurityController(SignInManager<Employee> signInManager, IMediator mediator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _mediator = mediator;
            _logger = Log.ForContext<SecurityController>();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string userName, [FromForm] string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true,
                                                                  true);

            if(result.Succeeded)
            {
                _logger.Information("Пользователь {0} вошёл в аккаунт", userName);
                return LocalRedirect("/");
            }

            return BadRequest(); //TODO:
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(command.Email, command.Password, true, true);
                _logger.Information("Пользователь {0} вошёл в аккаунт", command.Email);
                return LocalRedirect("/");
            }

            return BadRequest(); //TODO:
        }
    }
}