using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

[Table("TblVegetarianTalk")]
public partial class TblVegetarianTalk
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public long FromChatId { get; set; }

    public int VideoMessageId { get; set; }

    [StringLength(1024)]
    public string? VideoCaption { get; set; }
}
