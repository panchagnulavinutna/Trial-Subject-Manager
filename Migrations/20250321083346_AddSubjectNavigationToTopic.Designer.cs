﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trial_SubjectManager.Models;

#nullable disable

namespace Trial_SubjectManager.Migrations
{
    [DbContext(typeof(YourDbContext))]
    [Migration("20250321083346_AddSubjectNavigationToTopic")]
    partial class AddSubjectNavigationToTopic
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trial_SubjectManager.Models.SubTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__SubTopic__3214EC07789F7171");

                    b.HasIndex("TopicId");

                    b.ToTable("SubTopic", (string)null);
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Subject__3214EC07D654B7BB");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Topic__3214EC07644E6BD0");

                    b.HasIndex("SubjectId");

                    b.ToTable("Topic", (string)null);
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.SubTopic", b =>
                {
                    b.HasOne("Trial_SubjectManager.Models.Topic", "Topic")
                        .WithMany("SubTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SubTopic_Topic");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.Topic", b =>
                {
                    b.HasOne("Trial_SubjectManager.Models.Subject", "Subject")
                        .WithMany("Topics")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Topic_Subject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.Subject", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Trial_SubjectManager.Models.Topic", b =>
                {
                    b.Navigation("SubTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
