using System.ComponentModel.DataAnnotations;

namespace Route.C41.MVC.PL.ViewModels.Account
{
	public class SignUpViewModel
	{
		[Display(Name ="Username")]
        public string UserName { get; set; }

		[Display(Name = "First name")]
		public string FName { get; set; }

		[Display(Name = "Last name")]
		public string LName { get; set; }

		public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage ="Not a matched password")]
        public string ConfirmPassword { get; set; }


        public bool IsAgree { get; set; }


    }
}
