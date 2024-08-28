using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot5.Models;
using TelegramBot5.Models.ViewModels;
using static TelegramBot5.Propertys;
using static TelegramBot5.TelegramPropertys;


var bot = new TelegramBotClient("6281159464:AAEbHar0SSrSACS--hE2iYzmuOtw28rXZnc");//6597499528:AAH6bd0WdjMR4TjxHHylsJoPmavSJNLYewA  //6281159464:AAEbHar0SSrSACS--hE2iYzmuOtw28rXZnc
TatalooBotContext context = new TatalooBotContext();
using CancellationTokenSource cts = new();
List<VmPhotos> vmPhotos = new List<VmPhotos>();
List<VmVideos> vmVideos = new List<VmVideos>();
List<VmGifs> vmGifs = new List<VmGifs>();
List<VmFreeStyles> vmFreeStyles = new List<VmFreeStyles>();
List<VmSokhan> vmSokhans = new List<VmSokhan>();
List<VmVegetarianTalk> vmVegetarianTalks = new List<VmVegetarianTalk>();
List<VmTatalTalk> VmTalks = new List<VmTatalTalk>();
List<Message> Last50Message = new List<Message>();

Console.WriteLine("WriteConnectionString");
context.MyConnectionString = Console.ReadLine();
Console.WriteLine("Succeeded");


//Telegram.Bot.Exceptions.RequestException
//..............................
static void ManageUsersAccess(long id, string message, ITelegramBotClient bot)
{
    List<List<KeyboardButton>> WithBack = new List<List<KeyboardButton>>();
    List<KeyboardButton> ManageUsers = new List<KeyboardButton>();
    List<KeyboardButton> Back = new List<KeyboardButton>();
    ReplyKeyboardMarkup ManageUsersAccess = new ReplyKeyboardMarkup(WithBack) { ResizeKeyboard = true };
    if (ShowAudioFileToUsers && ShowVideoFilesToUsers)
    {
        ManageUsers.Add("غیر فعال نمایان شدن ویدیو ها");
        ManageUsers.Add("غیر فعال نمایان شدن فایل آهنگ ها");
    }
    else if (ShowAudioFileToUsers && ShowVideoFilesToUsers == false)
    {
        ManageUsers.Add("فعال نمایان شدن ویدیو ها");
        ManageUsers.Add("غیر فعال نمایان شدن فایل آهنگ ها");
    }
    else if (ShowAudioFileToUsers == false && ShowVideoFilesToUsers)
    {
        ManageUsers.Add("غیر فعال نمایان شدن ویدیو ها");
        ManageUsers.Add("فعال نمایان شدن فایل آهنگ ها");
    }
    else if (ShowAudioFileToUsers == false && ShowVideoFilesToUsers == false)
    {
        ManageUsers.Add("فعال نمایان شدن ویدیو ها");
        ManageUsers.Add("فعال نمایان شدن فایل آهنگ ها");
    }
    Back.Add("بازگشت");
    WithBack.Add(ManageUsers);
    WithBack.Add(Back);
    bot.SendTextMessageAsync(id, message, replyMarkup: ManageUsersAccess);
}
static void AddNewToVmPhoto(List<VmPhotos> vmPhotos, TatalooBotContext context)
{
    List<TblPhoto> Photos = context.TblPhotos.Where(i => i.IsNew == true).ToList();
    vmPhotos.Clear();
    foreach (TblPhoto i in Photos)
    {
        VmPhotos VmToAdd = new VmPhotos(i);
        vmPhotos.Add(VmToAdd);
    }

}
static void AddOldToVmPhoto(List<VmPhotos> vmPhotos, TatalooBotContext context)
{
    List<TblPhoto> Photos = context.TblPhotos.Where(i => i.IsNew == false).ToList();
    vmPhotos.Clear();
    foreach (TblPhoto i in Photos)
    {
        VmPhotos VmToAdd = new VmPhotos(i);
        vmPhotos.Add(VmToAdd);
    }

}

static void AddOldToVmTatalTalk(List<VmTatalTalk> VmTalks, TatalooBotContext context)
{
    List<TblTalksOfTataloo> Talks = context.TblTalksOfTataloos.Where(i => i.IsNew == false).ToList();
    VmTalks.Clear();
    foreach(TblTalksOfTataloo i in Talks)
    {
        VmTatalTalk VmToAdd = new VmTatalTalk(i);
        VmTalks.Add(VmToAdd);
    }
}
static void AddNewToVmTatalTalk(List<VmTatalTalk> VmTalks, TatalooBotContext context)
{
    List<TblTalksOfTataloo> Talks = context.TblTalksOfTataloos.Where(i => i.IsNew == true).ToList();
    VmTalks.Clear();
    foreach (TblTalksOfTataloo i in Talks)
    {
        VmTatalTalk VmToAdd = new VmTatalTalk(i);
        VmTalks.Add(VmToAdd);
    }
}
static void AddToVmVideo(int CategoryId, List<VmVideos> vmVideos, TatalooBotContext context)
{
    List<TblVideo> videos = context.TblVideos.Where(i => i.CategoryId == CategoryId).ToList();
    vmVideos.Clear();
    foreach (TblVideo i in videos)
    {
        VmVideos VmToAdd = new VmVideos(i);
        vmVideos.Add(VmToAdd);
    }

}
static void AddToVmGifs(List<VmGifs> vmGifs, TatalooBotContext context)
{
    List<TblGif> Allgifs = context.TblGifs.ToList();
    vmGifs.Clear();
    foreach(TblGif i in Allgifs)
    {
        VmGifs VmToAdd = new(i);
        vmGifs.Add(VmToAdd);
    }
}
static void AddNewToVmFreestyle(List<VmFreeStyles> vmFreestyles, TatalooBotContext context)
{
    List<TblFreeStyle> AllfreeStyles = context.TblFreeStyles.Where(i => i.TimeToPublic == true).ToList();
    vmFreestyles.Clear();
    foreach(TblFreeStyle i in AllfreeStyles)
    {
        VmFreeStyles VmToAdd = new(i);
        vmFreestyles.Add(VmToAdd);
    }
}
static void AddOldToVmFreestyle(List<VmFreeStyles> vmFreestyles, TatalooBotContext context)
{
    List<TblFreeStyle> AllfreeStyles = context.TblFreeStyles.Where(i => i.TimeToPublic == false).ToList();
    vmFreestyles.Clear();
    foreach (TblFreeStyle i in AllfreeStyles)
    {
        VmFreeStyles VmToAdd = new(i);
        vmFreestyles.Add(VmToAdd);
    }
}
static void AddToVmSokhan(List<VmSokhan> vmHeavySokhan, TatalooBotContext context)
{
    List<TblHeavyText> AllHeavyText = context.TblHeavyTexts.ToList();
    vmHeavySokhan.Clear();
    foreach(TblHeavyText i in AllHeavyText)
    {
        VmSokhan VmToAdd = new(i);
        vmHeavySokhan.Add(VmToAdd);
    }
}

static void AddToVmVegetarianTalks(List<VmVegetarianTalk> vmVegetarianTalks, TatalooBotContext context)
{
    List<TblVegetarianTalk> AllTalks = context.TblVegetarianTalks.ToList();
    vmVegetarianTalks.Clear();
    foreach(TblVegetarianTalk i in AllTalks)
    {
        VmVegetarianTalk VmToAdd = new(i);
        vmVegetarianTalks.Add(VmToAdd);
    }
}
//..............................

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>(), // receive all update types except ChatMember related updates
};
bot.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);


