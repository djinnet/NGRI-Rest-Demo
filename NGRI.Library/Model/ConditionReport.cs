using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGRI.Library.Model
{
    // the class is used to store the data of the condition report, such as ID, name, buildings, damages, the date of the report and there is one estate connected to the report.
    public class ConditionReport
    {
        // the ID of the report
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // the name of the report
        public string Name { get; set; } = "";

        // the buildings of the report
        public int Buildings { get; set; } = 0;

        // the damages of the report
        public int Damages { get; set; } = 0;

        // the date of the report
        public DateTime Date { get; set; } = DateTime.Now;

        // the estate connected to the report
        public Estate Estate { get; set; }
        
    }
}