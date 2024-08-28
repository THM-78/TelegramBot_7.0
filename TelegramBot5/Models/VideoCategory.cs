using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

[Table("VideoCategory")]
public partial class VideoCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<TblVideo> TblVideos { get; set; } = new List<TblVideo>();
}
