using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot5.Models;
using TelegramBot5.Models.ViewModels;
using static TelegramBot5.TelegramPropertys;
using Newtonsoft.Json;

namespace TelegramBot5
{
    public class Propertys
    {
        public static int forTattoobut { get; set; }
        public static int forTattoobut2 { get; set; }
        //.......
        public static bool AlbumsClicked { get; set; }
        public static bool AlbumsNameEqualsSongName { get; set; }
        public static string SelectedAlbumName { get; set; }
        public static bool RowOneisZero { get; set; }
        public static bool GoToAdmin { get; set; }
        public static bool BackToAlbumMenu { get; set; }

        //SongOperation
        public static string SongOperationTxt { get; set; }
        public static string AddSongName { get; set; }
        public static string AddSongPersianName { get; set; }
        public static string AddSongArtist { get; set; }
        public static string AddSongYtLink { get; set; }
        public static string? AddSongSyLink { get; set; }
        public static string AddSongAlbumName { get; set; }
        public static int AddSongMessageId { get; set; }
        public static int AddSongCoverMessageId { get; set; }
        public static int AddSongEmptyCoverMessageId { get; set; }
        public static string AddSongKaraokeLink { get; set; }
        public static string AddSongLyrics { get; set; }
        public static int SongId { get; set; }//For Send Song Covers
        public static bool CanSendSongInfo { get; set; }
        public static bool AddSong1 { get; set; }
        public static bool AddSong2 { get; set; }
        public static bool AddSong3 { get; set; }
        public static bool AddSong4 { get; set; }
        public static bool AddSong5 { get; set; }
        public static bool AddSong6 { get; set; }
        public static bool AddSong7 { get; set; }
        public static bool AddSong8 { get; set; }
        public static bool AddSong9 { get; set; }
        public static bool AddSong10 { get; set; }
        public static bool AddSong11 { get; set; }
        public static bool AddSong12 { get; set; }
        public static string addSongTxtEn { get; set; }
        public static string addSongTxtFa { get; set; }
        public static string addSongTxtArt { get; set; }
        public static string addSongTxtYtLink { get; set; }
        public static string addSongTxtSyLink { get; set; }
        public static string addSongTxtSendSong { get; set; }
        public static string addSongTxtAlbumName { get; set; }
        public static string addSongtxtCover { get; set; }
        public static string addSongtxtEmptyCover { get; set; }
        public static string addSongtxtKaraoke { get; set; }
        public static string addSongtxtLyrics { get; set; }
        public static string addSongtxtKootahLyrics { get; set; }
        public static string addSongtxtConfirm { get; set; }
        //deleteSong
        public static bool DelSong1 { get; set; }
        public static bool DelSong2 { get; set; }
        public static string DeleteSongName { get; set; }
        public static string DelSongtxtName { get; set; }
        public static string DelSongtxtInfo { get; set; }
        //editSong
        public static TblSong? SongtoEdit { get; set; }
        public static string EditSongName { get; set; }
        public static bool EditSong1 { get; set; }
        public static bool EditSong2 { get; set; }
        public static bool EditSong3 { get; set; }
        public static bool EditSong4 { get; set; }
        public static bool EditSongPersianName { get; set; }
        public static bool EditSongLyrics { get; set; }
        public static bool EditSongKaraoke { get; set; }
        public static bool EditSongEmptyCover { get; set; }
        //AddAlbum
        public static string AddAlbumName { get; set; }
        public static int AddAlbumCoverMessageId { get; set; }
        public static bool AddAlbum2 { get; set; }
        public static bool AddAlbum3 { get; set; }
        public static string AddAlbumTxtName { get; set; }
        public static string AddAlbumTxtCover { get; set; }
        //............................................................

