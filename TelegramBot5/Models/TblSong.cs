using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblSong
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string PersianName { get; set; } = null!;

    [StringLength(64)]
    public string Artists { get; set; } = null!;

    public int AlbumId { get; set; }

    public int SongMessageId { get; set; }

    public int CoverMessageId { get; set; }

    public int? EmptyCoverMessageId { get; set; }

    public long FromChatId { get; set; }

    [StringLength(128)]
    public string YtLink { get; set; } = null!;

    [StringLength(128)]
    public string? SyLink { get; set; }

    [StringLength(128)]
    public string? KaraokeLink { get; set; }

    public string? Lyrics { get; set; }

    [ForeignKey("AlbumId")]
    [InverseProperty("TblSongs")]
    public virtual TblAlbum Album { get; set; } = null!;

    [InverseProperty("Song")]
    public virtual ICollection<TblHeavyText> TblHeavyTexts { get; set; } = new List<TblHeavyText>();

    [InverseProperty("Song")]
    public virtual ICollection<TblMusicVideo> TblMusicVideos { get; set; } = new List<TblMusicVideo>();
}
