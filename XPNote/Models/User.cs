using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPNote.Models
{
    partial class User: ObservableValidator
    {
        
        public int Id;
        [ObservableProperty]
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        string? userName;

        [ObservableProperty]
        [Required]
        [MinLength(6)]
        [MaxLength(18)]
        string? password;

        [ObservableProperty]
        [Required]
        [EmailAddress]
        string? email;
    }
}
