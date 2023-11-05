﻿// <auto-generated />
using System;
using Academic_Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Academic_Blog.Domain.Migrations
{
    [DbContext(typeof(AcademicBlogContext))]
    [Migration("20231028120835_AddReportTable")]
    partial class AddReportTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Academic_Blog.Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountFieldMappingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("NumberOfBlogs")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AccountFieldMappingId")
                        .IsUnique()
                        .HasFilter("[AccountFieldMappingId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserName" }, "UX_Account_Username");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.AccountAwardMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AwardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("LecturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AwardId");

                    b.HasIndex("LecturerId");

                    b.HasIndex("StudentId");

                    b.ToTable("AccountAwardMapping", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.AccountFieldMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("AccountFieldMappings");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.BannedInfor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateBanned")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("BannedInfors");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewFromReviewer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Thumbnal_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid?>("ReplyToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CommentorId");

                    b.HasIndex("ReplyToId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Field", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("ForUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FromUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ForUserId");

                    b.HasIndex("FromUserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.TrackingViewBlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrackingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrackingViewBlog", (string)null);
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Account", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.AccountFieldMapping", "AccountFieldMapping")
                        .WithOne("Account")
                        .HasForeignKey("Academic_Blog.Domain.Models.Account", "AccountFieldMappingId");

                    b.HasOne("Academic_Blog.Domain.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ACCOUNT_ROLE");

                    b.Navigation("AccountFieldMapping");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.AccountAwardMapping", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Award", "Award")
                        .WithMany("AccountAwardMappings")
                        .HasForeignKey("AwardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academic_Blog.Domain.Models.Account", "Lecturer")
                        .WithMany("LecturerAwardMappings")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Lecturer_Award");

                    b.HasOne("Academic_Blog.Domain.Models.Account", "Student")
                        .WithMany("StudentAwardMappings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Student_Award");

                    b.Navigation("Award");

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.AccountFieldMapping", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Field", "Field")
                        .WithMany("AccountFieldMappings")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.BannedInfor", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Account", "Account")
                        .WithMany("BannedInfors")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_Account_BannedInfor");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Blog", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Account", "Author")
                        .WithMany("AuthorBlogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Author_Blog");

                    b.HasOne("Academic_Blog.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academic_Blog.Domain.Models.Account", "Reviewer")
                        .WithMany("ReviewBlogs")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Reviewer_Blog");

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Category", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Field", "Field")
                        .WithMany("Categories")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Comment", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Academic_Blog.Domain.Models.Account", "Commentor")
                        .WithMany("Comments")
                        .HasForeignKey("CommentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academic_Blog.Domain.Models.Comment", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");

                    b.Navigation("Blog");

                    b.Navigation("Commentor");

                    b.Navigation("ReplyTo");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Notification", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Account", "ForUser")
                        .WithMany("MyNotifications")
                        .HasForeignKey("ForUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_My_Notification");

                    b.HasOne("Academic_Blog.Domain.Models.Account", "FromUser")
                        .WithMany("MyImpactsNotifications")
                        .HasForeignKey("FromUserId")
                        .HasConstraintName("FK_Impact_Notification");

                    b.Navigation("ForUser");

                    b.Navigation("FromUser");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Report", b =>
                {
                    b.HasOne("Academic_Blog.Domain.Models.Comment", "Comment")
                        .WithMany("Reports")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Account", b =>
                {
                    b.Navigation("AuthorBlogs");

                    b.Navigation("BannedInfors");

                    b.Navigation("Comments");

                    b.Navigation("LecturerAwardMappings");

                    b.Navigation("MyImpactsNotifications");

                    b.Navigation("MyNotifications");

                    b.Navigation("ReviewBlogs");

                    b.Navigation("StudentAwardMappings");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.AccountFieldMapping", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Award", b =>
                {
                    b.Navigation("AccountAwardMappings");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Comment", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Field", b =>
                {
                    b.Navigation("AccountFieldMappings");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Academic_Blog.Domain.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
