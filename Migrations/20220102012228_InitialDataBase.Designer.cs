﻿// <auto-generated />
using System;
using ForumApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApi.Migrations
{
    [DbContext(typeof(ForumApiDataContext))]
    [Migration("20220102012228_InitialDataBase")]
    partial class InitialDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_Category_Slug")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("ForumApi.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("LastUpdateDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Slug" }, "IX_Post_Slug")
                        .IsUnique()
                        .HasFilter("[Slug] IS NOT NULL");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("ForumApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_User_Slug")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ForumApi.Models.Post", b =>
                {
                    b.HasOne("ForumApi.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Post_Category");

                    b.HasOne("ForumApi.Models.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ForumApi.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ForumApi.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
