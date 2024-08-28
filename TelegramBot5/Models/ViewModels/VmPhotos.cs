using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmPhotos
    {
        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int PhotoMessageId { get; set; }
        public bool? IsNew { get; set; }
        public VmPhotos()
        {

        }

        public VmPhotos(int id, long fromChatId, int photoMessageId, bool isNew)
        {
            this.Id = id;
            FromChatId = fromChatId;
            PhotoMessageId = photoMessageId;
            IsNew = isNew;
        }
        public VmPhotos(TblPhoto photo)
        {
            Id = photo.Id;
            FromChatId = photo.FromChatId;
            PhotoMessageId = photo.PhotoMessageId;
            IsNew = photo.IsNew;
        }
    }
}
