namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_RequiredFieldList")]
    public partial class RequiredField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequiredFieldId { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldValue { get; set; }
    }
}
