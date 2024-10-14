using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.SoundWave.Entities;
using System.ComponentModel.DataAnnotations;
using Web.Server.SoundWave.ViewModel;

namespace Web.Server.SoundWave.Pages.Account
{
    public class RegisterModel(UserManager<User> userManager) : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; } = new();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                UserName = RegisterViewModel.EmailAddress,
                Email = RegisterViewModel.EmailAddress
            };

            var result = await userManager.CreateAsync(user, RegisterViewModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                return RedirectToPage("/Account/Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
/*
 *  private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
 */