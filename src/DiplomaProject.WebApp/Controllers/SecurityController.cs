using System;
using System.Threading.Tasks;
using DiplomaProject.Domain.Entities;
using DiplomaProject.WebApp.Models;
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
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;

        public SecurityController(SignInManager<Employee> signInManager, UserManager<Employee> userManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
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
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MidName = model.MidName,
                BirthDay = model.BirthDay,
                EmploymentDate = model.EmploymentDate,
                Email = model.Email,
                UserName = model.Email,
                Sex = model.Sex,
                EmployeePositionId = 1
            };

            var result = await _userManager.CreateAsync(employee, model.Password);
            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(employee.Email, model.Password, true, true);
                return LocalRedirect("/");
            }

            return BadRequest(); //TODO:
        }
    }
}