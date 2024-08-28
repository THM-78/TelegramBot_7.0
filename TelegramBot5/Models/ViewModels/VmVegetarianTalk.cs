using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot5.Models.ViewModels
{
    internal class VmVegetarianTalk
    {
        public int Id { get; set; }
        public long FromChatId { get; set; }
        public int VideoMessageId { get; set; }
        public string? VideoCaption { get; set; }
        public VmVegetarianTalk()
        {
            
        }
        public VmVegetarianTalk(int id, long fromChatId, int videoMessageId, string? videoCaption)
        {
            Id = id;
            FromChatId = fromChatId;
            VideoMessageId = videoMessageId;
            VideoCaption = videoCaption;
        }
        public VmVegetarianTalk(TblVegetarianTalk vegetarianTalk)
        {
            Id = vegetarianTalk.Id;
            FromChatId = vegetarianTalk.FromChatId;
            VideoMessageId = vegetarianTalk.VideoMessageId;
            if(string.IsNullOrEmpty(vegetarianTalk.VideoCaption) == false)
            {
                VideoCaption = vegetarianTalk.VideoCaption;
            }
            else
            {
                VideoCaption = null;
            }
        }

    }
}
