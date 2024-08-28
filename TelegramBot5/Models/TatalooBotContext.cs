using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TelegramBot5.Models;

public partial class TatalooBotContext : DbContext
{
    public TatalooBotContext()
    {
    }

    public TatalooBotContext(DbContextOptions<TatalooBotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdminRol> TblAdminRols { get; set; }

    public virtual DbSet<TblAlbum> TblAlbums { get; set; }

    public virtual DbSet<TblAudioUrl> TblAudioUrls { get; set; }

    public virtual DbSet<TblBotAdmin> TblBotAdmins { get; set; }

    public virtual DbSet<TblBotUser> TblBotUsers { get; set; }

    public virtual DbSet<TblFreeStyle> TblFreeStyles { get; set; }

    public virtual DbSet<TblGif> TblGifs { get; set; }

    public virtual DbSet<TblHeavyText> TblHeavyTexts { get; set; }

    public virtual DbSet<TblJoinRequiredChannel> TblJoinRequiredChannels { get; set; }

    public virtual DbSet<TblMusicVideo> TblMusicVideos { get; set; }

    public virtual DbSet<TblPaymentOfMusicRight> TblPaymentOfMusicRights { get; set; }

    public virtual DbSet<TblPhoto> TblPhotos { get; set; }

    public virtual DbSet<TblSong> TblSongs { get; set; }

    public virtual DbSet<TblTalksOfTataloo> TblTalksOfTataloos { get; set; }

    public virtual DbSet<TblTattooMean> TblTattooMeans { get; set; }

    public virtual DbSet<TblVegetarianTalk> TblVegetarianTalks { get; set; }

    public virtual DbSet<TblVideo> TblVideos { get; set; }

    public virtual DbSet<VideoCategory> VideoCategories { get; set; }
    public string MyConnectionString { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(MyConnectionString);//"Data Source=.;Initial Catalog=TatalooBot;Integrated Security=True;Encrypt=False"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBotAdmin>(entity =>
        {
            entity.Property(e => e.RoleId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Role).WithMany(p => p.TblBotAdmins).HasConstraintName("FK_TblBotAdmins_TblAdminRol1");
        });

        modelBuilder.Entity<TblFreeStyle>(entity =>
        {
            entity.Property(e => e.TimeToPublic).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblHeavyText>(entity =>
        {
            entity.HasOne(d => d.Song).WithMany(p => p.TblHeavyTexts).HasConstraintName("FK_TblHeavyTexts_TblSongs");
        });

        modelBuilder.Entity<TblMusicVideo>(entity =>
        {
            entity.HasOne(d => d.Song).WithMany(p => p.TblMusicVideos).HasConstraintName("FK_TblMusicVideos_TblSongs");
        });

        modelBuilder.Entity<TblPhoto>(entity =>
        {
            entity.Property(e => e.IsNew).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblSong>(entity =>
        {
            entity.HasOne(d => d.Album).WithMany(p => p.TblSongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblSongs_TblAlbums");
        });

        modelBuilder.Entity<TblTalksOfTataloo>(entity =>
        {
            entity.Property(e => e.IsNew).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblVideo>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.TblVideos).HasConstraintName("FK_TblVideos_VideoCategory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
