using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.SoundWave.Entities;
using Web.Server.SoundWave.ViewModel;

namespace Web.Server.SoundWave.Pages.Account
{
    public class LoginModel(UserManager<User> userManager,SignInManager<User> signInManager) : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; } = new();
        //public void OnGet()
        //{
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                return Page();
            }
            var user =await userManager.FindByEmailAsync(LoginViewModel.EmailAddress);
            if(user!=null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, LoginViewModel.Password);
                if (passwordCheck) {
                    var result = await signInManager.PasswordSignInAsync(user,LoginViewModel.Password, false,false);
                    if (result.Succeeded) {
                        return RedirectToPage("../Index");
                    }
                    //return RedirectToPage("../Index");
                }
                TempData["Error"] = "Неверный логин и пароль";
                return Page();
            }
            TempData["Error"] = "Неверный логин и пароль";
            return Page();
        }
    }
}
