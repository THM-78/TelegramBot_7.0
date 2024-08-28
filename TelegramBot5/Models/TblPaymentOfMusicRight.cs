using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TblPaymentOfMusicRight
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public string Text { get; set; } = null!;
}
