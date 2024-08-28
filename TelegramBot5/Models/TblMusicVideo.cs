using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblMusicVideo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int SongId { get; set; }

    public long FromChatId { get; set; }

    public int VideoMessageId { get; set; }

    [StringLength(128)]
    public string Caption { get; set; } = null!;

    [ForeignKey("SongId")]
    [InverseProperty("TblMusicVideos")]
    public virtual TblSong Song { get; set; } = null!;
}