        //AlbumSection
        public static bool Albums1 { get; set; }
        public static bool Albums2 { get; set; }
        //RequirdChannelOperation
        public static bool ChannelOperation1 { get; set; }
        public static bool AddChannel1 { get; set; }
        public static bool AddChannel2 { get; set; }
        public static bool AddChannel3 { get; set; }
        public static bool AddChannel4 { get; set; }
        public static bool DelChannel1 { get; set; }
        public static bool DelChannel2 { get; set; }
        public static string DelChannelName { get; set; }
        public static string AddChannelName { get; set; }
        public static string AddChannelLink { get; set; }
        public static long AddChannelId { get; set; }
        public static string ChannelOperation { get; set; }
        public static string AddChannelTxtName { get; set; }
        public static string AddChannelTxtLink { get; set; }
        public static string AddChannelTxtId { get; set; }
        public static string AddChannelTxtConfirm { get; set; }
        public static string DelChannelTxtId { get; set; }
        public static string DelChannelTxtConfirm { get; set; }

        //............................................................
        //TattooMeans
        public static bool TattooMeans1 { get; set; }
        public static bool AddTattoo1 { get; set; }
        public static bool AddTattoo2 { get; set; }
        public static bool AddTattoo3 { get; set; }
        public static int AddTattooMessageId { get; set; }
        public static string AddTattooTxtPhoto { get; set; }
        public static string AddTattooTxtName { get; set; }
        public static string AddTattooTxtExplanation { get; set; }
        public static string AddTattooExplanation { get; set; }
        public static string AddTattooName { get; set; }

        //..............................................
        //HeavyText
        public static bool HeavyText1 { get; set; }
        public static bool AddHeavyText1 { get; set; }
        //........................
        //AdminOperation
        public static bool AdminOperation { get; set; }
        public static bool DelAdmin1 { get; set; }
        public static bool DelAdmin2 { get; set; }
        public static bool AddAdmin1 { get; set; }
        public static bool AddAdmin2 { get; set; }
        public static bool AddAdmin3 { get; set; }
        public static bool AddAdmin4 { get; set; }
        public static long DeleteAdminChatId { get; set; }
        public static string AddAdminName { get; set; }
        public static string AddAdminChatId { get; set; }
        public static int AddAdminRoleId { get; set; }
        public static string AddAdminRole { get; set; }
        public static string AddAdminTxtName { get; set; }
        public static string AddAdminTxtChatId { get; set; }
        public static string AddAdminTxtRole { get; set; }
        public static string AddAdminTxtConfirm { get; set; }
        public static string DelTxtAdmin { get; set; }
        public static string DelTxtAdminConfirm { get; set; }
        //........................................
        //Photos
        public static bool photo1 { get; set; }
        public static bool photo2 { get; set; }
        public static bool Oldphoto { get; set; }
        public static bool Newphoto { get; set; }
        public static bool Addphoto1 { get; set; }
        public static bool Addphoto2 { get; set; }
        public static bool Addphoto3 { get; set; }
        public static bool AddphotoIsNew { get; set; }
        public static int AddPhotoMessageId { get; set; }
        public static string AddPhotoOldOrNew { get; set; }
        public static string AddPhotoTxt { get; set; }
        public static string AddPhotoTxtConfirm { get; set; }
        //..........................................
        //Videos
        public static bool Videos1 { get; set; }
        public static bool Videos2 { get; set; }
        public static bool MusicVideos1 { get; set; }
        public static bool AddMusicVideos1 { get; set; }
        public static bool AddMusicVideos2 { get; set; }
        public static bool AddMusicVideos3 { get; set; }
        public static bool AddVideo1 { get; set; }
        public static bool AddVideo2 { get; set; }
        public static bool AddVideo3 { get; set; }
        public static int AddVideoCategoryId { get; set; }
        public static int AddVideoMessageId { get; set; }
        public static int AddMusicVideoSongId { get; set; }
        public static int AddMusicVideoMessageId = 0;
        public static string AddMusicVideoSongName { get; set; }
        public static string AddMusicVideoCaption { get; set; }
        public static string AddMusicVideoTxtConfirm { get; set; }
        public static string AddVideoCaption { get; set; }
        public static string AddMusicVideoTxtName { get; set; }
        public static string AddVideoTxtConfirm { get; set; }
        public static string AddVideoCategoryTxt { get; set; }
        public static string AddVideoTxt { get; set; }
        //.................................................
        //Gif
        public static bool Gif1 { get; set; }
        public static bool AddGif1 { get; set; }
        public static string AddGifTxt { get; set; }
        //freeStyles
        public static bool FreeStyle1 { get; set; }
        public static bool FreeStyle2 { get; set; }
        public static bool OldFreeStyle { get; set; }
        public static bool NewFreeStyle { get; set; }
        public static bool AddFreeStyleTimeToPublic = true;
        public static bool AddFreeStyle1 { get; set; }
        public static bool AddFreeStyle2 { get; set; }
        public static List<int> MessageIds = new List<int>();
        public static string AddFreestyleTxt { get; set; }
        //Send a public message
        public static bool SendPublicMessage { get; set; }
        public static bool SendPublicMessageConfirm { get; set; }
        public static string MessageToSend { get; set; }
        public static string SendPublicMessageTxtConfirm { get; set; }
        //VegeterianTalk
        public static string VegetarianTalkTxt { get; set; }
        public static bool VegetarianTalk1 { get; set; }
        public static bool AddVegetarianTalk1 { get; set; }

