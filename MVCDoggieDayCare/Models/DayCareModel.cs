using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDoggieDayCare.Models
{
    public class DayCareModel
    {
        [Key]
        public int PetID { get; set; }

        public string PetName { get; set; }
        public bool Male { get; set; }
        public int Weight { get; set; }


    }
}