using System.ComponentModel.DataAnnotations;

namespace Route.C41.MVC.PL.ViewModels.Account
{
    public class SignInViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


       


        public bool RememberMe { get; set; }
    }
}
