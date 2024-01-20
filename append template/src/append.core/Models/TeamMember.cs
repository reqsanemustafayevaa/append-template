using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.core.Models
{
    public class TeamMember:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string FullName { get; set; }
        [Required]
        [StringLength(70)]

        public string Profession { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
       
        [StringLength(100)]
        public string FbUrl {  get; set; }
        [StringLength(100)]
        public string InstaUrl {  get; set; }
        [StringLength(100)]
        public string TwitterUrl {  get; set; }
        [StringLength(100)]
        public string LimkedinUrl {  get; set; }
        [StringLength(100)]
        public string? ImageUrl {  get; set; }
      
        [NotMapped]
        public IFormFile? ImageFile {  get; set; }

    }
}
