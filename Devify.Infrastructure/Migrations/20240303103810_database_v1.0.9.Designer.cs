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
    [Migration("20240303103810_database_v1.0.9")]
    partial class database_v109
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Devify.Entity.SqlCart", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("discountid")
                        .HasColumnType("bigint");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("discountid");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("tb_carts");
                });

            modelBuilder.Entity("Devify.Entity.SqlCategory", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

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
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

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
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

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
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

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

                    b.Property<bool>("issale")
                        .HasColumnType("boolean");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<long>("purchases")
                        .HasColumnType("bigint");

                    b.Property<double>("salePrice")
                        .HasColumnType("double precision");

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

            modelBuilder.Entity("Devify.Entity.SqlDiscount", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("expiredTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("isDelete")
                        .HasColumnType("boolean");

                    b.Property<double>("minimum")
                        .HasColumnType("double precision");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.Property<double>("value")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("tb_discounts");
                });

            modelBuilder.Entity("Devify.Entity.SqlFile", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("tb_files");
                });

            modelBuilder.Entity("Devify.Entity.SqlLanguage", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

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

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("chapterid")
                        .HasColumnType("bigint");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("courseid")
                        .HasColumnType("bigint");

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

                    b.HasIndex("chapterid");

                    b.HasIndex("courseid");

                    b.ToTable("tb_lessons");
                });

            modelBuilder.Entity("Devify.Entity.SqlLevel", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

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
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

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

                    b.ToTable("tb_notifications");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("discountid")
                        .HasColumnType("bigint");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<double>("sale")
                        .HasColumnType("double precision");

                    b.Property<double>("total")
                        .HasColumnType("double precision");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("discountid");

                    b.HasIndex("userid");

                    b.ToTable("tb_orders");
                });

            modelBuilder.Entity("Devify.Entity.SqlRating", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("courseid")
                        .HasColumnType("bigint");

                    b.Property<bool>("isDelete")
                        .HasColumnType("boolean");

                    b.Property<int>("point")
                        .HasColumnType("integer");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.HasIndex("userid");

                    b.ToTable("tb_ratings");
                });

            modelBuilder.Entity("Devify.Entity.SqlRole", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("des")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_roles");
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
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("expiredTime")
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("Devify.Entity.SqlTransaction", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<double>("amount")
                        .HasColumnType("double precision");

                    b.Property<string>("method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("tb_transactions");
                });

            modelBuilder.Entity("Devify.Entity.SqlUser", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

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

                    b.Property<bool>("isbanned")
                        .HasColumnType("boolean");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("roleid")
                        .HasColumnType("bigint");

                    b.Property<string>("social")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("roleid");

                    b.ToTable("tb_users");
                });

            modelBuilder.Entity("SqlCartSqlCourse", b =>
                {
                    b.Property<long>("cartsid")
                        .HasColumnType("bigint");

                    b.Property<long>("coursesid")
                        .HasColumnType("bigint");

                    b.HasKey("cartsid", "coursesid");

                    b.HasIndex("coursesid");

                    b.ToTable("SqlCartSqlCourse");
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

            modelBuilder.Entity("Devify.Entity.SqlCart", b =>
                {
                    b.HasOne("Devify.Entity.SqlDiscount", "discount")
                        .WithMany("carts")
                        .HasForeignKey("discountid");

                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithOne("cart")
                        .HasForeignKey("Devify.Entity.SqlCart", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("discount");

                    b.Navigation("user");
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
                        .WithMany("comments")
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
                        .WithMany("details")
                        .HasForeignKey("orderid");

                    b.Navigation("course");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Devify.Entity.SqlLesson", b =>
                {
                    b.HasOne("Devify.Entity.SqlChapter", "chapter")
                        .WithMany("lessons")
                        .HasForeignKey("chapterid");

                    b.HasOne("Devify.Entity.SqlCourse", "course")
                        .WithMany("lessons")
                        .HasForeignKey("courseid");

                    b.Navigation("chapter");

                    b.Navigation("course");
                });

            modelBuilder.Entity("Devify.Entity.SqlNotification", b =>
                {
                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("notifications")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.HasOne("Devify.Entity.SqlDiscount", "discount")
                        .WithMany("orders")
                        .HasForeignKey("discountid");

                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("orders")
                        .HasForeignKey("userid");

                    b.Navigation("discount");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlRating", b =>
                {
                    b.HasOne("Devify.Entity.SqlCourse", "course")
                        .WithMany("ratings")
                        .HasForeignKey("courseid");

                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlToken", b =>
                {
                    b.HasOne("Devify.Entity.SqlUser", "user")
                        .WithMany("tokens")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Devify.Entity.SqlUser", b =>
                {
                    b.HasOne("Devify.Entity.SqlRole", "role")
                        .WithMany("users")
                        .HasForeignKey("roleid");

                    b.Navigation("role");
                });

            modelBuilder.Entity("SqlCartSqlCourse", b =>
                {
                    b.HasOne("Devify.Entity.SqlCart", null)
                        .WithMany()
                        .HasForeignKey("cartsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devify.Entity.SqlCourse", null)
                        .WithMany()
                        .HasForeignKey("coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("lessons");

                    b.Navigation("orders");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("Devify.Entity.SqlDiscount", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("Devify.Entity.SqlLesson", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("Devify.Entity.SqlOrder", b =>
                {
                    b.Navigation("details");
                });

            modelBuilder.Entity("Devify.Entity.SqlRole", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("Devify.Entity.SqlUser", b =>
                {
                    b.Navigation("cart");

                    b.Navigation("courses");

                    b.Navigation("notifications");

                    b.Navigation("orders");

                    b.Navigation("tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
