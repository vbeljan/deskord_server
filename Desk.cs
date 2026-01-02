using deskord_server.Components.Pages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace deskord_server.Models {
    public class Desk {
        [Key]
        public required string deskid {get; set;}
        public required string room {get; set;}
        public string? occupiedby {get; set;}
    }
}
