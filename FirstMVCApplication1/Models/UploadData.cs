using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApplication1.Models
{
    public class UploadData
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public IFormFile? Imagem { get; set; }
    }
}
