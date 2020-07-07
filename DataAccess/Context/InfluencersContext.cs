using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Data.Models;

namespace DataAccess.Context
{
    public partial class InfluencersContext : DbContext
    {
        #region Consturctors        
        
        public InfluencersContext(DbContextOptions<InfluencersContext> options)
            : base(options)
        {
        }

        #endregion

        #region Public Properties
        
        public virtual DbSet<Article> Article { get; set; }
       
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        
        public virtual DbSet<Author> Author { get; set; }
        
        public virtual DbSet<Tag> Tag { get; set; }

        public virtual DbSet<Contact> Contact { get; set; }

        #endregion

        #region Override Methods
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorNickname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__AuthorI__267ABA7A");                
            });

            modelBuilder.Entity<ArticleTags>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.TagId })
                    .HasName("PK__ArticleT__4A35BF72F817F599");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticleTa__Artic__37A5467C");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticleTa__TagId__38996AB5");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);                
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(c => c.Article)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.ArticleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 

        #endregion
    }
}
