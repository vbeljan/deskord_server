using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace deskord_server.Models {
    public class User {
        [Key]
        public required string email {get; set;}
        public required string password {get; set;}
        public required string fullname {get; set;}
        public string? used_desk {get; set;}
    }
}