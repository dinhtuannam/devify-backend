﻿// <auto-generated />
using System;
using Devify.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devify.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240110081604_database-v1.0.1")]
    partial class databasev101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Devify.Entity.SqlCategory", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_categories");
                });

            modelBuilder.Entity("Devify.Entity.SqlChapter", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("courseid")
                        .HasColumnType("bigint");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isactivated")
                        .HasColumnType("boolean");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("step")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.ToTable("tb_chapters");
                });

            modelBuilder.Entity("Devify.Entity.SqlComment", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("lessonid")
                        .HasColumnType("bigint");

                    b.Property<long>("parent")
                        .HasColumnType("bigint");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("lessonid");

                    b.HasIndex("userid");

                    b.ToTable("tb_comments");
                });

            modelBuilder.Entity("Devify.Entity.SqlCourse", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("categoryid")
                        .HasColumnType("bigint");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isactivated")
                        .HasColumnType("boolean");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<long>("purchases")
                        .HasColumnType("bigint");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.HasIndex("userid");

                    b.ToTable("tb_courses");
                });

            modelBuilder.Entity("Devify.Entity.SqlDetailOrder", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("courseid")
                        .HasColumnType("bigint");

                    b.Property<long?>("orderid")
                        .HasColumnType("bigint");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.HasIndex("orderid");

                    b.ToTable("tb_detail_orders");
                });

            modelBuilder.Entity("Devify.Entity.SqlLanguage", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_languages");
                });

            modelBuilder.Entity("Devify.Entity.SqlLesson", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("Chapterid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isactivated")
                        .HasColumnType("boolean");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("step")
                        .HasColumnType("integer");

                    b.Property<string>("video")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Chapterid");

                    b.ToTable("tb_lessons");
                });

            modelBuilder.Entity("Devify.Entity.SqlLevel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_levels");
                });

            modelBuilder.Entity("Devify.Entity.SqlNotification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("total")
                        .HasColumnType("double precision");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("tb_orders");
                });

            modelBuilder.Entity("Devify.Entity.SqlToken", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("accessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("expiredTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isExpired")
                        .HasColumnType("boolean");

                    b.Property<string>("refreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("tb_token");
                });

            modelBuilder.Entity("Devify.Entity.SqlUser", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("about")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("displayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("social")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_users");
                });

            modelBuilder.Entity("SqlCourseSqlLanguage", b =>
                {
                    b.Property<long>("coursesid")
                        .HasColumnType("bigint");

                    b.Property<long>("languagesid")
                        .HasColumnType("bigint");

                    b.HasKey("coursesid", "languagesid");

                    b.HasIndex("languagesid");

                    b.ToTable("SqlCourseSqlLanguage");
                });

            modelBuilder.Entity("SqlCourseSqlLevel", b =>
                {
                    b.Property<long>("coursesid")
                        .HasColumnType("bigint");

                    b.Property<long>("levelsid")
                        .HasColumnType("bigint");

                    b.HasKey("coursesid", "levelsid");

                    b.HasIndex("levelsid");

                    b.ToTable("SqlCourseSqlLevel");
                });

            modelBuilder.Entity("Devify.Entity.SqlChapter", b =>
                {
                    b.HasOne("Devify.Entity.SqlCourse", "course")
                        .WithMany("chapters")
                        .HasForeignKey("courseid");

                    b.Navigation("course");
                });

            modelBuilder.Entity("Devify.Entity.SqlComment", b =>
                {
                    b.HasOne("Devify.Entity.SqlLesson", "lesson")
                        .WithMany("Comments")
                        .HasForeignKey("lessonid");

                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("lesson");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlCourse", b =>
                {
                    b.HasOne("Devify.Entity.SqlCategory", "category")
                        .WithMany("courses")
                        .HasForeignKey("categoryid");

                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("courses")
                        .HasForeignKey("userid");

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlDetailOrder", b =>
                {
                    b.HasOne("Devify.Entity.SqlCourse", "course")
                        .WithMany("orders")
                        .HasForeignKey("courseid");

                    b.HasOne("Devify.Entity.SqlOrder", "order")
                        .WithMany("DetailOrders")
                        .HasForeignKey("orderid");

                    b.Navigation("course");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Devify.Entity.SqlLesson", b =>
                {
                    b.HasOne("Devify.Entity.SqlChapter", "Chapter")
                        .WithMany("lessons")
                        .HasForeignKey("Chapterid");

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Devify.Entity.SqlNotification", b =>
                {
                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("Notifications")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("Orders")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlToken", b =>
                {
                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("tokens")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SqlCourseSqlLanguage", b =>
                {
                    b.HasOne("Devify.Entity.SqlCourse", null)
                        .WithMany()
                        .HasForeignKey("coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devify.Entity.SqlLanguage", null)
                        .WithMany()
                        .HasForeignKey("languagesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SqlCourseSqlLevel", b =>
                {
                    b.HasOne("Devify.Entity.SqlCourse", null)
                        .WithMany()
                        .HasForeignKey("coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devify.Entity.SqlLevel", null)
                        .WithMany()
                        .HasForeignKey("levelsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Devify.Entity.SqlCategory", b =>
                {
                    b.Navigation("courses");
                });

            modelBuilder.Entity("Devify.Entity.SqlChapter", b =>
                {
                    b.Navigation("lessons");
                });

            modelBuilder.Entity("Devify.Entity.SqlCourse", b =>
                {
                    b.Navigation("chapters");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("Devify.Entity.SqlLesson", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("Devify.Entity.SqlUser", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Orders");

                    b.Navigation("courses");

                    b.Navigation("tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
