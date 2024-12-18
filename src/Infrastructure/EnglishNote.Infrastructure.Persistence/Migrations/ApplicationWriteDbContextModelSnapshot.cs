﻿// <auto-generated />
using System;
using EnglishNote.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishNote.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationWriteDbContext))]
    partial class ApplicationWriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Identity.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.QuizSessions.QuizSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VocabularySetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VocabularySetId")
                        .IsUnique();

                    b.ToTable("QuizSessions");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.VocabularySets.VocabularySet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("QuizSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ThumbnailId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VocabularySets");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Words.Word", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MemoryLevel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VocabularySetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WordText")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.HasIndex("VocabularySetId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.QuizSessions.QuizSession", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnglishNote.Domain.AggregatesModel.VocabularySets.VocabularySet", "VocabularySet")
                        .WithOne("QuizSession")
                        .HasForeignKey("EnglishNote.Domain.AggregatesModel.QuizSessions.QuizSession", "VocabularySetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VocabularySet");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Tags.Tag", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.VocabularySets.VocabularySet", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", "User")
                        .WithMany("VocabularySets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Words.Word", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Tags.Tag", "Tag")
                        .WithMany("Words")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", "User")
                        .WithMany("Words")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EnglishNote.Domain.AggregatesModel.VocabularySets.VocabularySet", "VocabularySet")
                        .WithMany("Words")
                        .HasForeignKey("VocabularySetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.WordMeaning", "Meanings", b1 =>
                        {
                            b1.Property<Guid>("WordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("CefrLevel")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("PartOfSpeech")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("WordId", "Id");

                            b1.ToTable("WordMeaning");

                            b1.WithOwner()
                                .HasForeignKey("WordId");

                            b1.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.Definition", "Definitions", b2 =>
                                {
                                    b2.Property<Guid>("WordMeaningWordId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("WordMeaningId")
                                        .HasColumnType("int");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<int>("Id"));

                                    b2.Property<string>("DefinitionText")
                                        .IsRequired()
                                        .HasMaxLength(1024)
                                        .HasColumnType("nvarchar(1024)");

                                    b2.HasKey("WordMeaningWordId", "WordMeaningId", "Id");

                                    b2.ToTable("Definition");

                                    b2.WithOwner()
                                        .HasForeignKey("WordMeaningWordId", "WordMeaningId");

                                    b2.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.Antonym", "Antonyms", b3 =>
                                        {
                                            b3.Property<Guid>("DefinitionWordMeaningWordId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int>("DefinitionWordMeaningId")
                                                .HasColumnType("int");

                                            b3.Property<int>("DefinitionId")
                                                .HasColumnType("int");

                                            b3.Property<int>("Id")
                                                .ValueGeneratedOnAdd()
                                                .HasColumnType("int");

                                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b3.Property<int>("Id"));

                                            b3.Property<string>("Value")
                                                .IsRequired()
                                                .HasMaxLength(126)
                                                .HasColumnType("nvarchar(126)");

                                            b3.HasKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId", "Id");

                                            b3.ToTable("Antonym");

                                            b3.WithOwner()
                                                .HasForeignKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId");
                                        });

                                    b2.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.Example", "Examples", b3 =>
                                        {
                                            b3.Property<Guid>("DefinitionWordMeaningWordId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int>("DefinitionWordMeaningId")
                                                .HasColumnType("int");

                                            b3.Property<int>("DefinitionId")
                                                .HasColumnType("int");

                                            b3.Property<int>("Id")
                                                .ValueGeneratedOnAdd()
                                                .HasColumnType("int");

                                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b3.Property<int>("Id"));

                                            b3.Property<string>("Value")
                                                .IsRequired()
                                                .HasMaxLength(1024)
                                                .HasColumnType("nvarchar(1024)");

                                            b3.HasKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId", "Id");

                                            b3.ToTable("Example");

                                            b3.WithOwner()
                                                .HasForeignKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId");
                                        });

                                    b2.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.Synonym", "Synonyms", b3 =>
                                        {
                                            b3.Property<Guid>("DefinitionWordMeaningWordId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int>("DefinitionWordMeaningId")
                                                .HasColumnType("int");

                                            b3.Property<int>("DefinitionId")
                                                .HasColumnType("int");

                                            b3.Property<int>("Id")
                                                .ValueGeneratedOnAdd()
                                                .HasColumnType("int");

                                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b3.Property<int>("Id"));

                                            b3.Property<string>("Value")
                                                .IsRequired()
                                                .HasMaxLength(126)
                                                .HasColumnType("nvarchar(126)");

                                            b3.HasKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId", "Id");

                                            b3.ToTable("Synonym");

                                            b3.WithOwner()
                                                .HasForeignKey("DefinitionWordMeaningWordId", "DefinitionWordMeaningId", "DefinitionId");
                                        });

                                    b2.Navigation("Antonyms");

                                    b2.Navigation("Examples");

                                    b2.Navigation("Synonyms");
                                });

                            b1.Navigation("Definitions");
                        });

                    b.OwnsMany("EnglishNote.Domain.AggregatesModel.Words.WordPhonetic", "Phonetics", b1 =>
                        {
                            b1.Property<Guid>("WordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Audio")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("CustomAudio")
                                .HasMaxLength(36)
                                .HasColumnType("nvarchar(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.HasKey("WordId", "Id");

                            b1.ToTable("WordPhonetic");

                            b1.WithOwner()
                                .HasForeignKey("WordId");
                        });

                    b.Navigation("Meanings");

                    b.Navigation("Phonetics");

                    b.Navigation("Tag");

                    b.Navigation("User");

                    b.Navigation("VocabularySet");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Tags");

                    b.Navigation("VocabularySets");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.Tags.Tag", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("EnglishNote.Domain.AggregatesModel.VocabularySets.VocabularySet", b =>
                {
                    b.Navigation("QuizSession")
                        .IsRequired();

                    b.Navigation("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
