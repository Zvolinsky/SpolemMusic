using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SpolemMusic.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public List<int> ProductIds { get; set; }
        public  DateTime OrderDate { get; set; }
        [AllowNull]
        public DateTime? ExecutionDate { get; set; } 
        public  bool OrderReceived { get; set; }
    }
}
