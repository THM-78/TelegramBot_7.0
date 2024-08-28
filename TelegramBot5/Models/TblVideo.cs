using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblVideo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public long FromChatId { get; set; }

    public int VideoMessageId { get; set; }

    public string? Caption { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("TblVideos")]
    public virtual VideoCategory Category { get; set; } = null!;
}
