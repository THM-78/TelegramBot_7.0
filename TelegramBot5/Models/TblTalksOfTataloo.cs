using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

[Table("TblTalksOfTataloo")]
public partial class TblTalksOfTataloo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public long FromChatId { get; set; }

    public int PhotoMessageId { get; set; }

    [Required]
    public bool? IsNew { get; set; }
}
