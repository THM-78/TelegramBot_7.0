using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmSokhan
    {
        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int HeavyTextMessageId { get; set; }
        public string? SongName { get; set; }
        public VmSokhan()
        {
            
        }
        public VmSokhan(int id, long fromChatId, int heavyTextMessageId, string songName)
        {
            Id = id;
            FromChatId = fromChatId;
            HeavyTextMessageId = heavyTextMessageId;
            SongName = songName;
        }
        public VmSokhan(TblHeavyText heavyText)
        {
            Id = heavyText.Id;
            FromChatId = heavyText.FromChatId;
            HeavyTextMessageId = heavyText.HeavyTextMessageId;
            if(heavyText.SongId is not null or 0)
            {
                SongName = heavyText.Song.Name;
            }
            else
            {
                SongName = null;
            }
        }


    }
}
