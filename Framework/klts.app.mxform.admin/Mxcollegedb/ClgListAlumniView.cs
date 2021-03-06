﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace klts.app.mxform.admin.Mxcollegedb
{
    public partial class ClgListAlumniView
    {
        [Column("AlumniID")]
        public int AlumniId { get; set; }
        [Column("TenantID")]
        public Guid TenantId { get; set; }
        [Column("DeptID")]
        public int? DeptId { get; set; }
        [Column("FinYearID")]
        public int? FinYearId { get; set; }
        public int? PassingYear { get; set; }
        [StringLength(50)]
        public string Course { get; set; }
        [Column("DegreeCourseID")]
        public int? DegreeCourseId { get; set; }
        [StringLength(100)]
        public string JobProfile { get; set; }
        [Column("CompanyID")]
        public int CompanyId { get; set; }
        [StringLength(70)]
        public string DeptName { get; set; }
        [Column("HODPersonID")]
        public int? HodpersonId { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string ContactNo { get; set; }
        [Column(TypeName = "ntext")]
        public string Address { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column("HODName")]
        [StringLength(818)]
        public string Hodname { get; set; }
        [StringLength(100)]
        public string PicAlumni { get; set; }
        public bool? IsApproved { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(500)]
        public string StudentVoice { get; set; }
        [StringLength(200)]
        public string JobProfileDetail { get; set; }
        [StringLength(100)]
        public string CompName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}