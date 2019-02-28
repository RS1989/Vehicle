using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vehicle.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public string RegNumber { get; set; }
        [Required]
        [ForeignKey("StatusRefID")]
        public Status VehicleStatus { get; set; }

        [Required]
        public Int32 StatusRefID { get; set; }

        [Required]
        [ForeignKey("CustomerRefID")]
        public Customer VehicleCustomer { get; set; }

        [Required]
        public Int64 CustomerRefID { get; set; } 
    }
}
