using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.Models.AccountViewModels
{
    public class RegisterViewModel
    {
	    [Required]
	    [RegularExpression("^[А-Я][а-я]{1,50}$", ErrorMessage = "Неверный формат имени")]
	    [Display(Name = "Имя")]
	    public string Name { get; set; }

	    [Required]
	    [RegularExpression("^(([А-Я][а-я]{1,50})([-][А-Я][а-я]{1,50})?)$", ErrorMessage = "Неверный формат фамилии")]
	    [Display(Name = "Фамилия")]
	    public string Surname { get; set; }

		[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
