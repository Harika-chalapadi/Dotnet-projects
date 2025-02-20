﻿// <auto-generated />
using System;
using CodeFirstAppWith2Tables.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstAppWith2Tables.Migrations
{
    [DbContext(typeof(TutorialDbContext))]
    [Migration("20241023040505_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstAppWith2Tables.Models.Article", b =>
                {
                    b.Property<int?>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ArticleId"));

                    b.Property<string>("ArticleContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TutorialId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId");

                    b.HasIndex("TutorialId");

                    b.ToTable("tblArticle");
                });

            modelBuilder.Entity("CodeFirstAppWith2Tables.Models.Tutorial", b =>
                {
                    b.Property<int>("TutorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorialId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorialId");

                    b.ToTable("tblTutorial");
                });

            modelBuilder.Entity("CodeFirstAppWith2Tables.Models.Article", b =>
                {
                    b.HasOne("CodeFirstAppWith2Tables.Models.Tutorial", "Tutorials")
                        .WithMany("Articles")
                        .HasForeignKey("TutorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutorials");
                });

            modelBuilder.Entity("CodeFirstAppWith2Tables.Models.Tutorial", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
