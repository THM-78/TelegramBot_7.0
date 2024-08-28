using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmVideos
    {
        public int id { get; set; }
        public long FromChatId { get; set; }
        public int VideoMessageId { get; set; }
        public string Caption { get; set; }
        public int CategoryId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public VmVideos()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public VmVideos(int id, long fromChatId, int videoMessageId, string caption, int categoryId)
        {
            this.id = id;
            FromChatId = fromChatId;
            VideoMessageId = videoMessageId;
            Caption = caption;
            CategoryId = categoryId;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public VmVideos(TblVideo video)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            id = video.Id;
            FromChatId = video.FromChatId;
            VideoMessageId = video.VideoMessageId;
            Caption = video.Caption;
            CategoryId = video.CategoryId;
        }
    }
}
