using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblHeavyText
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public long FromChatId { get; set; }

    public int HeavyTextMessageId { get; set; }

    public int? SongId { get; set; }

    [ForeignKey("SongId")]
    [InverseProperty("TblHeavyTexts")]
    public virtual TblSong? Song { get; set; }
}
