using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Project
    {
        public Project()
        {
            this.Employees = new HashSet<Employee>();
            Steps = new List<Step>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        [DisplayName("Nazwa")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}