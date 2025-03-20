using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trial_SubjectManager.Models;

public partial class YourDbContext : DbContext
{
    public YourDbContext()
    {
    }

    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SubTopic> SubTopics { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubTopic__3214EC07789F7171");

            entity.ToTable("SubTopic");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Topic).WithMany(p => p.SubTopics)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_SubTopic_Topic");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC07D654B7BB");

            entity.ToTable("Subject");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Topic__3214EC07644E6BD0");

            entity.ToTable("Topic");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Subject).WithMany(p => p.Topics)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Topic_Subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
