using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot5.Models;
using TelegramBot5.Models.ViewModels;

namespace TelegramBot5
{
    public class TelegramPropertys
    {


        public static KeyboardButton[][] HomeKeyboard = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "صفحه اصلی"),
            },
        };
        public static ReplyKeyboardMarkup Home = new ReplyKeyboardMarkup(HomeKeyboard)
        {
            ResizeKeyboard = true,
        };
        
        public static KeyboardButton[][] BackKeyboard = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "بازگشت"),
            },
        };
        public static ReplyKeyboardMarkup Back = new ReplyKeyboardMarkup(BackKeyboard)
        {
            ResizeKeyboard = true,
        };
        public static KeyboardButton[][] NextKeyboard = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "بازگشت"),
                new KeyboardButton(text: "بعدی"),
            },
        };
        public static ReplyKeyboardMarkup Next = new ReplyKeyboardMarkup(NextKeyboard)
        {
            ResizeKeyboard = true,
        };
        public static KeyboardButton[][] Adminkeyboardbutton = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton (text: "🖼 آلبوم ها"),
                new KeyboardButton(text: "🔍 جستوجوی آهنگ"),
                new KeyboardButton(text: "🦹🏻‍♂ فری استایل")
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "💳 پرداخت حق موزیک"),
                new KeyboardButton(text: "🎬 موزیک ویدئو ها"),
                new KeyboardButton(text: "📝 صحبت های امیر تتلو"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "⌛️ گیف ها"),
                new KeyboardButton(text: "🎥 ویدئو ها"),
                new KeyboardButton(text: "🏞 عکس ها"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "👨‍🎤 سخن سلطان"),
                new KeyboardButton(text: "🎭 معنی تتو ها"),
                new KeyboardButton(text: "🎫 خرید بلیط"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "🌿 صحبت های گیاه خواری"),
                new KeyboardButton(text: "بخش ادمین 🤴🏻"),
            }
        };
        public static KeyboardButton[][] AdminSection = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "ارسال پیام همگانی ✉️"),
                new KeyboardButton(text: "مدیریت آهنگ ها"),
                new KeyboardButton(text: "مدیریت قفل چنل"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "مدیریت دسترسی کاربران"),
                new KeyboardButton(text: "مدیریت ادمین ها"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "گیف ➕"),
                new KeyboardButton(text: "عکس ➕"),
                new KeyboardButton(text: "آلبوم ➕")
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "معنی تتو ➕"),
                new KeyboardButton(text: "صحبت ➕"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "صحبت گیاه خواری ➕"),
                new KeyboardButton(text: "سخن ➕"),
                new KeyboardButton(text: "فری استایل ➕")
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "ویدیو ➕"),
                new KeyboardButton(text: "موزیک ویدیو ➕"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton("صفحه اصلی")
            },
        };
        public static KeyboardButton[][] ManageChannelKeyboard = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "اضافه کردن کانال"),
                new KeyboardButton(text: "حذف کانال"),
            },
        };
        public static KeyboardButton[][] keyboardbutton = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton (text: "🖼 آلبوم ها"),
                new KeyboardButton(text: "🎥 ویدئو ها"),
                new KeyboardButton(text: "🔍 جستوجوی آهنگ"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "🦹🏻‍♂ فری استایل"),
                new KeyboardButton(text: "🎬 موزیک ویدئو ها"),
                new KeyboardButton(text: "📝 صحبت های امیر تتلو"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "🏞 عکس ها"),
                new KeyboardButton(text: "💳 پرداخت حق موزیک"),
                new KeyboardButton(text: "👨‍🎤 سخن سلطان"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "🎭 معنی تتو ها"),
                new KeyboardButton(text: "🌿 صحبت های گیاه خواری"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "☎️ پشتیبانی"),
                new KeyboardButton(text: "⌛️ گیف ها"),
                new KeyboardButton(text: "🎫 خرید بلیط")
            },

        };
        public static KeyboardButton[][] Confirm = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "بله"),
                new KeyboardButton(text: "انصراف")
            },
        };
        public static KeyboardButton[][] EditSongOptions = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "نام فارسی آهنگ"),
                new KeyboardButton(text: "متن آهنگ"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "کاور خام"),
                new KeyboardButton(text: "لینک کارائوکه"),
            }
        };
        public static ReplyKeyboardMarkup EditSong = new ReplyKeyboardMarkup(EditSongOptions) { ResizeKeyboard = true};
        public static KeyboardButton[][] SongInfoKey = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "کاور آهنگ"),
                new KeyboardButton(text: "متن آهنگ"),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(text: "بازگشت"),
            },
        };
        public static KeyboardButton[][] SongInfoKeyNoLyrics = new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(text: "بازگشت"),
                new KeyboardButton(text: "کاور آهنگ"),
            },
        };
        public static ReplyKeyboardMarkup SongInfo = new ReplyKeyboardMarkup(SongInfoKey) { ResizeKeyboard = true };
        public static ReplyKeyboardMarkup SongInfoNoLyrics = new ReplyKeyboardMarkup(SongInfoKeyNoLyrics) { ResizeKeyboard = true };
        public static KeyboardButton[][] DeleteConfirm = new KeyboardButton[][]
        {
                new KeyboardButton[]
                {
                    new KeyboardButton(text: "حذف")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton(text: "انصراف")
                },
        };
        public static ReplyKeyboardRemove replyMarkupRemove = new ReplyKeyboardRemove();




        internal IEnumerable<IEnumerable<InlineKeyboardButton>> BotButtonsToKeyboardButtons(List<List<TblJoinRequiredChannel>> botButtonInfos)
        {
            List<List<InlineKeyboardButton>> keyboardButtons = new List<List<InlineKeyboardButton>>();

            foreach (List<TblJoinRequiredChannel> columns in botButtonInfos)
            {
                List<InlineKeyboardButton> rows = new List<InlineKeyboardButton>();
                foreach (TblJoinRequiredChannel row in columns)
                {
                    rows.Add(item: new InlineKeyboardButton(row.Name)
                    {
                        Text = row.Name,
                        Url = row.ChannelLink
                    });
                }
                keyboardButtons.Add(rows);
            }
            return keyboardButtons;
        }
    }
}
