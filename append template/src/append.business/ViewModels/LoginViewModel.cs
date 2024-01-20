using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string UserName {  get; set; }
        [DataType(DataType.Password)]
        [Required]
        [StringLength (maximumLength:20,MinimumLength =8)]
        public string Password {  get; set; }
    }
}
