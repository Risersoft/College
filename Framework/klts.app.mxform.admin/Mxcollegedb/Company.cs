﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace klts.app.mxform.admin.Mxcollegedb
{
    public partial class Company
    {
        public Company()
        {
            Committee = new HashSet<Committee>();
            Department = new HashSet<Department>();
        }

        [Key]
        [Column("CompanyID")]
        public int CompanyId { get; set; }
        [Key]
        [Column("TenantID")]
        public Guid TenantId { get; set; }
        [Column("MainPartyID")]
        public int? MainPartyId { get; set; }
        [StringLength(100)]
        public string CompName { get; set; }
        [Column("HRStartDate", TypeName = "datetime")]
        public DateTime? HrstartDate { get; set; }
        [Column("PrincipalPersonID")]
        public int? PrincipalPersonId { get; set; }
        [Column("PrincipalMessageHTML")]
        public string PrincipalMessageHtml { get; set; }
        public string PrincipalMessageText { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public string CollegePros { get; set; }
        [StringLength(50)]
        public string CompCode { get; set; }
        [Column("PANNum")]
        [StringLength(50)]
        public string Pannum { get; set; }
        public string AcademicCalender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<Committee> Committee { get; set; }
        [InverseProperty("Company")]
        public virtual ICollection<Department> Department { get; set; }
    }
}