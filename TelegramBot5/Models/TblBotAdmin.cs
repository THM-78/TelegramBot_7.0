using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblBotAdmin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string? Name { get; set; }

    public long AdminChatId { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("TblBotAdmins")]
    public virtual TblAdminRol Role { get; set; } = null!;
}
