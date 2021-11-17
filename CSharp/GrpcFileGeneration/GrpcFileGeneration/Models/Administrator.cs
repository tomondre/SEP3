using System.ComponentModel.DataAnnotations;

namespace GrpcFileGeneration.Models
{
    public class Administrator
    {
        public int? Id { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { set; get; }
    }
}