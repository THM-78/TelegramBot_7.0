using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmGifs
    {
        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int GifMessageId { get; set; }
        public VmGifs()
        {
            
        }

        public VmGifs(int id, long fromChatId, int gifMessageId)
        {
            Id = id;
            FromChatId = fromChatId;
            GifMessageId = gifMessageId;
        }
        public VmGifs(TblGif gif)
        {
            Id = gif.Id;
            FromChatId = gif.FromChatId;
            GifMessageId = gif.GifMessageId;
        }
    }
}
