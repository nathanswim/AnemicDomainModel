using System.ComponentModel.DataAnnotations;

namespace Logic.Dtos
{
    public sealed class UpdateCustomerDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
    }




}
