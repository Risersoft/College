﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace klts.app.mxform.admin.Mxcollegedb
{
    public partial class Alumni
    {
        [Key]
        [Column("AlumniID")]
        public int AlumniId { get; set; }
        [Key]
        [Column("TenantID")]
        public Guid TenantId { get; set; }
        [Column("DeptID")]
        public int? DeptId { get; set; }
        [Column("FinYearID")]
        public int? FinYearId { get; set; }
        [Column("DegreeCourseID")]
        public int? DegreeCourseId { get; set; }
        [StringLength(100)]
        public string Subject1 { get; set; }
        [StringLength(100)]
        public string Subject2 { get; set; }
        [StringLength(100)]
        public string Subject3 { get; set; }
        [StringLength(100)]
        public string JobProfile { get; set; }
        [StringLength(200)]
        public string JobProfileDetail { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string ContactNo { get; set; }
        [Column(TypeName = "ntext")]
        public string Address { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string StudentVoice { get; set; }
        [StringLength(100)]
        public string PicAlumni { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public bool? IsApproved { get; set; }
        [Column("CompanyID")]
        public int? CompanyId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [ForeignKey("TenantId,DeptId")]
        [InverseProperty("Alumni")]
        public virtual Department Department { get; set; }
    }
}