        //TalksOfTataloo
        public static bool TatalTalk1 { get; set; }
        public static bool TatalTalk2 { get; set; }
        public static bool OldlTalk { get; set; }
        public static bool NewTalk { get; set; }
        public static bool AddTalk1 { get; set; }
        public static bool AddTalk2 { get; set; }
        public static bool AddTalk3 { get; set; }
        public static int AddTalkMessageId { get; set; }
        public static bool AddTalkIsNew { get; set; }
        //ManageUsersAccess
        public static bool ManageUsersAccess1 { get; set; }
        public static void Bott()
        {
            forTattoobut = 0;
            forTattoobut2 = -4;
            //..
            AlbumsClicked = false;
            AlbumsNameEqualsSongName = false;
            SelectedAlbumName = "";
            RowOneisZero = false;
            GoToAdmin = false;
            BackToAlbumMenu = false;
            AddSongName = "";
            AddSongPersianName = "";
            AddSongArtist = "";
            AddSongYtLink = "";
            AddSongSyLink = null;
            AddSongAlbumName = "";
            AddSongMessageId = 0;
            AddSongCoverMessageId = 0;
            AddSongEmptyCoverMessageId = 0;
            AddSongKaraokeLink = "";
            AddSongLyrics = "";
            SongId = 0;
            CanSendSongInfo =
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
            DelSong1 = false;
            DelSong2 = false;
            DeleteSongName = "";
            DelSongtxtName = "";
            DelSongtxtInfo = "";
            EditSongName = "";
            SongtoEdit = null;
            EditSong1 = false;
            EditSong2 = false;
            EditSong3 = false;
            EditSong4 = false;
            //..
            AddAlbumName = "";
            AddAlbumCoverMessageId = 0;
            AddAlbum2 = false;
            AddAlbum3 = false;
            //..
            Albums1 = false;
            Albums2 = false;
            //..
            ChannelOperation1 = false;
            AddChannel1 = false;
            AddChannel2 = false;
            AddChannel3 = false;
            AddChannel4 = false;
            DelChannel1 = false;
            DelChannel2 = false;
            DelChannelName = "";
            AddChannelName = "";
            AddChannelLink = "";
            AddChannelId = 0;
            ChannelOperation = "";
            //..
            TattooMeans1 = false;
            AddTattoo1 = false;
            AddTattoo2 = false;
            AddTattoo3 = false;
            AddTattooMessageId = 0;
            AddTattooExplanation = "";
            AddTattooName = "";
            //..
            HeavyText1 = false;
            AddHeavyText1 = false;
            //..
            AdminOperation = false;
            DelAdmin1 = false;
            DelAdmin2 = false;
            AddAdmin1 = false;
            AddAdmin2 = false;
            AddAdmin3 = false;
            AddAdmin4 = false;
            DeleteAdminChatId = 0;
            AddAdminName = "";
            AddAdminChatId = "";
            AddAdminRoleId = 0;
            AddAdminRole = "";
            //..
            photo1 = false;
            photo2 = false;
            Oldphoto = false;
            Newphoto = false;
            Addphoto1 = false;
            Addphoto2 = false;
            Addphoto3 = false;
            AddphotoIsNew = false;
            AddPhotoMessageId = 0;
            AddPhotoOldOrNew = "";
            //..
            Videos1 = false;
            Videos2 = false;
            MusicVideos1 = false;
            AddMusicVideos1 = false;
            AddMusicVideos2 = false;
            AddMusicVideos3 = false;
            AddVideo1 = false;
            AddVideo2 = false;
            AddVideo3 = false;
            AddVideoCategoryId = 0;
            AddVideoMessageId = 0;
            AddMusicVideoSongId = 0;
            AddMusicVideoMessageId = 0;
            AddMusicVideoSongName = "";
            AddMusicVideoCaption = "";
            Gif1 = false;
            AddGif1 = false;
            //..
            FreeStyle1 = false;
            FreeStyle2 = false;
            OldFreeStyle = false;
            NewFreeStyle = false;
            AddFreeStyleTimeToPublic = true;
            AddFreeStyle1 = false;
            AddFreeStyle2 = false;
            MessageIds.Clear();
            AddFreestyleTxt = "";
            //..
            SendPublicMessage = false;
            SendPublicMessageConfirm = false;
            MessageToSend = "";
            //..
            VegetarianTalkTxt = "";
            VegetarianTalk1 = false;
            AddVegetarianTalk1 = false;
            //..
            TatalTalk1 = false;
            TatalTalk2 = false;
            OldlTalk = false;
            NewTalk = false;
            AddTalk1 = false;
            AddTalk1 = false;
            AddTalk3 = false;
            AddTalkMessageId = 0;
            AddTalkIsNew = true;
            //..
            ManageUsersAccess1 = false;
        }
        public static string textm { get; set; }
        public static bool ShowAudioFileToUsers { get; set; }
        public static bool ShowVideoFilesToUsers { get; set; }

        
        public static void GenerateAlbumsBtn(List<List<KeyboardButton>> albumButton, TatalooBotContext context)
        {
            List<TblAlbum> TblAlbum = context.TblAlbums.ToList();
            int AlbomCount = TblAlbum.Count;
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            int RowCount = 0;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            if (AlbomCount > 0)
            {
                if(AlbomCount % 3 == 0)
                {
                    RowCount = AlbomCount / 3;
                }
                else
                {
                    RowCount = ((AlbomCount / 3 + 1) * 3) / 3;
                }
                for(int i = 1; i <= RowCount; i++)
                {
                    List<KeyboardButton> Row = new List<KeyboardButton>();
                    List<TblAlbum> ARow = context.TblAlbums.Skip((i - 1) * 3).Take(3).ToList();
                    foreach(TblAlbum album in ARow)
                    {
                        Row.Add(album.Name);
                    }
                    albumButton.Add(Row);
                }
            }
            else
            {
                RowOneisZero = true;
            }
        }
        public static void GenerateMusicVideoBtn(List<List<KeyboardButton>> KeyboardButton, TatalooBotContext context)
        {
            List<KeyboardButton> back = new List<KeyboardButton>();
            back.Add("بازگشت");
            List<TblMusicVideo> musicVideos = context.TblMusicVideos.ToList();
            int musicVideosCount = musicVideos.Count;
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            int RowCount = 0;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            if (musicVideosCount > 0)
            {
                if (musicVideosCount % 3 == 0)
                {
                    RowCount = musicVideosCount / 3;
                }
                else
                {
                    RowCount = ((musicVideosCount / 3 + 1) * 3) / 3;
                }
                for (int i = 1; i <= RowCount; i++)
                {
                    List<KeyboardButton> Row = new List<KeyboardButton>();
                    List<TblMusicVideo> ARow = context.TblMusicVideos.Skip((i - 1) * 3).Take(3).ToList();
                    foreach (TblMusicVideo musicVideo in ARow)
                    {
                        Row.Add(musicVideo.Song.Name);
                    }
                    KeyboardButton.Add(back);
                    KeyboardButton.Add(Row);
                }
            }
            else
            {
                RowOneisZero = true;
            }
        }
        public static void GenerateSongBtn(List<List<KeyboardButton>> SongButton, List<TblSong> Songss)
        {

            List<KeyboardButton> Back = new List<KeyboardButton>();
            Back.Add("بازگشت");
            List<KeyboardButton> RowOne = new List<KeyboardButton>();
            List<KeyboardButton> RowTwo = new List<KeyboardButton>();
            List<KeyboardButton> RowThree = new List<KeyboardButton>();
            List<KeyboardButton> RowFour = new List<KeyboardButton>();
            List<KeyboardButton> RowFive = new List<KeyboardButton>();
            List<KeyboardButton> RowSix = new List<KeyboardButton>();
            List<KeyboardButton> RowSeven = new List<KeyboardButton>();
            List<KeyboardButton> RowEight = new List<KeyboardButton>();
            if (Songss.Count >= 20)
            {
                foreach (TblSong i in Songss)
                {
                    if (RowOne.Count < 4)
                    {
                        RowOne.Add(i.Name);
                    }
                    else if (RowTwo.Count < 4)
                    {
                        RowTwo.Add(i.Name);
                    }
                    else if (RowThree.Count < 4)
                    {
                        RowThree.Add(i.Name);
                    }
                    else if (RowFour.Count < 4)
                    {
                        RowFour.Add(i.Name);
                    }
                    else if (RowFive.Count < 4)
                    {
                        RowFive.Add(i.Name);
                    }
                    else if (RowSix.Count < 4)
                    {
                        RowSix.Add(i.Name);
                    }
                    else if (RowSeven.Count < 4)
                    {
                        RowSeven.Add(i.Name);
                    }
                    else if (RowEight.Count < 4)
                    {
                        RowEight.Add(i.Name);
                    }
                }
            }
            else if (Songss.Count < 20)
            {
                foreach (TblSong i in Songss)
                {
                    if (RowOne.Count < 3)
                    {
                        RowOne.Add(i.Name);
                    }
                    else if (RowTwo.Count < 3)
                    {
                        RowTwo.Add(i.Name);
                    }
                    else if (RowThree.Count < 3)
                    {
                        RowThree.Add(i.Name);
                    }
                    else if (RowFour.Count < 3)
                    {
                        RowFour.Add(i.Name);
                    }
                    else if (RowFive.Count < 3)
                    {
                        RowFive.Add(i.Name);
                    }
                    else if (RowSix.Count < 3)
                    {
                        RowSix.Add(i.Name);
                    }
                    else if (RowSeven.Count < 3)
                    {
                        RowSeven.Add(i.Name);
                    }
                }
            }
            SongButton.Add(RowOne);
            SongButton.Add(RowTwo);
            SongButton.Add(RowThree);
            SongButton.Add(RowFour);
            SongButton.Add(RowFive);
            SongButton.Add(RowSix);
            SongButton.Add(RowSeven);
            SongButton.Add(RowEight);
            SongButton.Add(Back);
        }
        public static void GenerateTattooBtn(List<List<KeyboardButton>> AllBtn, List<TblTattooMean> Tattoo)
        {
            List<TblTattooMean> sublist = new List<TblTattooMean>();
            List<KeyboardButton> Row1 = new List<KeyboardButton>();
            List<KeyboardButton> Row2 = new List<KeyboardButton>();
            forTattoobut += 4;
            forTattoobut2 += 4;
            for (int i = forTattoobut2; i <= forTattoobut; i += 4)
            {
                Row2.Add("بعدی");
                Row2.Add("صفحه اصلی");
                sublist = Tattoo.Skip(i).Take(4).ToList();
                foreach (TblTattooMean a in sublist)
                {
                    Row1.Add(a.Name);
                }
                if (Row1.Count < 4)
                {
                    Row2.Clear();
                    Row1.Add("بازگشت");
                    Row1.Reverse();
                }
                AllBtn.Add(Row1);
                AllBtn.Add(Row2);
                break;
            }
        }
        public static string CapitalizeWords(string input)
        {
            if (input != null)
            {
                // Split the input string into an array of words
                string[] words = input.Split(' ');

                // Create a StringBuilder to store the capitalized words
                StringBuilder result = new StringBuilder();

                // Iterate through each word and capitalize the first letter
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        // Capitalize the first letter of the word and append it to the result
                        result.Append(char.ToUpper(word[0]) + word.Substring(1));
                    }

                    // Append a space after each word
                    result.Append(" ");
                }

                // Remove any trailing spaces and return the capitalized string
                return result.ToString().Trim();
            }
            else
            {
                return null;
            }
        }
        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}
