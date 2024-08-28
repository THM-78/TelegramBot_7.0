using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblTattooMean
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; } = null!;

    public long FromChatId { get; set; }

    public int TattooMeanMessageId { get; set; }

    [StringLength(1024)]
    public string Explanation { get; set; } = null!;
}
