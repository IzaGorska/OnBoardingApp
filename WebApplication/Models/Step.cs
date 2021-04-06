using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepID { get; set; }

        //[ForeignKey("Project")]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public virtual Project Project { get; set; }
    }
}