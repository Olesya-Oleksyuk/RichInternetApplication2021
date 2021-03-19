using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities;

namespace ToDoList.Infrastructure.Data
{
    public class BaseProjectContext : DbContext
    {
        public BaseProjectContext(DbContextOptions<BaseProjectContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteItem> NoteItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Note>(ConfigureNotes);
            builder.Entity<NoteItem>(ConfigureNoteItems);
            builder.Entity<User>(ConfigureUsers);
        }

        private void ConfigureNotes(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        private void ConfigureNoteItems(EntityTypeBuilder<NoteItem> builder)
        {
            builder.ToTable("NoteItems");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(b => b.Note)
                .WithMany(u => u.NoteItems)
                .HasForeignKey(b => b.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureUsers(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
           
        }
    }
}
