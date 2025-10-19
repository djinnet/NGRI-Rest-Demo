using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGRI.Library.Model
{
    //The class is used to store the data of the Estate, such as ID, Address, City, Country, PostalCode and a List of condition reports
    public class Estate
    {
        //the ID of the estate
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //the address of the estate
        [Required]
        public string Address { get; set; } = "";

        //the city of the estate
        [Required]
        public string City { get; set; } = "";

        //the country of the estate
        public string Country { get; set; } = "";

        //the postal code of the estate
        public int PostalCode { get; set; }

        //the list of condition reports
        public ICollection<ConditionReport> ConditionReports { get; set; } = new List<ConditionReport>();
    }
}
