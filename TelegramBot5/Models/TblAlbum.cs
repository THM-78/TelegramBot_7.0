using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblAlbum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    public long? FromChatId { get; set; }

    public int? CoverMessageId { get; set; }

    [InverseProperty("Album")]
    public virtual ICollection<TblSong> TblSongs { get; set; } = new List<TblSong>();
}
