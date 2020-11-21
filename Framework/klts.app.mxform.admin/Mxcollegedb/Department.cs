﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace klts.app.mxform.admin.Mxcollegedb
{
    public partial class Department
    {
        public Department()
        {
            Alumni = new HashSet<Alumni>();
            NoticeBoard = new HashSet<NoticeBoard>();
        }

        [Key]
        [Column("DeptID")]
        public int DeptId { get; set; }
        [Key]
        [Column("TenantID")]
        public Guid TenantId { get; set; }
        [Column("CompanyID")]
        public int? CompanyId { get; set; }
        [StringLength(70)]
        public string DeptName { get; set; }
        [Column("HODPersonID")]
        public int? HodpersonId { get; set; }
        public int? EstabYear { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(50)]
        public string DepCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [ForeignKey("TenantId,CompanyId")]
        [InverseProperty("Department")]
        public virtual Company Company { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Alumni> Alumni { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<NoticeBoard> NoticeBoard { get; set; }
    }
}