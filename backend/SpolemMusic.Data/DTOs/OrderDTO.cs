using SpolemMusic.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.DTOs
{
    public class OrderDTO
    {
        public int ClientId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
