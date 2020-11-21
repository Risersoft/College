﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace klts.app.mxform.admin.Mxcollegedb
{
    public partial class ClgListCommitteeMemberView
    {
        [Column("CommitteeMemberID")]
        public int CommitteeMemberId { get; set; }
        [Column("TenantID")]
        public Guid TenantId { get; set; }
        [Column("CommitteeID")]
        public int? CommitteeId { get; set; }
        [Column("PersonID")]
        public int? PersonId { get; set; }
        [Column("DeptID")]
        public int? DeptId { get; set; }
        public int? Rank { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Sdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Edate { get; set; }
        [Column("CompanyID")]
        public int? CompanyId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsManagement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommSdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommEdate { get; set; }
        [StringLength(100)]
        public string Occupation { get; set; }
        [StringLength(100)]
        public string CommDesig { get; set; }
        [StringLength(818)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string CommitteeCode { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(50)]
        public string Desig { get; set; }
        [StringLength(255)]
        public string CellNum { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(250)]
        public string DescriptionText { get; set; }
        [Column("DescriptionHTML")]
        public string DescriptionHtml { get; set; }
        public bool? NotListed { get; set; }
    }
}