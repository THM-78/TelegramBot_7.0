using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblGif
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public long FromChatId { get; set; }

    public int GifMessageId { get; set; }
}
