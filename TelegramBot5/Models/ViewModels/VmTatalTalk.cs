using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmTatalTalk
    {
        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int PhotoMessageId { get; set; }
        public bool? IsNew { get; set; }
        public VmTatalTalk()
        {

        }

        public VmTatalTalk(int id, long fromChatId, int photoMessageId, bool isNew)
        {
            this.Id = id;
            FromChatId = fromChatId;
            PhotoMessageId = photoMessageId;
            IsNew = isNew;
        }

        public VmTatalTalk(TblTalksOfTataloo Talk)
        {
            Id = Talk.Id;
            FromChatId = Talk.FromChatId;
            PhotoMessageId = Talk.PhotoMessageId;
            IsNew = Talk.IsNew;
        }
    }
}
