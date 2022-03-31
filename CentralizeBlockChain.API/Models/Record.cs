using System;
using System.ComponentModel.DataAnnotations;

namespace CentralizeBlockChain.API.Models
{
    public class Record
    {
        [Key]
        public int BlockNumer { get; set; }
        public DateTime? Timestamp { get; set; }
        [Required]
        public string pervious_hash { get; set; }
        [Required]
        public double proof { get; set; }
    }
}