bot.Timeout = TimeSpan.FromMinutes(5);
var me = await bot.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
{
    if(update.Message is not null)
    {
        Last50Message?.Add(update.Message);

        if (Last50Message?.Count > 50)
        {
            Last50Message.RemoveAt(0);
        }
        try
        {
            List<string> Albums = new List<string>();
            List<TblJoinRequiredChannel> tblJoinRequireds = context.TblJoinRequiredChannels.ToList();
            List<TblSong> Songs = context.TblSongs.ToList();
            List<TblHeavyText> heavyTexts = context.TblHeavyTexts.ToList();
            List<List<TblTattooMean>> Tattoos = new List<List<TblTattooMean>>();
            List<TblTattooMean> Tattoo = context.TblTattooMeans.ToList();
            List<TblMusicVideo> MusicVideos = context.TblMusicVideos.ToList();
            List<TblBotAdmin> Admins = context.TblBotAdmins.ToList();
            List<TblAdminRol> adminRols = context.TblAdminRols.ToList();
            List<TblGif> gifs = context.TblGifs.ToList();
            List<TblBotUser> botUsers = context.TblBotUsers.ToList();
            List<string> JoinedChannels = new List<string>();
            var message = update.Message;
            string text = "";
            long id = update.Message.Chat.Id;
            if (message is not null && message.Text != null)
            {
                text = message.Text;
            }
            User botUser = await bot.GetMeAsync();
            string botUsername = botUser.Username;

            ChatMember chatMember;
            TblAlbum SelectedAlbum = context.TblAlbums.SingleOrDefault(i => i.Name == text);

            List<List<InlineKeyboardButton>> inlinekey = new List<List<InlineKeyboardButton>>();
            List<KeyboardButton> ChannelsRequird = new List<KeyboardButton>();
            foreach (TblJoinRequiredChannel i in tblJoinRequireds)
            {
                List<InlineKeyboardButton> inlines = new List<InlineKeyboardButton>();
                inlines.Add(new InlineKeyboardButton(i.Name)
                {
                    Text = i.Name,
                    Url = i.ChannelLink
                });
                inlinekey.Add(inlines);
                ChannelsRequird.Add(i.Name);
                chatMember = await bot.GetChatMemberAsync(i.ChannelId, userId: id, cancellationToken: cancellationToken);
                if (chatMember.Status is ChatMemberStatus.Member or ChatMemberStatus.Administrator or ChatMemberStatus.Creator)
                {
                    JoinedChannels.Add(i.Name);
                }
            }
            List<InlineKeyboardButton> ChannelRequird = new List<InlineKeyboardButton>();
            ChannelRequird.Add(new InlineKeyboardButton("عضو شدم")
            {
                Text = "عضو شدم",
                CallbackData = "عضو شدم"
            });
            inlinekey.Add(ChannelRequird);

            if (message.Type == MessageType.Text)
            {
                //جدا کردن لینک از متن پیام

                //if(e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                //{
                //    string urlPattern = @"(https?://[^\s]+)";
                //    Regex regex = new Regex(urlPattern);
                //    if (regex.IsMatch(text))
                //    {
                //        MatchCollection matches = regex.Matches(text);
                //        foreach (Match match in matches)
                //        {
                //            string url = match.Value;
                //            Console.WriteLine("URL detected: " + url);
                //        }
                //    }
                //}


                /// member_count
                if (text == "/start")
                {
                    Bott();
                    textm = "/start";
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                    if (context.TblBotUsers.SingleOrDefault(i => i.ChatId == id) == null && context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) == null)
                    {
                        TblBotUser UserToAdd = new TblBotUser();
                        UserToAdd.ChatId = id;
                        context.TblBotUsers.Add(UserToAdd);
                        context.SaveChanges();
                    }
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {
                            ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                            await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: AdminKeyboard);

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                    else
                    {
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {
                            ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(keyboardbutton);
                            await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: keyboardMarkup);

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                    //int chatMember = await bot.GetChatMemberCountAsync(-979113119);
                    //await bot.SendTextMessageAsync(chatId:-979113119,text:chatMember.ToString());   
                }
                if (text == "صفحه اصلی")
                {
                    Bott();
                    textm = "صفحه اصلی";
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: AdminKeyboard);
                    }
                    else
                    {
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {
                            ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(keyboardbutton);
                            await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: keyboardMarkup);

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                    //int chatMember = await bot.GetChatMembersCountAsync(-979113119);
                    //await bot.SendTextMessageAsync(chatId:-979113119,text:chatMember.ToString()); 
                }
                if (text == "بازگشت")
                {
                    if (GoToAdmin)
                    {
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                        {
                            ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(AdminSection);
                            await bot.SendTextMessageAsync(id, "AdminSection", replyMarkup: AdminKeyboard);
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است");
                            Bott();
                        }
                    }
                    else if (BackToAlbumMenu)
                    {
                        Bott();
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {

                            textm = "🖼 آلبوم ها";
                            List<List<KeyboardButton>> albumButton = new List<List<KeyboardButton>>();
                            GenerateAlbumsBtn(albumButton, context);
                            if (RowOneisZero)
                            {
                                await bot.SendTextMessageAsync(id, "آلبومی وجود ندارد", replyMarkup: Back);
                                Bott();
                            }
                            else
                            {
                                ReplyKeyboardMarkup AlbumkeyboardMarkup = new ReplyKeyboardMarkup(albumButton);
                                await bot.SendTextMessageAsync(id, "آلبوم مورد نظر را انتخاب کنید\n برای بازگشت به منو اصلی ، `بازگشت` را ارسال کنید", parseMode: ParseMode.MarkdownV2, replyMarkup: AlbumkeyboardMarkup);
                                Albums1 = true;
                            }

                            //int chatMember = await bot.GetChatMembersCountAsync(-979113119);
                            //await bot.SendTextMessageAsync(chatId:-979113119,text:chatMember.ToString());   
                        }
                        else
                        {
                            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                    else
                    {
                        Bott();
                        textm = "صفحه اصلی";
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                        {
                            ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                            await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: AdminKeyboard);
                        }
                        else
                        {
                            if (JoinedChannels.Count == tblJoinRequireds.Count)
                            {
                                ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(keyboardbutton);
                                await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: keyboardMarkup);

                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, $"برای استفاده از ربات در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                            }
                        }
                    }
                }
                if (text == "🎬 موزیک ویدئو ها")
                {
                    Bott();
                    List<List<KeyboardButton>> buttons = new List<List<KeyboardButton>>();
                    GenerateMusicVideoBtn(buttons, context);
                    ReplyKeyboardMarkup MusicVideosBtn = new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
                    await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: MusicVideosBtn);
                    MusicVideos1 = true;
                }
                if (MusicVideos1 && text != "🎬 موزیک ویدئو ها")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        //if (text == "بعدی")
                        //{
                        //    List<List<KeyboardButton>> buttons = new List<List<KeyboardButton>>();
                        //    GenerateMusicVideoBtn(buttons, MusicVideos, forTattoobut, forTattoobut2);
                        //    ReplyKeyboardMarkup MusicVideosBtn = new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
                        //    await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: MusicVideosBtn);
                        //}
                        if (context.TblMusicVideos.SingleOrDefault(i => i.Song.Name == text) != null)
                        {
                            TblMusicVideo video = context.TblMusicVideos.SingleOrDefault(i => i.Song.Name == text);
                            if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                            {
                                await bot.CopyMessageAsync(id, video.FromChatId, video.VideoMessageId);
                            }
                            else
                            {
                                if (ShowVideoFilesToUsers)
                                {
                                    await bot.CopyMessageAsync(id, video.FromChatId, video.VideoMessageId);
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, $"{video.Caption}");
                                }
                            }
                        }
                        else if(text == "بازگشت")
                        {
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "💳 پرداخت حق موزیک")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        TblPaymentOfMusicRight PaymentOfMusic = context.TblPaymentOfMusicRights.SingleOrDefault(i => i.Id == 1);
                        await bot.SendTextMessageAsync(id, PaymentOfMusic.Text, replyMarkup: Back);
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"برای استفاده از ربات در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                    Bott();
                }
                if (text == "🎫 خرید بلیط")
                {
                    await bot.SendTextMessageAsync(id, "فعلا این بخش در حال آماده سازی هستش !!");
                    Bott();
                }
                if (text == "بخش ادمین 🤴🏻")
                {
                    Bott();
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(AdminSection);
                        await bot.SendTextMessageAsync(id, "AdminSection", replyMarkup: AdminKeyboard);
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است");
                    }
                }
                if (text == "آلبوم ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddAlbumTxtName = "نام آلبوم را ارسال کنید (انگلیسی)";
                        await bot.SendTextMessageAsync(id, AddAlbumTxtName, replyMarkup: replyMarkupRemove);
                        AddAlbum2 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است");
                    }
                }
                if (AddAlbum2 && text != "آلبوم ➕" && text != "بعدی")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddAlbumName = CapitalizeWords(text);
                        AddAlbumTxtCover = "عکس کاور آلبوم را ارسال کنید (اختیاری) \n برای رد شدن روی /skip کلیک کنید";
                        await bot.SendTextMessageAsync(id, AddAlbumTxtCover);
                        AddAlbum2 = false;
                        AddAlbum3 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddAlbum2 = false;
                        AddAlbum3 = false;
                    }
                }
                if (text == "🔍 جستوجوی آهنگ")
                {
                    Bott();
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        var messageText = "برای جستجوی آهنگ مورد نظر از متود زیر استفاده کنید:\n `/search`نام آهنگ مورد نظر \n Example : /search Boht";
                        await bot.SendTextMessageAsync(id, messageText, parseMode: ParseMode.MarkdownV2, replyMarkup: Back);
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text.StartsWith("/search") && CanSendSongInfo == false)
                {
                    AddSongName = "";
                    AddSongPersianName = "";
                    AddSongArtist = "";
                    AddSongYtLink = "";
                    AddSongSyLink = null;
                    AddSongAlbumName = "";
                    textm = text.ToString();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        string song = "";
                        try
                        {
                            song = text.Substring(8);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        if (song.Length > 1)
                        {
                            TblSong tblSong = context.TblSongs.SingleOrDefault(i => i.Name.Contains(song) || i.PersianName.Contains(song));
                            if (tblSong != null)
                            {
                                SongId = tblSong.Id;
                                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null || ShowAudioFileToUsers)
                                {
                                    await bot.CopyMessageAsync(id, tblSong.FromChatId, tblSong.SongMessageId, caption: "");
                                    if (tblSong.SyLink == null)
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                    else
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                }
                                else
                                {
                                    if (tblSong.SyLink == null)
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                    else
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                }
                                CanSendSongInfo = true;
                            }
                            else
                            {
                                if (tblSong == null)
                                {
                                    await bot.SendTextMessageAsync(id, "اسم آهنگ را به درستی وارد کنید");
                                }
                            }
                        }
                        else
                        {
                            if (song == "")
                            {
                                await bot.SendTextMessageAsync(id, "بعد کلمه /search فاصله دهید و سپس نام آهنگ مورد نظر را وارد کنید");
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "آهنگی با این اسم در کارنامه امیر تتلو وجود ندارد");
                            }
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "🖼 آلبوم ها")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {

                        textm = "🖼 آلبوم ها";
                        List<List<KeyboardButton>> albumButton = new List<List<KeyboardButton>>();
                        GenerateAlbumsBtn(albumButton, context);
                        if (RowOneisZero)
                        {
                            await bot.SendTextMessageAsync(id, "آلبومی وجود ندارد", replyMarkup: Back);
                            Bott();
                        }
                        else
                        {
                            ReplyKeyboardMarkup AlbumkeyboardMarkup = new ReplyKeyboardMarkup(albumButton);
                            await bot.SendTextMessageAsync(id, "آلبوم مورد نظر را انتخاب کنید\n برای بازگشت به منو اصلی ، `بازگشت` را ارسال کنید", parseMode: ParseMode.MarkdownV2, replyMarkup: AlbumkeyboardMarkup);
                            Albums1 = true;
                        }

                        //int chatMember = await bot.GetChatMembersCountAsync(-979113119);
                        //await bot.SendTextMessageAsync(chatId:-979113119,text:chatMember.ToString());   
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }

                if (Albums1 && SelectedAlbum != null)
                {
                    SelectedAlbumName = text;
                    int albumId = context.TblAlbums.SingleOrDefault(i => i.Name == SelectedAlbumName).Id;
                    TblAlbum AlbumToSend = context.TblAlbums.SingleOrDefault(i => i.Id == albumId);
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        List<List<KeyboardButton>> AlbumSongsButton = new List<List<KeyboardButton>>();
                        ReplyKeyboardMarkup inlineAlbumSongsKeyboard = new ReplyKeyboardMarkup(AlbumSongsButton) { ResizeKeyboard = true };
                        List<TblSong> songss = context.TblSongs.Where(i => i.AlbumId == albumId).ToList();
                        GenerateSongBtn(AlbumSongsButton, songss);
                        if (AlbumToSend.CoverMessageId is null)
                        {
                            await bot.SendTextMessageAsync(id, $"{SelectedAlbum.Name} Album", replyMarkup: inlineAlbumSongsKeyboard);
                        }
                        else
                        {
                            await bot.CopyMessageAsync(id, AlbumToSend.FromChatId, (int)AlbumToSend.CoverMessageId, caption: $"{SelectedAlbum.Name} Album", replyMarkup: inlineAlbumSongsKeyboard);
                        }

                        if (Songs.SingleOrDefault(i => i.Name == SelectedAlbumName) != null)
                        {
                            AlbumsNameEqualsSongName = true;
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                    Albums1 = false;
                    Albums2 = true;
                    BackToAlbumMenu = true;
                }
                if (Albums2 && context.TblSongs.SingleOrDefault(i => i.Name == text) is not null)
                {
                    TblSong tblSong = context.TblSongs.SingleOrDefault(i => i.Name == text);
                    SongId = tblSong.Id;
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (AlbumsNameEqualsSongName)
                        {
                            AlbumsNameEqualsSongName = false;
                        }
                        else
                        {
                            if (tblSong?.Album.Name == SelectedAlbumName)
                            {
                                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null || ShowAudioFileToUsers)
                                {
                                    await bot.CopyMessageAsync(id, tblSong.FromChatId, tblSong.SongMessageId, caption: "");
                                    if (tblSong.SyLink == null)
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                    else
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                }
                                else
                                {
                                    if (tblSong?.SyLink == null)
                                    {
                                        if (tblSong?.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                    else
                                    {
                                        if (tblSong.Lyrics != null)
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                        }
                                        else
                                        {
                                            await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                        }
                                    }
                                }
                                CanSendSongInfo = true;
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Back);
                                Bott();

                            }
                            Albums2 = false;
                        }
                        BackToAlbumMenu = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        Bott();
                    }
                }
                if (CanSendSongInfo && SongId != 0 && text.StartsWith("/search") == false && context.TblSongs.SingleOrDefault(i => i.Name == text) == null)
                {
                    TblSong song = context.TblSongs.SingleOrDefault(i => i.Id == SongId);
                    if (text == "کاور آهنگ")
                    {
                        await bot.CopyMessageAsync(id, song.FromChatId, song.CoverMessageId);
                        if (song.EmptyCoverMessageId != null)
                        {
                            await bot.CopyMessageAsync(id, song.FromChatId, Convert.ToInt32(song.EmptyCoverMessageId), caption: "");
                        }
                    }
                    else if (text == "متن آهنگ")
                    {
                        if (song.Lyrics != null)
                        {
                            await bot.SendTextMessageAsync(id, song.Lyrics);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "متنی برای این آهنگ پیدا نشد");
                        }
                    }
                    else if (text == "بازگشت")
                    {
                        SongId = 0;
                        CanSendSongInfo = false;
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        SongId = 0;
                        CanSendSongInfo = false;
                        Bott();
                    }
                }
                if (AddSong7 && SelectedAlbum is not null)
                {
                    AddSongAlbumName = text;
                    addSongtxtCover = "کاور اصلی آهنگ را ارسال کنید";
                    await bot.SendTextMessageAsync(id, addSongtxtCover, replyMarkup: replyMarkupRemove);
                    AddSong7 = false;
                    AddSong8 = true;
                }
                if (text == "☎️ پشتیبانی")
                {
                    await bot.SendTextMessageAsync(id, "پیام خود را در قالب یک مَتن کوتاه و مختصر نوشته و برای ادمین ارسال کنید و صبر کنید پاسخ داده میشود !! از شکیبایی شما سپاسگذاریم 🙏🏻💌\n\n 🆔 @Amirzarbat", replyMarkup: Home);
                    Bott();
                }
                if (text == "🎭 معنی تتو ها")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        textm = "🎭 معنی تتو ها";
                        forTattoobut = 0;
                        forTattoobut2 = -4;
                        List<List<KeyboardButton>> buttons = new List<List<KeyboardButton>>();
                        GenerateTattooBtn(buttons, Tattoo);
                        ReplyKeyboardMarkup TattooBtn = new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: TattooBtn);
                        TattooMeans1 = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (TattooMeans1 && text != "🎭 معنی تتو ها")
                {
                    if (text == "بعدی")
                    {
                        List<List<KeyboardButton>> buttons = new List<List<KeyboardButton>>();
                        GenerateTattooBtn(buttons, Tattoo);
                        ReplyKeyboardMarkup TattooBtn = new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: TattooBtn);
                    }
                    else if (context.TblTattooMeans.SingleOrDefault(i => i.Name == text) != null)
                    {
                        TblTattooMean TattooMean = context.TblTattooMeans.SingleOrDefault(i => i.Name == text);
                        await bot.CopyMessageAsync(id, TattooMean.FromChatId, TattooMean.TattooMeanMessageId, caption: $"نام : {TattooMean.Name}\n\n{TattooMean.Explanation}");
                    }
                    else if (text == "بازگشت")
                    {
                        TattooMeans1 = false;
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        TattooMeans1 = false;
                        Bott();
                    }
                }
                if (text == "🏞 عکس ها")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        KeyboardButton[][] TimeToPublic = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "قدیمی"),
                                        new KeyboardButton(text: "جدید"),
                                    },
                        };
                        ReplyKeyboardMarkup TimeToPublicPhoto = new ReplyKeyboardMarkup(TimeToPublic) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: TimeToPublicPhoto);
                        photo1 = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "📝 صحبت های امیر تتلو")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        KeyboardButton[][] TimeToPublic = new KeyboardButton[][]
                        {
                            new KeyboardButton[]
                            {
                                new KeyboardButton(text: "قدیمی"),
                                new KeyboardButton(text: "جدید"),
                            },
                        };
                        ReplyKeyboardMarkup TimeToPublicSohbat = new ReplyKeyboardMarkup(TimeToPublic);
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: TimeToPublicSohbat);
                        TatalTalk1 = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }

                }
                if (text == "قدیمی" || text == "جدید")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (photo1)
                        {
                            Random random = new Random();
                            if (text == "قدیمی")
                            {
                                AddOldToVmPhoto(vmPhotos, context);
                                if (vmPhotos.Count >= 1)
                                {
                                    int randomIndex = random.Next(vmPhotos.Count);
                                    var Photo = vmPhotos[randomIndex];
                                    await bot.CopyMessageAsync(id, Photo.FromChatId, Photo.PhotoMessageId, caption: "", replyMarkup: Next);
                                    vmPhotos.Remove(Photo);
                                    Oldphoto = true;
                                    Newphoto = false;
                                    photo2 = true;
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "هیچ عکسی در این بخش وجود ندارد", replyMarkup: Back);
                                    photo1 = false;
                                    photo2 = false;
                                    Bott();
                                }
                            }
                            else if(text == "جدید")
                            {
                                AddNewToVmPhoto(vmPhotos, context);
                                if (vmPhotos.Count >= 1)
                                {
                                    int randomIndex = random.Next(vmPhotos.Count);
                                    var Photo = vmPhotos[randomIndex];
                                    await bot.CopyMessageAsync(id, Photo.FromChatId, Photo.PhotoMessageId, caption: "", replyMarkup: Next);
                                    vmPhotos.Remove(Photo);
                                    Oldphoto = true;
                                    Newphoto = false;
                                    photo2 = true;
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "هیچ عکسی در این بخش وجود ندارد", replyMarkup: Back);
                                    photo1 = false;
                                    photo2 = false;
                                    Bott();
                                }
                            }
                            photo1 = false;
                        }
                        if (TatalTalk1)
                        {
                            Random random = new Random();
                            if (text == "قدیمی")
                            {
                                AddOldToVmTatalTalk(VmTalks, context);
                                if(VmTalks.Count >= 1)
                                {
                                    int randomIndex = random.Next(VmTalks.Count);
                                    var Talk = VmTalks[randomIndex];
                                    await bot.CopyMessageAsync(id, Talk.FromChatId, Talk.PhotoMessageId, replyMarkup: Next);
                                    VmTalks.Remove(Talk);
                                    TatalTalk2 = true;
                                    NewTalk = false;
                                    OldlTalk = true;
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "هیچ عکسی در این بخش وجود ندارد", replyMarkup: Back);
                                    Bott();
                                }
                            }
                            else if (text == "جدید")
                            {
                                AddNewToVmTatalTalk(VmTalks, context);
                                if (VmTalks.Count >= 1)
                                {
                                    int randomIndex = random.Next(VmTalks.Count);
                                    var Talk = VmTalks[randomIndex];
                                    await bot.CopyMessageAsync(id, Talk.FromChatId, Talk.PhotoMessageId, replyMarkup: Next);
                                    VmTalks.Remove(Talk);
                                    TatalTalk2 = true;
                                    NewTalk = true;
                                    OldlTalk = false;
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "هیچ عکسی در این بخش وجود ندارد", replyMarkup: Back);
                                    Bott();
                                }
                            }
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (photo2 && text != "قدیمی" && text != "جدید")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if (vmPhotos.Count >= 1)
                            {
                                Random random = new Random();
                                if (Oldphoto || Newphoto)
                                {
                                    int randomIndex = random.Next(vmPhotos.Count);
                                    var Photo = vmPhotos[randomIndex];
                                    await bot.CopyMessageAsync(id, Photo.FromChatId, Photo.PhotoMessageId, caption: "", replyMarkup: Next);
                                    vmPhotos.Remove(Photo);
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                                    photo2 = false;
                                    Bott();
                                }
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "شما تمام عکس هارا مشاهده کردید", replyMarkup: Back);
                                photo2 = false;
                                Bott();
                            }
                        }
                        else if (text == "بازگشت")
                        {
                            Oldphoto = false;
                            Newphoto = false;
                            photo2 = false;
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if(TatalTalk2 && text != "قدیمی" && text != "جدید")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if (VmTalks.Count >= 1)
                            {
                                Random random = new Random();
                                if (OldlTalk || NewTalk)
                                {
                                    int randomIndex = random.Next(vmPhotos.Count);
                                    var Photo = vmPhotos[randomIndex];
                                    await bot.CopyMessageAsync(id, Photo.FromChatId, Photo.PhotoMessageId, caption: "", replyMarkup: Next);
                                    vmPhotos.Remove(Photo);
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                                    TatalTalk2 = false;
                                    Bott();
                                }
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "شما تمام عکس های این بخش را مشاهده کردید", replyMarkup: Back);
                                photo2 = false;
                                Bott();
                            }
                        }
                        else if (text == "بازگشت")
                        {
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "🎥 ویدئو ها")
                {
                    Bott();
                    textm = "🎥 ویدئو ها";
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        KeyboardButton[][] videoCat = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "دیگر"),
                                        new KeyboardButton(text: "لایو"),
                                        new KeyboardButton(text: "مصاحبه"),
                                    },
                        };
                        ReplyKeyboardMarkup VideoCategory = new ReplyKeyboardMarkup(videoCat) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: VideoCategory);
                        Videos1 = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (Videos1 && text != "🎥 ویدئو ها")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        Random random = new Random();
                        if (context.VideoCategories.SingleOrDefault(i => i.Name == text) != null)
                        {
                            int CategoryId = context.VideoCategories.SingleOrDefault(i => i.Name == text).Id;
                            AddToVmVideo(CategoryId, vmVideos, context);
                            if (vmVideos.Count >= 1)
                            {
                                int randomIndex = random.Next(vmVideos.Count);
                                var Video = vmVideos[randomIndex];
                                await bot.CopyMessageAsync(id, Video.FromChatId, Video.VideoMessageId, caption: $"{Video.Caption}", replyMarkup: Next);
                                vmVideos.Remove(Video);
                                Videos1 = false;
                                Videos2 = true;
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "هیچ ویدئویی در این بخش وجود ندارد", replyMarkup: Home);
                                Videos1 = false;
                                Videos2 = true;
                                Bott();

                            }

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        Videos1 = false;
                    }
                }
                if (Videos2 && context.VideoCategories.SingleOrDefault(i => i.Name == text) == null)
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if (vmVideos.Count >= 1)
                            {
                                Random random = new Random();
                                int randomIndex = random.Next(vmVideos.Count);
                                var Video = vmVideos[randomIndex];
                                await bot.CopyMessageAsync(id, Video.FromChatId, Video.VideoMessageId, caption: $"{Video.Caption}", replyMarkup: Next);
                                vmVideos.Remove(Video);
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "شما تمام ویدئو هارا مشاهده کردید", replyMarkup: Home);
                                Videos1 = false;
                                Videos2 = false;
                                Bott();
                            }
                        }
                        else if (text == "بازگشت")
                        {
                            Videos2 = false;
                            Videos1 = false;
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "🦹🏻‍♂ فری استایل")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        KeyboardButton[][] TimeToPublic = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "قدیمی"),
                                        new KeyboardButton(text: "جدید"),
                                    },
                        };
                        ReplyKeyboardMarkup TimeToPublicPhoto = new ReplyKeyboardMarkup(TimeToPublic) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: TimeToPublicPhoto);
                        FreeStyle1 = true;
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (FreeStyle1 && text != "🦹🏻‍♂ فری استایل")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "قدیمی")
                        {
                            AddOldToVmFreestyle(vmFreeStyles, context);
                            Random random = new Random();
                            if (vmFreeStyles.Count >= 1)
                            {
                                int randomIndex = random.Next(vmFreeStyles.Count);
                                VmFreeStyles freeStyle = vmFreeStyles[randomIndex];
                                await bot.CopyMessageAsync(id, freeStyle.FromChatId, freeStyle.VideoMessageId, replyMarkup: Next);
                                await bot.SendTextMessageAsync(id, "برای دیدن فری استایل های بیشتر روی <بعدی> کلیک کنید");
                                FreeStyle2 = true;
                                OldFreeStyle = true;
                                vmFreeStyles.Remove(freeStyle);
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "در این بخش هیچ فری استایلی قرار داده نشده", replyMarkup: Back);
                            }
                            FreeStyle1 = false;
                        }
                        else if (text == "جدید")
                        {
                            AddNewToVmFreestyle(vmFreeStyles, context);
                            Random random = new Random();
                            if (vmFreeStyles.Count >= 1)
                            {
                                int randomIndex = random.Next(vmFreeStyles.Count);
                                VmFreeStyles freeStyle = vmFreeStyles[randomIndex];
                                await bot.CopyMessageAsync(id, freeStyle.FromChatId, freeStyle.VideoMessageId, replyMarkup: Next);
                                await bot.SendTextMessageAsync(id, "برای دیدن فری استایل های بیشتر روی <بعدی> کلیک کنید");
                                NewFreeStyle = true;
                                FreeStyle2 = true;
                                vmFreeStyles.Remove(freeStyle);
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "در این بخش هیچ فری استایلی قرار داده نشده", replyMarkup: Back);
                            }
                            FreeStyle1 = false;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            FreeStyle1 = false;
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        FreeStyle1 = false;
                        FreeStyle2 = false;
                        Bott();
                    }
                }
                if (FreeStyle2 && text != "قدیمی" && text != "جدید")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if (NewFreeStyle)
                            {
                                if(vmFreeStyles.Count >= 1)
                                {
                                    Random random = new Random();
                                    int randomIndex = random.Next(vmFreeStyles.Count);
                                    VmFreeStyles freeStyle = vmFreeStyles[randomIndex];
                                    await bot.CopyMessageAsync(id, freeStyle.FromChatId, freeStyle.VideoMessageId, replyMarkup: Next);
                                    vmFreeStyles.Remove(freeStyle);
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "شما تمام فری استایل های این بخش را تماشا کردید", replyMarkup: Back);
                                    FreeStyle2 = false;
                                    NewFreeStyle = false;
                                    OldFreeStyle = false;
                                }
                            }
                            else if (OldFreeStyle)
                            {
                                if (vmFreeStyles.Count >= 1)
                                {
                                    Random random = new Random();
                                    int randomIndex = random.Next(vmFreeStyles.Count);
                                    VmFreeStyles freeStyle = vmFreeStyles[randomIndex];
                                    await bot.CopyMessageAsync(id, freeStyle.FromChatId, freeStyle.VideoMessageId, replyMarkup: Next, cancellationToken: cancellationToken);
                                    vmFreeStyles.Remove(freeStyle);
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "شما تمام فری استایل های این بخش را تماشا کردید", replyMarkup: Back, cancellationToken: cancellationToken);
                                    FreeStyle2 = false;
                                    NewFreeStyle = false;
                                    OldFreeStyle = false;
                                }
                            }
                        }
                        else if (text == "بازگشت")
                        {
                            FreeStyle2 = false;
                            NewFreeStyle = false;
                            OldFreeStyle = false;
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            FreeStyle2 = false;
                            NewFreeStyle = false;
                            OldFreeStyle = false;
                            Bott();
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        FreeStyle2 = false;
                        NewFreeStyle = false;
                        OldFreeStyle = false;
                        Bott();
                    }
                }
                if (text == "🌿 صحبت های گیاه خواری")
                {
                    Bott();
                    AddToVmVegetarianTalks(vmVegetarianTalks, context);
                    if (vmVegetarianTalks.Count >= 1)
                    {
                        Random random = new Random();
                        int randomIndex = random.Next(vmVegetarianTalks.Count);
                        VmVegetarianTalk talk = vmVegetarianTalks[randomIndex];
                        VegetarianTalkTxt = "برای دیدن نمونه های بیشتر روی <بعدی> کلیک کنید";
                        await bot.CopyMessageAsync(id, talk.FromChatId, talk.VideoMessageId, caption: talk.VideoCaption);
                        await bot.SendTextMessageAsync(id, VegetarianTalkTxt, replyMarkup: Next);
                        VegetarianTalk1 = true;
                        vmVegetarianTalks.Remove(talk);
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "هیچ داده ای در این بخش وجود ندارد", replyMarkup: Home);
                        Bott();
                    }
                }
                if (VegetarianTalk1 && text != "🌿 صحبت های گیاه خواری")
                {
                    if (text == "بعدی")
                    {
                        if(vmVegetarianTalks.Count >= 1)
                        {
                            Random random = new Random();
                            int randomIndex = random.Next(vmVegetarianTalks.Count);
                            VmVegetarianTalk talk = vmVegetarianTalks[randomIndex];
                            await bot.CopyMessageAsync(id, talk.FromChatId, talk.VideoMessageId, caption: talk.VideoCaption, replyMarkup: Next);
                            VegetarianTalkTxt = "";
                            vmVegetarianTalks.Remove(talk);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "شما تمام صحبت هارا مشاهده کردید", replyMarkup: Back);
                            Bott();
                        }
                    }
                    else if (text == "بازگشت")
                    {
                        VegetarianTalk1 = false;
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        VegetarianTalk1 = false;
                        Bott();
                    }
                }
                if (text == "⌛️ گیف ها")
                {
                    Bott();
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        AddToVmGifs(vmGifs, context);
                        if (vmGifs.Count >= 1)
                        {
                            Random random = new Random();
                            int randomIndex = random.Next(vmGifs.Count);
                            var gif = vmGifs[randomIndex];
                            await bot.CopyMessageAsync(id, gif.FromChatId, gif.GifMessageId, replyMarkup: Next);
                            vmGifs.Remove(gif);
                            Gif1 = true;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "هیچ گیفی در این بخش وجود ندارد", replyMarkup: Home);
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (Gif1 && text != "⌛️ گیف ها")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if(vmGifs.Count >= 1)
                            {
                                Random random = new Random();
                                int randomIndex = random.Next(vmGifs.Count);
                                var gif = vmGifs[randomIndex];
                                await bot.CopyMessageAsync(id, gif.FromChatId, gif.GifMessageId, replyMarkup: Next);
                                vmGifs.Remove(gif);
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "شما تمام گیف هارا مشاهده کردید", replyMarkup: Back);
                                Gif1 = false;
                                Bott();
                            }
                        }
                        else if (text == "صفحه اصلی")
                        {
                            Bott();
                        }
                        else if (text == "بازگشت")
                        {
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "👨‍🎤 سخن سلطان")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        Bott();
                        AddToVmSokhan(vmSokhans, context);
                        if (vmSokhans.Count >= 1)
                        {
                            textm = "👨‍🎤 سخن سلطان";
                            Random random = new Random();
                            int randomIndex = random.Next(vmSokhans.Count);
                            VmSokhan tblHeavy = vmSokhans[randomIndex];
                            if (tblHeavy.SongName != null)
                            {
                                await bot.CopyMessageAsync(id, tblHeavy.FromChatId, tblHeavy.HeavyTextMessageId, caption: $"نام آهنگ : {tblHeavy.SongName}", replyMarkup: Next);
                            }
                            else
                            {
                                await bot.CopyMessageAsync(id, tblHeavy.FromChatId, tblHeavy.HeavyTextMessageId, caption: "", replyMarkup: Next);
                            }
                            HeavyText1 = true;
                            vmSokhans.Remove(tblHeavy);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "فعلا در این بخش داده ای وجود ندارد", replyMarkup: Back);
                            Bott();
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (HeavyText1 && text != "👨‍🎤 سخن سلطان")
                {
                    if (JoinedChannels.Count == tblJoinRequireds.Count)
                    {
                        if (text == "بعدی")
                        {
                            if (vmSokhans.Count >= 1)
                            {
                                Random random = new Random();
                                int randomIndex = random.Next(vmSokhans.Count);
                                VmSokhan tblHeavy = vmSokhans[randomIndex];
                                if (tblHeavy.SongName != null)
                                {
                                    await bot.CopyMessageAsync(id, tblHeavy.FromChatId, tblHeavy.HeavyTextMessageId, caption: $"نام آهنگ : {tblHeavy.SongName}", replyMarkup: Next);
                                }
                                else
                                {
                                    await bot.CopyMessageAsync(id, tblHeavy.FromChatId, tblHeavy.HeavyTextMessageId, caption: "", replyMarkup: Next);
                                }
                                vmSokhans.Remove(tblHeavy);
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "شما تمام عکس نوشته هارا مشاهده کردید", replyMarkup: Back);
                                Bott();
                            }
                        }
                        else if (text == "صفحه اصلی")
                        {
                            HeavyText1 = false;
                        }
                        else if (text == "بازگشت")
                        {
                            HeavyText1 = false;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            HeavyText1 = false;
                        }
                    }
                    else
                    {
                        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                        await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                    }
                }
                if (text == "صحبت گیاه خواری ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        Bott();
                        KeyboardButton[][] AddVeganTalkKey = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "بازگشت"),
                                        new KeyboardButton(text: "اضافه کن"),
                                    },
                        };
                        ReplyKeyboardMarkup AddVeganTalk = new ReplyKeyboardMarkup(AddVeganTalkKey) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "ویدیو هارا را با کپشن مورد نظر ارسال کنید", replyMarkup: AddVeganTalk);
                        Last50Message?.Clear();
                        AddVegetarianTalk1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if (text == "ویدیو ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        KeyboardButton[][] videoCat = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "دیگر"),
                                        new KeyboardButton(text: "لایو"),
                                        new KeyboardButton(text: "مصاحبه"),
                                    },
                        };
                        ReplyKeyboardMarkup VideoCategory = new ReplyKeyboardMarkup(videoCat) { ResizeKeyboard = true };
                        AddVideoCategoryTxt = "دسته بندی ویدیو را از طریق گزینه های زیر تعیین کنید";
                        await bot.SendTextMessageAsync(id, AddVideoCategoryTxt, replyMarkup: VideoCategory);
                        AddVideo1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }

                }
                if (AddVideo1 && text != "ویدیو ➕")
                {
                    if (context.VideoCategories.SingleOrDefault(i => i.Name == text) != null)
                    {
                        AddVideoCategoryId = context.VideoCategories.SingleOrDefault(i => i.Name == text).Id;
                        AddVideoTxt = "ویدیو را با کپشن مربوطه ارسال کنید!";
                        await bot.SendTextMessageAsync(id, AddVideoTxt, replyMarkup: replyMarkupRemove);
                        AddVideo1 = false;
                        AddVideo2 = true;

                    }
                    else
                    {

                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        AddVideo1 = false;
                        Bott();

                    }

                }
                if (text == "موزیک ویدیو ➕")
                {
                    Bott();
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddMusicVideoTxtName = "نام آهنگ استفاده شده در ویدیو را به صورت انگلیسی ارسال کنید \n (مطمئن شوید این آهنگ را در بخش `مدیریت آهنگ ها` اضافه نموده اید !!!)";
                        await bot.SendTextMessageAsync(id, AddMusicVideoTxtName, parseMode: ParseMode.Markdown, replyMarkup: replyMarkupRemove);
                        AddMusicVideos1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddMusicVideos1 && text != "موزیک ویدیو ➕")
                {
                    if (context.TblSongs.SingleOrDefault(i => i.Name == CapitalizeWords(text)) != null)
                    {
                        AddMusicVideoSongName = text;
                        AddMusicVideoSongId = context.TblSongs.SingleOrDefault(i => i.Name == text).Id;
                        await bot.SendTextMessageAsync(id, "موزیک ویدیو را همراه با کپشن مورد نظر ارسال کنید (به صورت فایل نباشد)", replyMarkup: replyMarkupRemove);
                        AddMusicVideos1 = false;
                        AddMusicVideos2 = true;
                        GoToAdmin = false;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Back);
                        GoToAdmin = true;
                    }
                    AddMusicVideos1 = false;
                }
                if (text == "سخن ➕")
                {
                    KeyboardButton[][] AddHeavyTextKey = new KeyboardButton[][]
                    {
                                new KeyboardButton[]
                                {
                                    new KeyboardButton(text: "صفحه اصلی"),
                                    new KeyboardButton(text: "اضافه کن"),
                                },
                    };
                    ReplyKeyboardMarkup AddHeavyText = new ReplyKeyboardMarkup(AddHeavyTextKey) { ResizeKeyboard = true };
                    await bot.SendTextMessageAsync(id, "عکس نوشته هارا برای ربات ارسال کنید و سپس روی <اضافه کن> کلیک کنید", replyMarkup: AddHeavyText);
                    AddHeavyText1 = true;
                    Last50Message?.Clear();
                }
                if (text == "فری استایل ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        KeyboardButton[][] AddFreeStyleTimeToPublic = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        //new KeyboardButton(text: "صفحه اصلی"),
                                        //new KeyboardButton(text: "اضافه کن"),
                                        new KeyboardButton(text: "قدیمی"),
                                        new KeyboardButton(text: "جدید"),
                                    },
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "بازگشت"),
                                    },
                        };
                        ReplyKeyboardMarkup AddFreeStyle = new ReplyKeyboardMarkup(AddFreeStyleTimeToPublic) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: AddFreeStyle);
                        AddFreeStyle1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if (AddFreeStyle1 && text != "فری استایل ➕")
                {
                    KeyboardButton[][] AddFreeStyleKey = new KeyboardButton[][]
                    {
                                new KeyboardButton[]
                                {
                                    new KeyboardButton(text: "صفحه اصلی"),
                                    new KeyboardButton(text: "اضافه کن"),
                                },
                    };
                    ReplyKeyboardMarkup AddFreeStyle = new ReplyKeyboardMarkup(AddFreeStyleKey) { ResizeKeyboard = true };
                    AddFreestyleTxt = "ویدیو هارا با کپشن مورد نظر برای ربات ارسال کنید و سپس روی <اضافه کن> کلیک کنید";
                    if (text == "قدیمی")
                    {
                        Last50Message?.Clear();
                        AddFreeStyleTimeToPublic = false;
                        await bot.SendTextMessageAsync(id, AddFreestyleTxt, replyMarkup: AddFreeStyle);
                        AddFreeStyle2 = true;
                    }
                    else if (text == "جدید")
                    {
                        Last50Message?.Clear();
                        AddFreeStyleTimeToPublic = true;
                        await bot.SendTextMessageAsync(id, AddFreestyleTxt, replyMarkup: AddFreeStyle);
                        AddFreeStyle2 = true;
                    }
                    else if (text == "بازگشت")
                    {
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Back);
                        GoToAdmin = true;
                    }
                    AddFreeStyle1 = false;
                }

                if (text == "مدیریت دسترسی کاربران")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        List<List<KeyboardButton>> WithBack = new List<List<KeyboardButton>>();
                        ManageUsersAccess(id, "از طریق گزینه های زیر میتوانید محدوده دسترسی کاربران تغییر دهید 👇🏻👇🏻", bot);
                        ManageUsersAccess1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if (ManageUsersAccess1 && text != "مدیریت دسترسی کاربران")
                {
                    string messagee = "تغییرات با موفقیت انجام شد ✅";
                    if (text == "غیر فعال نمایان شدن ویدیو ها")
                    {
                        ShowVideoFilesToUsers = false;
                        ManageUsersAccess(id, messagee, bot);
                    }
                    else if (text == "غیر فعال نمایان شدن فایل آهنگ ها")
                    {
                        ShowAudioFileToUsers = false;
                        ManageUsersAccess(id, messagee, bot);
                    }
                    else if (text == "فعال نمایان شدن ویدیو ها")
                    {
                        ShowVideoFilesToUsers = true;
                        ManageUsersAccess(id, messagee, bot);
                    }
                    else if (text == "فعال نمایان شدن فایل آهنگ ها")
                    {
                        ShowAudioFileToUsers = true;
                        ManageUsersAccess(id, messagee, bot);
                    }
                    else if (text == "بازگشت")
                    {
                        ManageUsersAccess1 = false;
                        Bott();
                    }
                }

                if (text == "مدیریت آهنگ ها")
                {
                    KeyboardButton[][] SongOperation = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton(text: "اضافه کردن آهنگ"),
                            new KeyboardButton(text: "ویرایش آهنگ")
                        },
                        new KeyboardButton[]
                        {
                            new KeyboardButton(text: "حذف آهنگ")
                        },
                    };
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        SongOperationTxt = "عملیات مورد نظر را انتخاب کنید";
                        ReplyKeyboardMarkup SongOperationKey = new ReplyKeyboardMarkup(SongOperation) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, SongOperationTxt, replyMarkup: SongOperationKey);
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (text == "اضافه کردن آهنگ" || text == "حذف آهنگ" || text == "ویرایش آهنگ")
                {
                    if (SongOperationTxt == "عملیات مورد نظر را انتخاب کنید")
                    {
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                        {
                            if (text == "اضافه کردن آهنگ")
                            {
                                addSongTxtEn = "نام آهنگ را ارسال کنید (انگلیسی)";
                                AddSong1 = true;
                                await bot.SendTextMessageAsync(id, addSongTxtEn, replyMarkup: replyMarkupRemove);
                                AddSong2 = false;
                                AddSong3 = false;
                            }
                            else if(text == "حذف آهنگ")
                            {
                                DelSongtxtName = "نام آهنگی که میخواهید حذف شود را ارسال کنید";
                                await bot.SendTextMessageAsync(id, DelSongtxtName, replyMarkup: replyMarkupRemove);
                                DelSong1 = true;
                            }
                            else if(text == "ویرایش آهنگ")
                            {
                                EditSongName = "نام آهنگی که میخواهید ادیت شود را ارسال کنید";
                                await bot.SendTextMessageAsync(id, EditSongName, replyMarkup: replyMarkupRemove);
                                DelSong1 = false;
                                AddSong1 = false;
                                EditSong1 = true;
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "یافت نشد");
                            }
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است");
                        }
                    }
                    else
                    {
                        Bott();
                        await bot.SendTextMessageAsync(id, "یافت نشد");
                    }
                    SongOperationTxt = "";
                }
                if (AddSong1 && addSongTxtEn == "نام آهنگ را ارسال کنید (انگلیسی)" && text != "اضافه کردن آهنگ" && HeavyText1 == false)
                {
                    AddSongName = text;
                    addSongTxtFa = "نام آهنگ را ارسال کنید (فارسی)";
                    await bot.SendTextMessageAsync(id, addSongTxtFa);
                    addSongTxtEn = "";
                    AddSong2 = true;
                    AddSong1 = false;
                    AddSong3 = false;
                    AddSong4 = false;
                }
                if (AddSong2 && addSongTxtFa == "نام آهنگ را ارسال کنید (فارسی)" && text != AddSongName)
                {
                    AddSongPersianName = text;
                    addSongTxtArt = "نام آرتیست را ارسال کنید";
                    await bot.SendTextMessageAsync(id, addSongTxtArt);
                    addSongTxtFa = "";
                    AddSong1 = false;
                    AddSong2 = false;
                    AddSong3 = true;
                    AddSong4 = false;
                    AddSong5 = false;
                    AddSong6 = false;
                    AddSong7 = false;
                }
                if (AddSong3 && addSongTxtArt == "نام آرتیست را ارسال کنید" && text != AddSongPersianName)
                {
                    AddSongArtist = text;
                    addSongTxtYtLink = "لینک یوتیوب آهنگ را ارسال کنید";
                    await bot.SendTextMessageAsync(id, addSongTxtYtLink);
                    addSongTxtArt = "";
                    AddSong1 = false;
                    AddSong2 = false;
                    AddSong3 = false;
                    AddSong4 = true;
                }
                if (AddSong4 && addSongTxtYtLink == "لینک یوتیوب آهنگ را ارسال کنید" && text != AddSongArtist)
                {
                    if (text.Contains("https://youtu.be") || text.Contains("https://youtube.com"))
                    {
                        AddSongYtLink = text;
                        addSongTxtSyLink = "لینک اسپاتیفای آهنگ را ارسال کنید (اجباری نیست) \n برای رد کردن /skip را ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongTxtSyLink);
                        addSongTxtYtLink = "";
                        AddSong1 = false;
                        AddSong2 = false;
                        AddSong3 = false;
                        AddSong4 = false;
                        AddSong5 = true;
                    }

                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد \n لینک را به درستی ارسال کنید");
                    }
                }
                if (AddSong5 && addSongTxtSyLink == "لینک اسپاتیفای آهنگ را ارسال کنید (اجباری نیست) \n برای رد کردن /skip را ارسال کنید" && text != AddSongYtLink)
                {
                    if (text == "/skip")
                    {
                        AddSongSyLink = null;
                        addSongTxtSyLink = "";
                        addSongTxtSendSong = "فایل صوتی آهنگ را ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongTxtSendSong);
                        AddSong1 = false;
                        AddSong2 = false;
                        AddSong3 = false;
                        AddSong4 = false;
                        AddSong5 = false;
                        AddSong6 = true;
                    }
                    else if (text.Contains("https://open.spotify.com"))
                    {
                        AddSongSyLink = text;
                        addSongTxtSyLink = "";
                        addSongTxtSendSong = "فایل صوتی آهنگ را ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongTxtSendSong);
                        AddSong1 = false;
                        AddSong2 = false;
                        AddSong3 = false;
                        AddSong4 = false;
                        AddSong5 = false;
                        AddSong6 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد \n لینک را به درستی ارسال کنید");
                    }
                }
                if(EditSong1 && EditSongName == "نام آهنگی که میخواهید ادیت شود را ارسال کنید" && text != "ویرایش آهنگ")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if(SongtoEdit is null)
                        {
                            SongtoEdit = context.TblSongs.SingleOrDefault(i => i.Name == CapitalizeWords(text) || i.PersianName == text);
                        }
                        if(SongtoEdit is not null)
                        {
                            await bot.SendTextMessageAsync(id, "گزینه مورد نظر برای ادیت را انتخاب کنید", replyMarkup: EditSong, cancellationToken: cancellationToken);
                            EditSong2 = true;
                            EditSong1 = false;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "آهنگی با این اسم در لیست آهنگ ها وجود ندارد", replyMarkup: Back);
                            Bott();
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if(text is "نام فارسی آهنگ" or "متن آهنگ" or "کاور خام" or "لینک کارائوکه" && EditSong2)
                {
                    if(text == "نام فارسی آهنگ")
                    {
                        EditSongPersianName = true;
                        await bot.SendTextMessageAsync(id, "نام آهنگ را برای ادیت ارسال کنید (فارسی)", replyMarkup: replyMarkupRemove);
                    }
                    else if(text == "متن آهنگ")
                    {
                        EditSongLyrics = true;
                        await bot.SendTextMessageAsync(id, "متن آهنگ را ارسال کنید", replyMarkup: replyMarkupRemove);
                    }
                    else if(text == "کاور خام")
                    {
                        EditSongEmptyCover = true;
                        await bot.SendTextMessageAsync(id, "کاور خام آهنگ را ارسال کنید", replyMarkup: replyMarkupRemove);
                    }
                    else if(text == "لینک کارائوکه")
                    {
                        await bot.SendTextMessageAsync(id, "لینک کارائوکه آهنگ را ارسال کنید", replyMarkup: replyMarkupRemove);
                        EditSongKaraoke = true;
                    }
                    EditSong2 = false;
                    EditSong3 = true;
                }
               
                if (text == "ارسال پیام همگانی ✉️")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        await bot.SendTextMessageAsync(id, "متن پیام را ارسال کنید", replyMarkup: replyMarkupRemove);
                        SendPublicMessage = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (SendPublicMessage && text != "ارسال پیام همگانی ✉️")
                {
                    MessageToSend = $"*پیام از طرف ادمین ربات : * \n\n {text}";
                    SendPublicMessageTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                    ReplyKeyboardMarkup ConfirmPm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                    await bot.SendTextMessageAsync(id, SendPublicMessageTxtConfirm, replyMarkup: ConfirmPm);
                    SendPublicMessage = false;
                    SendPublicMessageConfirm = true;
                }
                if(text == "صحبت ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddPhotoTxt = "عکس مورد نظر را ارسال کنید";
                        await bot.SendTextMessageAsync(id, AddPhotoTxt, replyMarkup: replyMarkupRemove);
                        AddTalk1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if (text == "عکس ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddPhotoTxt = "عکس مورد نظر را ارسال کنید";
                        await bot.SendTextMessageAsync(id, AddPhotoTxt, replyMarkup: replyMarkupRemove);
                        Addphoto1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (Addphoto2)
                {
                    ReplyKeyboardMarkup AddPhotoConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                    if (text == "قدیمی")
                    {
                        AddPhotoTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                        await bot.SendTextMessageAsync(id, AddPhotoTxtConfirm, replyMarkup: AddPhotoConfirm);
                        AddphotoIsNew = false;
                        Addphoto2 = false;
                        Addphoto3 = true;
                    }
                    else if (text == "جدید")
                    {
                        AddPhotoTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                        await bot.SendTextMessageAsync(id, AddPhotoTxtConfirm, replyMarkup: AddPhotoConfirm);
                        AddphotoIsNew = true;
                        Addphoto2 = false;
                        Addphoto3 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        Addphoto2 = false;
                        Addphoto3 = false;
                        Bott();
                    }
                }
                if (AddTalk2)
                {
                    ReplyKeyboardMarkup AddTalkConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                    if (text == "قدیمی")
                    {
                        AddPhotoTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                        await bot.SendTextMessageAsync(id, AddPhotoTxtConfirm, replyMarkup: AddTalkConfirm);
                        AddTalkIsNew = false;
                        AddTalk2 = false;
                        AddTalk3 = true;
                    }
                    else if (text == "جدید")
                    {
                        AddPhotoTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                        await bot.SendTextMessageAsync(id, AddPhotoTxtConfirm, replyMarkup: AddTalkConfirm);
                        AddTalkIsNew = true;
                        AddTalk2 = false;
                        AddTalk3 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        Bott();
                    }
                }
                if (text == "معنی تتو ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddTattooTxtPhoto = "عکس تتو مورد نظر را ارسال کنید";
                        await bot.SendTextMessageAsync(id, AddTattooTxtPhoto, replyMarkup: replyMarkupRemove);
                        AddTattoo1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddTattoo2)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (text.Length >= 64)
                        {
                            await bot.SendTextMessageAsync(id, "نوشته شما بیشتر از 64 کاراکتر میباشد ❌\n لطفا متن را کوتاه تر کرده و ارسال نمایید");
                        }
                        else
                        {
                            AddTattooName = text;
                            AddTattooTxtExplanation = "توضیحات کامل تتو را ارسال کنید";
                            await bot.SendTextMessageAsync(id, AddTattooTxtExplanation);
                            AddTattoo2 = false;
                            AddTattoo3 = true;
                        }

                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddTattoo3 && text != AddTattooName)
                {
                    AddTattooExplanation = text;
                    TblTattooMean tattooMean = new TblTattooMean();
                    tattooMean.Name = AddTattooName;
                    tattooMean.FromChatId = id;
                    tattooMean.TattooMeanMessageId = AddTattooMessageId;
                    tattooMean.Explanation = AddTattooExplanation;
                    context.TblTattooMeans.Add(tattooMean);
                    context.SaveChanges();
                    await bot.SendTextMessageAsync(id, "داده مورد نظر اضافه گردید ✅", replyMarkup: Home);
                    AddTattoo3 = false;
                    Bott();
                }
                if (text == "گیف ➕")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddGifTxt = "گیف هارا برای ربات ارسال کنید و سپس روی <اضافه کن> کلیک کنید";
                        KeyboardButton[][] AddGifKey = new KeyboardButton[][]
                        {
                                    new KeyboardButton[]
                                    {
                                        new KeyboardButton(text: "صفحه اصلی"),
                                        new KeyboardButton(text: "اضافه کن"),
                                    },
                        };
                        ReplyKeyboardMarkup AddGif = new ReplyKeyboardMarkup(AddGifKey) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, AddGifTxt, replyMarkup: AddGif);
                        AddGif1 = true;
                        Last50Message?.Clear();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }

                }
                if (text == "مدیریت ادمین ها")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id && i.RoleId == 1) != null)
                        {
                            string AdminsInfo = "*لیست ادمین ها :*\n\n";
                            KeyboardButton[][] ManageAdminsKeyboard = new KeyboardButton[][]
                            {
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton(text: "اضافه کردن ادمین"),
                                        },
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton(text: "صفحه اصلی"),
                                            new KeyboardButton(text: "حذف ادمین"),
                                        }
                            };
                            ReplyKeyboardMarkup ManageAdmins = new ReplyKeyboardMarkup(ManageAdminsKeyboard) { ResizeKeyboard = true };
                            foreach (TblBotAdmin i in Admins)
                            {
                                AdminsInfo += $"نام : {i.Name}\n آیدی : {i.AdminChatId}\n\n";
                            }
                            await bot.SendTextMessageAsync(id, AdminsInfo, parseMode: ParseMode.MarkdownV2, replyMarkup: ManageAdmins);
                            AdminOperation = true;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "فقط ادمین های اصلی ربات به این بخش دسترسی دارند", replyMarkup: Home);
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AdminOperation && text == "حذف ادمین" || AdminOperation && text == "اضافه کردن ادمین")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id && i.RoleId == 1) != null)
                        {
                            if (text == "اضافه کردن ادمین")
                            {
                                AddAdminTxtName = "نام ادمین را ارسال کنید";
                                await bot.SendTextMessageAsync(id, AddAdminTxtName, replyMarkup: replyMarkupRemove);
                                AdminOperation = false;
                                AddAdmin1 = true;
                            }
                            else if (text == "حذف ادمین")
                            {
                                DelTxtAdmin = "آیدی عددی ادمین مورد نظر را وارد کنید";
                                await bot.SendTextMessageAsync(id, DelTxtAdmin, replyMarkup: replyMarkupRemove);
                                AdminOperation = false;
                                DelAdmin1 = true;
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            }
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "فقط ادمین های اصلی ربات به این بخش دسترسی دارند", replyMarkup: Home);
                        }

                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddAdmin1 && text != "اضافه کردن ادمین")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddAdminName = text;
                        AddAdminTxtChatId = "آیدی عددی کاربر مورد نظر را وارد کنید";
                        await bot.SendTextMessageAsync(id, AddAdminTxtChatId, replyMarkup: replyMarkupRemove);
                        AddAdmin1 = false;
                        AddAdmin2 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddAdmin2 && text != AddAdminName && IsNumeric(text))
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        List<KeyboardButton> Role = new List<KeyboardButton>();
                        foreach (TblAdminRol i in adminRols)
                        {
                            Role.Add(i.Name);
                        }
                        ReplyKeyboardMarkup Roles = new ReplyKeyboardMarkup(Role) { ResizeKeyboard = true };
                        AddAdminChatId = text;
                        AddAdminTxtRole = "رول ادمین را تعیین کنید (پهنای دسترسی)";
                        await bot.SendTextMessageAsync(id, AddAdminTxtRole, replyMarkup: Roles);
                        AddAdmin1 = false;
                        AddAdmin2 = false;
                        AddAdmin3 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (AddAdmin3 && context.TblAdminRols.SingleOrDefault(i => i.Name == text) != null)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        AddAdminRoleId = context.TblAdminRols.SingleOrDefault(i => i.Name == text).Id;
                        AddAdminTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                        ReplyKeyboardMarkup AddAdminConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                        await bot.SendTextMessageAsync(id, AddAdminTxtConfirm, replyMarkup: AddAdminConfirm);
                        AddAdmin1 = false;
                        AddAdmin2 = false;
                        AddAdmin3 = false;
                        AddAdmin4 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddAdmin1 = false;
                        AddAdmin2 = false;
                        AddAdmin3 = false;
                    }
                }
                if (DelAdmin1 && text != "حذف ادمین")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId.ToString() == text) != null)
                    {
                        TblBotAdmin botAdmin = context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId.ToString() == text);
                        ReplyKeyboardMarkup DeleteAdmin = new ReplyKeyboardMarkup(DeleteConfirm) { ResizeKeyboard = true };
                        DelTxtAdminConfirm = $"نام : {botAdmin.Name}\n آیدی : {botAdmin.AdminChatId}\n برای تایید روی گزینه < حذف > کلیک کنید";
                        await bot.SendTextMessageAsync(id, DelTxtAdminConfirm, replyMarkup: DeleteAdmin);
                        DeleteAdminChatId = botAdmin.AdminChatId;
                        DelAdmin1 = false;
                        DelAdmin2 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "ادمینی با این آیدی در لیست وجود ندارد", replyMarkup: Home);
                        Bott();
                    }
                }
                if (text == "مدیریت قفل چنل")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        ChannelOperation = "عملیات مورد نظر را انتخاب کنید";
                        ReplyKeyboardMarkup RequirdChannelOperation = new ReplyKeyboardMarkup(ManageChannelKeyboard)
                        {
                            ResizeKeyboard = true
                        };
                        await bot.SendTextMessageAsync(id, ChannelOperation, replyMarkup: RequirdChannelOperation);
                        ChannelOperation1 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (ChannelOperation1 && text != "مدیریت قفل چنل")
                {
                    if (text == "اضافه کردن کانال" || (text == "حذف کانال" && DelChannel1 == false))
                    {
                        if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                        {
                            if (text == "اضافه کردن کانال")
                            {
                                AddChannelTxtName = "نام چنل را برای اضافه شدن ارسال کنید";
                                await bot.SendTextMessageAsync(id, AddChannelTxtName, replyMarkup: replyMarkupRemove);
                                AddChannel1 = true;

                            }
                            else if (text == "حذف کانال" && DelChannel1 == false)
                            {
                                List<TblJoinRequiredChannel> joinRequiredChannels = context.TblJoinRequiredChannels.ToList();
                                if (joinRequiredChannels.Count > 0)
                                {
                                    DelChannelTxtId = "کانال مورد نظر را انتخاب کنید";
                                    ReplyKeyboardMarkup ChannelToDel = new ReplyKeyboardMarkup(ChannelsRequird)
                                    {
                                        ResizeKeyboard = true
                                    };
                                    await bot.SendTextMessageAsync(id, DelChannelTxtId, replyMarkup: ChannelToDel);
                                    DelChannel1 = true;
                                }
                                else
                                {
                                    await bot.SendTextMessageAsync(id, "کانالی وجود ندارد", replyMarkup: Back);
                                    Bott();
                                    GoToAdmin = true;
                                }
                            }
                            else
                            {
                                await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                            }
                            ChannelOperation1 = false;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        }
                    }
                }
                if (AddChannel1 && text != "اضافه کردن کانال")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (context.TblJoinRequiredChannels.SingleOrDefault(i => i.Name == text) == null)
                        {
                            AddChannelName = text;
                            AddChannelTxtLink = "لینک کانال را ارسال کنید \n مثال : https://t.me/xxxxxxxxx";
                            await bot.SendTextMessageAsync(id, AddChannelTxtLink);
                            AddChannel1 = false;
                            AddChannel2 = true;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "از تکراری وارد نمودن نام خودداری نمایید", replyMarkup: replyMarkupRemove);
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddChannel1 = false;
                    }
                }
                if (AddChannel2 && text != AddChannelName)
                {
                    if (text.Contains("https://t.me/"))
                    {
                        if (context.TblJoinRequiredChannels.SingleOrDefault(i => i.ChannelLink == text) == null)
                        {
                            AddChannelLink = text;
                            AddChannelTxtId = "آیدی عددی کانال مورد نظر را ارسال کنید";
                            await bot.SendTextMessageAsync(id, AddChannelTxtId);
                            AddChannel1 = false;
                            AddChannel2 = false;
                            AddChannel3 = true;
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "این کانال در لیست وجود دارد!!", replyMarkup: Back);
                            Bott();
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "لینک فرستاده شده صحیح نیست", replyMarkup: Home);
                        AddChannel1 = false;
                        AddChannel2 = false;
                    }
                }
                if (AddChannel3 && text != AddChannelLink)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (text.StartsWith("-100"))
                        {
                            ChatMember AddChannelChatMemberConfirm;
                            //try
                            //{
                            AddChannelChatMemberConfirm = await bot.GetChatMemberAsync(Convert.ToInt64(text.Trim()), id);
                            AddChannelId = Convert.ToInt64(text);
                            AddChannelTxtConfirm = "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟";
                            ReplyKeyboardMarkup AddChannelConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                            await bot.SendTextMessageAsync(id, AddChannelTxtConfirm, replyMarkup: AddChannelConfirm);
                            AddChannel1 = false;
                            AddChannel2 = false;
                            AddChannel3 = false;
                            AddChannel4 = true;
                            //}
                            //catch (Telegram.Bot.Exceptions.ChatNotFoundException ex)
                            //{
                            //    string ChatNotFound = "کانال یافت نشد ❌\n1. آیدی کانال را به درستی وارد نکردید \n2. ربات ادمین کانال مورد نیست ";
                            //    await bot.SendTextMessageAsync(id, ChatNotFound, replyMarkup: Back);
                            //    Bott();
                            //    GoToAdmin = true;
                            //}
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "آیدی را به درستی وارد نمایید", replyMarkup: Back);
                            AddChannel1 = false;
                            AddChannel2 = false;
                            AddChannel3 = true;
                            AddChannel4 = false;
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Bott();
                    }
                }
                if (DelChannel1 && context.TblJoinRequiredChannels.SingleOrDefault(i => i.Name == text) != null)
                {
                    if (context.TblJoinRequiredChannels.SingleOrDefault(i => i.Name == text) != null)
                    {
                        ReplyKeyboardMarkup DeleteSChannel = new ReplyKeyboardMarkup(DeleteConfirm) { ResizeKeyboard = true };
                        TblJoinRequiredChannel requiredChannel = context.TblJoinRequiredChannels.SingleOrDefault(i => i.Name == text);
                        DelChannelTxtConfirm = $"نام کانال : {requiredChannel.Name} \n لینک کانال : {requiredChannel.ChannelLink} \n اگر برای حذف این کانال از لیست اطمینان دارید روی گزینه < حذف > کلیک کنید";
                        await bot.SendTextMessageAsync(id, DelChannelTxtConfirm, replyMarkup: DeleteSChannel);
                        DelChannelName = text;
                        DelChannel2 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    }
                    DelChannel1 = false;
                }
                if (text == "حذف")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (DelSong2 && DeleteSongName != "")
                        {
                            TblSong DeleteSong = context.TblSongs.SingleOrDefault(i => i.Name == DeleteSongName);
                            context.TblSongs.Remove(DeleteSong);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "آهنگ مورد نظر با موفقیت حذف گردید", replyMarkup: Home);
                            DelSong1 = false;
                            DelSong2 = false;
                        }
                        else if (DelChannel2 && DelChannelName != "")
                        {
                            TblJoinRequiredChannel DeleteChannel = context.TblJoinRequiredChannels.SingleOrDefault(i => i.Name == DelChannelName);
                            context.TblJoinRequiredChannels.Remove(DeleteChannel);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "کانال مورد نظر با موفقیت حذف گردید", replyMarkup: Home);
                            DelChannelName = "";
                            DelChannel1 = false;
                            DelChannel2 = false;
                        }
                        else if (DelAdmin2 && DeleteAdminChatId != 0)
                        {
                            TblBotAdmin AdminToDel = context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == DeleteAdminChatId);
                            context.TblBotAdmins.Remove(AdminToDel);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "ادمین با موفیت حذف شد", replyMarkup: Home);
                            Bott();
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
                if (text == "انصراف")
                {
                    ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(AdminSection);
                    if (DelSong2)
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: AdminKeyboard);
                        DelSong2 = false;
                    }
                    else if (DelAdmin2 && DeleteAdminChatId != 0)
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: Home);
                        Bott();
                        DelAdmin2 = false;
                    }
                    else if (DelChannel2)
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: AdminKeyboard);
                        DelChannel2 = false;
                    }
                    else if (SendPublicMessageConfirm && MessageToSend != "")
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: Home);
                        Bott();
                        SendPublicMessageConfirm = false;
                        MessageToSend = "";
                    }
                    else if (AddTalk3)
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: Back);
                        Bott();
                    }
                    else if (EditSong4 && SongtoEdit != null)
                    {
                        await bot.SendTextMessageAsync(id, "✅", replyMarkup: Back);
                        Bott();
                    }    
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    }
                }
                if (AddSong11 || AddSong11 && addSongtxtKootahLyrics == "بسیار کوتاه است")
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (text.Length > 64)
                        {
                            AddSongLyrics = text;
                            ReplyKeyboardMarkup AddSongConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                            addSongtxtConfirm = "آیا از اطلاعات وارد شده اطمینان کامل دارید";
                            await bot.SendTextMessageAsync(id, addSongtxtConfirm, replyMarkup: AddSongConfirm);
                            AddSong11 = false;
                            AddSong12 = true;
                            addSongtxtKootahLyrics = "";
                        }
                        else if (text == "/skip Lyrics")
                        {
                            AddSongLyrics = null;
                            ReplyKeyboardMarkup AddSongConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                            addSongtxtConfirm = "آیا از اطلاعات وارد شده اطمینان کامل دارید";
                            await bot.SendTextMessageAsync(id, addSongtxtConfirm, replyMarkup: AddSongConfirm);
                            AddSong11 = false;
                            AddSong12 = true;
                            addSongtxtKootahLyrics = "";
                        }
                        else
                        {
                            addSongtxtKootahLyrics = "بسیار کوتاه است";
                            await bot.SendTextMessageAsync(id, addSongtxtKootahLyrics, replyMarkup: replyMarkupRemove);
                        }
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    }
                }
            }




            if (AddVegetarianTalk1 && text != "صحبت گیاه خواری ➕")
            {
                if (message.Type == MessageType.Video)
                {

                }
                else if (text == "اضافه کن")
                {
                    List<Message> ListToAdd = Last50Message.Where(i => i.Type == MessageType.Video).ToList();
                    if(ListToAdd.Count >= 1)
                    {
                        foreach (Message i in ListToAdd)
                        {
                            TblVegetarianTalk vegetarianTalk = new TblVegetarianTalk();
                            vegetarianTalk.FromChatId = i.From.Id;
                            vegetarianTalk.VideoMessageId = i.MessageId;
                            vegetarianTalk.VideoCaption = i.Caption;
                            context.TblVegetarianTalks.Add(vegetarianTalk);
                            context.SaveChanges();
                        }
                        await bot.SendTextMessageAsync(id, "با موفقیت اضافه شد ✅", replyMarkup: Back);
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "داده ای برای اضافه شدن ارسال نکردید!!", replyMarkup: Back);
                        Bott();
                    }
                    GoToAdmin = true;

                }
                else if (text == "بازگشت")
                {
                    Bott();
                }
                else if (text == "صفحه اصلی")
                {
                    Bott();
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "لینک را به درستی ارسال کنید", replyMarkup: Back);
                    GoToAdmin = true;
                }
            }
            if (AddVideo2 && context.VideoCategories.SingleOrDefault(i => i.Name == text) == null)
            {
                if (message.Type == MessageType.Video)
                {
                    AddVideoMessageId = message.MessageId;
                    AddVideoCaption = message.Caption;
                    ReplyKeyboardMarkup AddVideoConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                    AddVideoTxtConfirm = "آیا از اطلاعات وارد شده اطمینان کامل دارید ؟";
                    await bot.SendTextMessageAsync(id, AddVideoTxtConfirm, replyMarkup: AddVideoConfirm);
                    AddVideo2 = false;
                    AddVideo3 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                }
            }
            if (AddMusicVideos2 && text != AddMusicVideoSongName)
            {
                if (message.Type == MessageType.Video)
                {
                    if(string.IsNullOrEmpty(message.Caption) == false)
                    {
                        AddMusicVideoCaption = message.Caption;
                    }
                    else
                    {
                        AddMusicVideoCaption = AddMusicVideoSongName;
                    }
                    AddMusicVideoMessageId = message.MessageId;
                    ReplyKeyboardMarkup AddVideoConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true };
                    AddMusicVideoTxtConfirm = "آیا از اطلاعات وارد شده اطمینان کامل دارید ؟";
                    await bot.SendTextMessageAsync(id, AddMusicVideoTxtConfirm, replyMarkup: AddVideoConfirm);
                    AddMusicVideos1 = false;
                    AddMusicVideos2 = false;
                    AddMusicVideos3 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    Bott();
                }
            }
            if (AddHeavyText1 && text != "سخن ➕")
            {
                if (message.Type == MessageType.Photo)
                {

                }
                else if (text == "اضافه کن")
                {
                    foreach (Message i in Last50Message)
                    {
                        if (i.Type == MessageType.Photo)
                        {
                            TblHeavyText heavyText = new TblHeavyText();
                            heavyText.FromChatId = i.Chat.Id;
                            heavyText.HeavyTextMessageId = i.MessageId;
                            context.TblHeavyTexts.Add(heavyText);
                            context.SaveChanges();
                        }
                    }
                    await bot.SendTextMessageAsync(id, "با موفقیت اضافه شد", replyMarkup: Home);
                    Bott();
                }
                else if (text == "صفحه اصلی")
                {
                    AddHeavyText1 = false;
                    Bott();
                }
                else if (text == "بازگشت")
                {
                    AddHeavyText1 = false;
                    Bott();
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    AddHeavyText1 = false;
                    Bott();
                }
            }
            if (AddFreeStyle2 && text != "قدیمی" && text != "جدید")
            {
                if (text == "اضافه کن")
                {
                    foreach (Message i in Last50Message)
                    {
                        if (i.Type == MessageType.Video)
                        {
                            TblFreeStyle freeStyle = new TblFreeStyle();
                            freeStyle.FromChatId = id;
                            freeStyle.VideoMessageId = i.MessageId;
                            if (AddFreeStyleTimeToPublic == false)
                            {
                                freeStyle.TimeToPublic = false;
                            }
                            context.TblFreeStyles.Add(freeStyle);
                            context.SaveChanges();
                        }
                    }
                    await bot.SendTextMessageAsync(id, "با موفقیت اضافه شد", replyMarkup: Home);
                    Bott();
                }
                else if (message.Type == MessageType.Video)
                {

                }
                else if (text == "صفحه اصلی")
                {
                    AddFreeStyle2 = false;
                    Bott();
                }
                else if (text == "بازگشت")
                {
                    AddFreeStyle2 = false;
                    Bott();
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                }
            }
            if (AddTattoo1 && text != "معنی تتو ➕")
            {
                if (message.Type == MessageType.Photo)
                {
                    AddTattooMessageId = message.MessageId;
                    AddTattooTxtName = "نام یا توصیفی یک کلمه ای از تتو را ارسال کنید";
                    await bot.SendTextMessageAsync(id, AddTattooTxtName, replyMarkup: replyMarkupRemove);
                    AddTattoo1 = false;
                    AddTattoo2 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    AddTattoo1 = false;
                    Bott();
                }
            }
            if (Addphoto1 && text != "عکس ➕")
            {
                if (message.Type == MessageType.Photo)
                {
                    AddPhotoMessageId = message.MessageId;
                    KeyboardButton[][] TimeToPublic = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton(text: "قدیمی"),
                            new KeyboardButton(text: "جدید"),
                        },
                    };
                    ReplyKeyboardMarkup TimeToPublicPhoto = new ReplyKeyboardMarkup(TimeToPublic) { ResizeKeyboard = true };
                    AddPhotoOldOrNew = "زمان انتشار عکس را تعیین کنید";
                    await bot.SendTextMessageAsync(id, AddPhotoOldOrNew, replyMarkup: TimeToPublicPhoto);
                    Addphoto1 = false;
                    Addphoto2 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    Addphoto1 = false;
                    Addphoto2 = false;
                    Bott();
                }
            }
            if(AddTalk1 && text != "صحبت ➕")
            {
                if (message.Type == MessageType.Photo)
                {
                    AddTalkMessageId = message.MessageId;
                    KeyboardButton[][] TimeToPublic = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton(text: "قدیمی"),
                            new KeyboardButton(text: "جدید"),
                        },
                    };
                    ReplyKeyboardMarkup TimeToPublicTalk = new ReplyKeyboardMarkup(TimeToPublic) { ResizeKeyboard = true };
                    AddPhotoOldOrNew = "زمان انتشار عکس را تعیین کنید";
                    await bot.SendTextMessageAsync(id, AddPhotoOldOrNew, replyMarkup: TimeToPublicTalk);
                    AddTalk1 = false;
                    AddTalk2 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    AddTalk1 = false;
                    AddTalk2 = false;
                    Bott();
                }
            }
            if (AddGif1 && text != "گیف ➕")
            {
                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                {
                    if (message.Animation != null)
                    {

                    }
                    else if (text == "اضافه کن")
                    {
                        if (Last50Message is not null)
                        {
                            foreach (Message i in Last50Message)
                            {
                                if (i.Animation != null)
                                {
                                    TblGif GifToAdd = new TblGif();
                                    GifToAdd.FromChatId = i.From.Id;
                                    GifToAdd.GifMessageId = i.MessageId;
                                    context.TblGifs.Add(GifToAdd);
                                    context.SaveChanges();
                                }
                            }
                            await bot.SendTextMessageAsync(id, "گیف ها با موفقیت اضافه شد ✅", replyMarkup: Home);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "داده ای دریافت نشد", replyMarkup: Back);

                        }
                        Bott();
                    }
                    else if (text == "صفحه اصلی")
                    {
                        AddGif1 = false;
                        Bott();
                    }
                    else if (text == "بازگشت")
                    {
                        AddGif1 = false;
                        GoToAdmin = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    }
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                    AddGif1 = false;
                    Bott();
                }
            }
            if (EditSong3 && text != "نام فارسی آهنگ" && text != "متن آهنگ" && text != "کاور خام" && text != "لینک کارائوکه")
            {
                ReplyKeyboardMarkup EditSongConfirm = new ReplyKeyboardMarkup(Confirm) { ResizeKeyboard = true};
                if(EditSongEmptyCover && message.Type == MessageType.Photo)
                {
                    SongtoEdit.EmptyCoverMessageId = message.MessageId;
                }
                else if(EditSongKaraoke && (text.Contains("https://youtu.be/") || text.Contains("https://youtube.com")))
                {
                    SongtoEdit.KaraokeLink = text.Trim();
                }
                else if(EditSongLyrics && text.Length > 128)
                {
                    SongtoEdit.Lyrics = text;
                }
                else if(EditSongPersianName && text.Length <= 64)
                {
                    SongtoEdit.PersianName = text.Trim();
                }
                context.TblSongs.Update(SongtoEdit);
                context.SaveChanges();
                EditSong3 = false;
                EditSong4 = true;
                await bot.SendTextMessageAsync(id, "تغییرات با موفقیت انجام شد ✅", replyMarkup: replyMarkupRemove, cancellationToken: cancellationToken);
                await bot.SendTextMessageAsync(id, "آیا قصد ادامه عملیات را دارید؟", replyMarkup: EditSongConfirm, cancellationToken: cancellationToken);
            }
            if (AddSong6 && addSongTxtSendSong == "فایل صوتی آهنگ را ارسال کنید")
            {
                if (message.Type == MessageType.Audio)
                {
                    List<List<KeyboardButton>> albumButton = new List<List<KeyboardButton>>();
                    GenerateAlbumsBtn(albumButton, context);
                    AddSongMessageId = message.MessageId;
                    bot.SendTextMessageAsync(id, "Song saved successfully!");
                    addSongTxtAlbumName = "آلبوم مورد نظر را انتخاب کنید";
                    ReplyKeyboardMarkup AlbumkeyboardMarkup = new ReplyKeyboardMarkup(albumButton);
                    await bot.SendTextMessageAsync(id, addSongTxtAlbumName, replyMarkup: AlbumkeyboardMarkup);
                    AddSong1 = false;
                    AddSong2 = false;
                    AddSong3 = false;
                    AddSong4 = false;
                    AddSong5 = false;
                    AddSong6 = false;
                    AddSong7 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "لطفا آهنگ را بصورت فایل صوتی و با فرمت mp3 ارسال کنید");
                }
            }
            if (DelSong1 && DelSongtxtName == "نام آهنگی که میخواهید حذف شود را ارسال کنید" && text != "حذف آهنگ")
            {
                if (context.TblSongs.SingleOrDefault(i => i.Name.Contains(text)) != null)
                {
                    ReplyKeyboardMarkup DeleteSong = new ReplyKeyboardMarkup(DeleteConfirm) { ResizeKeyboard = true };
                    TblSong song = context.TblSongs.SingleOrDefault(i => i.Name.Contains(text));
                    DelSongtxtInfo = $"نام آهنگ : {song.Name} \n آلبوم : {song.Album.Name} \n خواننده : {song.Artists} \n برای تایید روی گزینه < حذف > کلیک کنید";
                    DeleteSongName = song.Name;
                    await bot.SendTextMessageAsync(id, DelSongtxtInfo, replyMarkup: DeleteSong);
                    DelSong1 = false;
                    DelSong2 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "اسم آهنگ را به درستی وارد کنید");
                }
            }
            if (AddAlbum3 && CapitalizeWords(text) != AddAlbumName && AddAlbumTxtCover == "عکس کاور آلبوم را ارسال کنید (اختیاری) \n برای رد شدن روی /skip کلیک کنید")
            {
                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                {
                    if (message.Type == MessageType.Photo)
                    {
                        if (context.TblAlbums.SingleOrDefault(i => i.Name == AddAlbumName) != null)
                        {
                            TblAlbum Album = context.TblAlbums.SingleOrDefault(i => i.Name == AddAlbumName);
                            Album.Id = Album.Id;
                            AddAlbumCoverMessageId = message.MessageId;
                            Album.Name = AddAlbumName;
                            Album.FromChatId = id;
                            Album.CoverMessageId = AddAlbumCoverMessageId;
                            context.TblAlbums.Update(Album);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "آلبوم با موفقیت ادیت شد ✅", replyMarkup: Back);
                        }
                        else
                        {
                            TblAlbum Album = new TblAlbum();
                            AddAlbumCoverMessageId = message.MessageId;
                            Album.Name = AddAlbumName;
                            Album.FromChatId = id;
                            Album.CoverMessageId = AddAlbumCoverMessageId;
                            context.TblAlbums.Add(Album);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "آلبوم با موفقیت اضافه شد ✅", replyMarkup: Back);
                        }
                        Bott();
                    }
                    else if (text == "/skip")
                    {
                        TblAlbum Album = new TblAlbum();
                        Album.Name = AddAlbumName;
                        context.TblAlbums.Add(Album);
                        context.SaveChanges();
                        await bot.SendTextMessageAsync(id, "آلبوم با موفقیت اضافه شد ✅", replyMarkup: Back);
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Back);
                        Bott();
                    }
                    GoToAdmin = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                }
            }
            if (AddSong8 && text != AddSongAlbumName && addSongtxtCover == "کاور اصلی آهنگ را ارسال کنید")
            {
                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                {
                    if (message.Type == MessageType.Photo)
                    {
                        AddSongCoverMessageId = message.MessageId;
                        addSongtxtKaraoke = "لینک یوتیوب کارائوکه را ارسال کنید \n برای رد شدن را `/skip Karaoke` ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongtxtKaraoke, parseMode: ParseMode.MarkdownV2);
                        AddSong8 = false;
                        AddSong9 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    }
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                }
            }
            if (AddSong9 && message.Type != MessageType.Photo && addSongtxtKaraoke == "لینک یوتیوب کارائوکه را ارسال کنید \n برای رد شدن را `/skip Karaoke` ارسال کنید")
            {
                if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                {
                    if (text.Contains("https://youtu.be/") || text.Contains("https://youtube.com"))
                    {
                        AddSongKaraokeLink = text;
                        addSongtxtEmptyCover = "کاور خام آهنگ را ارسال کنید \n برای رد شدن را `/skip EmptyCover` ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongtxtEmptyCover, parseMode: ParseMode.MarkdownV2);
                        AddSong9 = false;
                        AddSong10 = true;
                    }
                    else if (text == "/skip Karaoke")
                    {
                        AddSongKaraokeLink = null;
                        addSongtxtEmptyCover = "کاور خام آهنگ را ارسال کنید \n برای رد شدن را `/skip EmptyCover` ارسال کنید";
                        await bot.SendTextMessageAsync(id, addSongtxtEmptyCover, parseMode: ParseMode.MarkdownV2);
                        AddSong9 = false;
                        AddSong10 = true;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "یافت نشد \n لینک را به درستی ارسال کنید");
                    }
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                }
            }
            if (AddSong10 && text != "/skip Karaoke" && text != AddSongKaraokeLink)
            {
                if (message.Type == MessageType.Photo)
                {
                    AddSongEmptyCoverMessageId = message.MessageId;
                    addSongtxtLyrics = "متن آهنگ را ارسال کنید \n برای رد شدن را `/skip Lyrics` ارسال کنید";
                    await bot.SendTextMessageAsync(id, addSongtxtLyrics);
                    AddSong8 = false;
                    AddSong9 = false;
                    AddSong10 = false;
                    AddSong11 = true;
                }
                else if (text == "/skip EmptyCover")
                {
                    AddSongEmptyCoverMessageId = 0;
                    addSongtxtLyrics = "متن آهنگ را ارسال کنید \n برای رد شدن را `/skip Lyrics` ارسال کنید";
                    await bot.SendTextMessageAsync(id, addSongtxtLyrics, parseMode: ParseMode.MarkdownV2);
                    AddSong8 = false;
                    AddSong9 = false;
                    AddSong10 = false;
                    AddSong11 = true;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                }
            }
            if (text == "بله")
            {
                ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                if (AddSong12 && AddSongName != "" && AddSongPersianName != "" && AddSongYtLink != "" && AddSongArtist != "" && AddSongAlbumName != "")
                {
                    TblSong song = new TblSong();
                    if (context.TblAlbums.Any(i => i.Name == AddSongAlbumName))
                    {
                        if (context.TblSongs.SingleOrDefault(i => i.Name == AddSongName) == null)
                        {

                            int AlbumId = context.TblAlbums.SingleOrDefault(i => i.Name == AddSongAlbumName).Id;
                            song.FromChatId = id;
                            song.Name = CapitalizeWords(AddSongName);
                            song.Artists = AddSongArtist;
                            song.AlbumId = AlbumId;
                            song.SongMessageId = AddSongMessageId;
                            song.YtLink = AddSongYtLink;
                            song.SyLink = AddSongSyLink;
                            song.PersianName = AddSongPersianName;
                            song.CoverMessageId = AddSongCoverMessageId;
                            if (AddSongEmptyCoverMessageId != 0)
                            {
                                song.EmptyCoverMessageId = AddSongEmptyCoverMessageId;
                            }
                            song.KaraokeLink = AddSongKaraokeLink;
                            song.Lyrics = AddSongLyrics;
                            context.TblSongs.Add(song);
                            context.SaveChanges();
                            await bot.SendTextMessageAsync(id, "آهنگ با موفقیت اضافه شد", replyMarkup: keyboardMarkup);
                            AddSong1 = false;
                            AddSong2 = false;
                            AddSong3 = false;
                            AddSong4 = false;
                            AddSong5 = false;
                            AddSong6 = false;
                            AddSong7 = false;
                            AddSong8 = false;
                            AddSong9 = false;
                            AddSong10 = false;
                            AddSong11 = false;
                            AddSong12 = false;
                            SongOperationTxt = "";
                            AddSongName = "";
                            AddSongPersianName = "";
                            AddSongArtist = "";
                            AddSongYtLink = "";
                            AddSongSyLink = null;
                            AddSongAlbumName = "";
                            AddSongKaraokeLink = "";
                            AddSongLyrics = "";
                        }

                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "آلبوم در نظر گرفته شده در کارنامه امیر تتلو وجود ندارد", replyMarkup: keyboardMarkup);
                        AddSong1 = false;
                        AddSong2 = false;
                        AddSong3 = false;
                        AddSong4 = false;
                        AddSong5 = false;
                        AddSong6 = false;
                        AddSong7 = false;
                        AddSong8 = false;
                        AddSong9 = false;
                        AddSong10 = false;
                        AddSong11 = false;
                        AddSong12 = false;
                        SongOperationTxt = "";
                        AddSongName = "";
                        AddSongPersianName = "";
                        AddSongArtist = "";
                        AddSongYtLink = "";
                        AddSongSyLink = null;
                        AddSongAlbumName = "";
                        AddSongKaraokeLink = "";
                        AddSongLyrics = "";
                    }

                }
                else if (AddChannel4 && AddChannelTxtConfirm == "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟")
                {
                    TblJoinRequiredChannel requiredChannel = new TblJoinRequiredChannel();
                    requiredChannel.Name = AddChannelName;
                    requiredChannel.ChannelLink = AddChannelLink;
                    requiredChannel.ChannelId = AddChannelId;
                    context.TblJoinRequiredChannels.Add(requiredChannel);
                    context.SaveChanges();
                    await bot.SendTextMessageAsync(id, "کانال با موفقیت اضافه شد ✅", replyMarkup: keyboardMarkup);
                    AddChannel1 = false;
                    AddChannel2 = false;
                    AddChannel3 = false;
                    AddChannel4 = false;
                    DelChannel1 = false;
                    DelChannel2 = false;
                    AddChannelTxtConfirm = "";
                }
                else if (AddAdmin4 && AddAdminTxtConfirm == "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟")
                {
                    TblBotAdmin botAdmin = new TblBotAdmin();
                    botAdmin.Name = AddAdminName;
                    botAdmin.AdminChatId = Convert.ToInt64(AddAdminChatId);
                    botAdmin.RoleId = AddAdminRoleId;
                    context.TblBotAdmins.Add(botAdmin);
                    context.SaveChanges();
                    await bot.SendTextMessageAsync(id, "ادمین با موفقیت اضافه شد ✅", replyMarkup: Home);
                    Bott();
                }
                else if (SendPublicMessageConfirm && MessageToSend != "")
                {
                    foreach (TblBotUser i in botUsers)
                    {
                        await bot.SendTextMessageAsync(i.ChatId, MessageToSend, parseMode: ParseMode.MarkdownV2);
                    }
                    await bot.SendTextMessageAsync(id, "پیام شما برای تمام کاربران ربات ارسال شد", replyMarkup: Home);
                    MessageToSend = "";
                    SendPublicMessageConfirm = false;
                    Bott();
                }
                else if (Addphoto3 && AddPhotoTxtConfirm == "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟" && AddPhotoMessageId != 0)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        TblPhoto PhotoToAdd = new()
                        {
                            FromChatId = id,
                            PhotoMessageId = AddPhotoMessageId,
                            IsNew = AddphotoIsNew
                        };
                        context.TblPhotos.Add(PhotoToAdd);
                        context.SaveChanges();
                        await bot.SendTextMessageAsync(id, "عکس با موفقیت اضافه شد ✅", replyMarkup: Home, cancellationToken: cancellationToken);
                        AddPhotoMessageId = 0;
                        Addphoto3 = false;
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        Addphoto3 = false;
                        Bott();
                    }
                }
                else if(AddTalk3 && AddPhotoTxtConfirm == "آیا از صحت اطلاعات ارسال شده اطمینان دارید؟" && AddTalkMessageId is not 0)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        TblTalksOfTataloo TalkToAdd = new()
                        {
                            FromChatId = id,
                            PhotoMessageId = AddTalkMessageId,
                            IsNew = AddTalkIsNew
                        };
                        context.TblTalksOfTataloos.Add(TalkToAdd);
                        context.SaveChanges();
                        await bot.SendTextMessageAsync(id, "عکس با موفقیت اضافه شد ✅", replyMarkup: Home, cancellationToken: cancellationToken);
                        Bott();
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddTalk3 = false;
                        Bott();
                    }
                }
                else if (AddVideo3 && AddVideoCategoryId != 0 && AddVideoMessageId != 0)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        TblVideo VideoToAdd = new TblVideo();
                        VideoToAdd.FromChatId = id;
                        VideoToAdd.VideoMessageId = AddVideoMessageId;
                        VideoToAdd.CategoryId = AddVideoCategoryId;
                        if (AddVideoCaption != "")
                        {
                            VideoToAdd.Caption = AddVideoCaption;
                        }
                        context.TblVideos.Add(VideoToAdd);
                        context.SaveChanges();
                        await bot.SendTextMessageAsync(id, "ویدیو با موفقیت اضافه شد ✅", replyMarkup: Back);
                        GoToAdmin = true;
                        AddVideo3 = false;
                        AddVideo2 = false;
                        AddVideo1 = false;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddVideo3 = false;
                        Bott();
                    }
                }
                else if (AddMusicVideos3 && message.Type != MessageType.Video)
                {
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        TblMusicVideo MusicVideoToAdd = new TblMusicVideo();
                        MusicVideoToAdd.SongId = AddMusicVideoSongId;
                        MusicVideoToAdd.FromChatId = id;
                        MusicVideoToAdd.VideoMessageId = AddMusicVideoMessageId;
                        MusicVideoToAdd.Caption = AddMusicVideoCaption;
                        context.TblMusicVideos.Add(MusicVideoToAdd);
                        context.SaveChanges();
                        await bot.SendTextMessageAsync(id, "موزیک ویدیو با موفقیت اضافه شد ✅", replyMarkup: Back);
                        Bott();
                        GoToAdmin = true;
                        AddMusicVideos3 = false;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(id, "این بخش فقط مخصوص ادمین ربات است", replyMarkup: Home);
                        AddMusicVideos3 = false;
                        Bott();
                    }
                }
                else if(EditSong4 && SongtoEdit != null)
                {
                    await bot.SendTextMessageAsync(id, "گزینه مورد نظر برای ادیت را انتخاب کنید", replyMarkup: EditSong, cancellationToken: cancellationToken);
                    EditSong1 = false;
                    EditSong2 = true;
                    EditSong3 = false;
                    EditSong4 = false;
                }
                else
                {
                    await bot.SendTextMessageAsync(id, "یافت نشد", replyMarkup: Home);
                    Bott();
                    AddSong1 = false;
                    AddSong2 = false;
                    AddSong3 = false;
                    AddSong4 = false;
                    AddSong5 = false;
                    AddSong6 = false;
                    AddSong7 = false;
                    AddSong8 = false;
                    AddChannel1 = false;
                    AddChannel2 = false;
                    AddChannel3 = false;
                    AddChannel4 = false;
                    DelChannel1 = false;
                    DelChannel2 = false;
                    AddChannelTxtConfirm = "";
                }
            }
        }
        catch (System.InvalidOperationException ex)
        {
            if (AddFreeStyle2)
            {
                AddGif1 = false;
                AddHeavyText1 = false;
            }
            if (AddGif1)
            {
                AddHeavyText1 = false;
                AddFreeStyle2 = false;
            }
            if (AddHeavyText1)
            {
                AddGif1 = false;
                AddFreeStyle2 = false;
            }
            if (AddVegetarianTalk1)
            {
                AddGif1 = false;
                AddFreeStyle2 = false;
                AddHeavyText1 = false;
            }
            else
            {
                Bott();
            }
        }
    }
    if (update.CallbackQuery != null)
    {
        List<TblJoinRequiredChannel> tblJoinRequireds = context.TblJoinRequiredChannels.ToList();
        List<string> JoinedChannels = new List<string>();
        List<List<InlineKeyboardButton>> inlinekey = new List<List<InlineKeyboardButton>>();
        List<KeyboardButton> ChannelsRequird = new List<KeyboardButton>();
        var CallbackQuery = update.CallbackQuery;
        var Data = update.CallbackQuery.Data; if (Data == null) { return; }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        int messageId = update.CallbackQuery.Message.MessageId;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        long id = update.CallbackQuery.Message.Chat.Id;
        ChatMember chatMember;
        foreach (TblJoinRequiredChannel i in tblJoinRequireds)
        {
            List<InlineKeyboardButton> inlines = new List<InlineKeyboardButton>();
            inlines.Add(new InlineKeyboardButton(i.Name)
            {
                Text = i.Name,
                Url = i.ChannelLink
            });
            inlinekey.Add(inlines);
            ChannelsRequird.Add(i.Name);

            chatMember = await bot.GetChatMemberAsync(i.ChannelId, userId: id, cancellationToken: cancellationToken);
            if (chatMember.Status is ChatMemberStatus.Member or ChatMemberStatus.Administrator or ChatMemberStatus.Creator)
            {
                JoinedChannels.Add(i.Name);
            }
        }
        List<InlineKeyboardButton> ChannelRequird = new List<InlineKeyboardButton>();
        ChannelRequird.Add(new InlineKeyboardButton("عضو شدم")
        {
            Text = "عضو شدم",
            CallbackData = "عضو شدم"
        });
        inlinekey.Add(ChannelRequird);

        if (Data == "عضو شدم")
        {
            if (JoinedChannels.Count == tblJoinRequireds.Count)
            {
                if (textm == "/start")
                {
                    Bott();
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: AdminKeyboard);
                    }
                    else
                    {
                        ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(keyboardbutton);
                        await bot.SendTextMessageAsync(id, "انتخاب کنید", replyMarkup: keyboardMarkup);
                    }
                }
                else if (textm.StartsWith("/search"))
                {
                    string song = "";
                    try
                    {
                        song = textm.Substring(8);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (song.Length > 1)
                    {
                        TblSong tblSong = context.TblSongs.SingleOrDefault(i => i.Name.Contains(song) || i.PersianName.Contains(song));
                        if (tblSong != null)
                        {
                            if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null || ShowAudioFileToUsers)
                            {
                                await bot.CopyMessageAsync(id, tblSong.FromChatId, tblSong.SongMessageId);
                                if (tblSong.SyLink == null)
                                {
                                    if (tblSong.Lyrics != null)
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                    }
                                    else
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                    }
                                }
                                else
                                {
                                    if (tblSong.Lyrics != null)
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                    }
                                    else
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                    }
                                }
                            }
                            else
                            {
                                if (tblSong.SyLink == null)
                                {
                                    if (tblSong.Lyrics != null)
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                    }
                                    else
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                    }
                                }
                                else
                                {
                                    if (tblSong.Lyrics != null)
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfo);
                                    }
                                    else
                                    {
                                        await bot.SendTextMessageAsync(id, $"🔻LINK YOUTUBE 🖇\n {tblSong.YtLink}\n\n 🔻LINK SPOTIFY 🖇\n {tblSong.SyLink}\n\n 🔻LINK Karaoke 🖇\n {tblSong.KaraokeLink}", replyMarkup: SongInfoNoLyrics);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tblSong == null)
                            {
                                await bot.SendTextMessageAsync(id, "اسم آهنگ را به درستی وارد کنید");
                            }
                        }
                    }
                    else
                    {
                        if (song == "")
                        {
                            await bot.SendTextMessageAsync(id, "بعد کلمه /search فاصله دهید و سپس نام آهنگ مورد نظر را وارد کنید");
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, "آهنگی با این اسم در کارنامه امیر تتلو وجود ندارد", replyMarkup: Back);
                            Bott();
                        }
                    }
                }
                else
                {
                    Bott();
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlinekey);
                    ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(keyboardbutton);
                    if (context.TblBotAdmins.SingleOrDefault(i => i.AdminChatId == id) != null)
                    {
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {
                            ReplyKeyboardMarkup AdminKeyboard = new ReplyKeyboardMarkup(Adminkeyboardbutton);
                            await bot.SendTextMessageAsync(id, "عضویت شما تایید شد ✅", replyMarkup: AdminKeyboard);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                    else
                    {
                        if (JoinedChannels.Count == tblJoinRequireds.Count)
                        {
                            await bot.SendTextMessageAsync(id, "عضویت شما تایید شد ✅", replyMarkup: keyboardMarkup);

                        }
                        else
                        {
                            await bot.SendTextMessageAsync(id, $"در کانال های زیر عضو شوید", replyMarkup: inlineKeyboard);
                        }
                    }
                }
            }
            else
            {
                await bot.AnswerCallbackQueryAsync(callbackQueryId: update.CallbackQuery.Id, "هنوز در همه کانال ها عضو نشدید", true);
            }
        }

    }
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
