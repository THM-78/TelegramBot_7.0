using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

[Table("TblAdminRol")]
public partial class TblAdminRol
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<TblBotAdmin> TblBotAdmins { get; set; } = new List<TblBotAdmin>();
}
