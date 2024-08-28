using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmFreeStyles
    {

        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int VideoMessageId { get; set; }
        public bool? TimeToPublic { get; set; }
        public VmFreeStyles()
        {
            
        }
        public VmFreeStyles(int id, long fromChatId, int videoMessageId, bool timeToPublic)
        {
            Id = id;
            FromChatId = fromChatId;
            VideoMessageId = videoMessageId;
            TimeToPublic = timeToPublic;
        }
        public VmFreeStyles(TblFreeStyle freeStyle)
        {
            Id = freeStyle.Id;
            FromChatId = freeStyle.FromChatId;
            VideoMessageId = freeStyle.VideoMessageId;
            TimeToPublic = freeStyle.TimeToPublic;
        }
    }
}
