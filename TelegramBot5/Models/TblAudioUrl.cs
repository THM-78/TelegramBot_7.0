using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

[Table("TblAudioUrl")]
[Index("Id", Name = "IX_TblAudioUrl")]
public partial class TblAudioUrl
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(64)]
    public string AudioUrl { get; set; } = null!;
}
