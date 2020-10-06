using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.BusinessModel
{
  public  class UserRegistrationModel
    {
        [Required(ErrorMessage = "نام الزامی می باشد")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی الزامی می باشد")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "شماره موبایل الزامی می باشد")]
        public string PhoneNumber { get; set; }
        public long NationalCode { get; set; }
       public long BirthDate { get; set; }

        [Required(ErrorMessage = "آدرس ایمیل الزامی می باشد")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامی می باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار رمز عبور یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }
    }
}
