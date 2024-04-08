﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SteamNexus.Data;

#nullable disable

namespace SteamNexus.Migrations
{
    [DbContext(typeof(SteamNexusDbContext))]
    partial class SteamNexusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SteamNexus.Models.Advertisement", b =>
                {
                    b.Property<int>("AdvertisementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvertisementId"), 10000L);

                    b.Property<string>("Discription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("AdvertisementId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("SteamNexus.Models.CPU", b =>
                {
                    b.Property<int>("CPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CPUId"), 10000L);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("CPUId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("SteamNexus.Models.CommonQuestion", b =>
                {
                    b.Property<int>("CommonQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommonQuestionId"), 10000L);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CommonQuestionId");

                    b.ToTable("CommonQuestions");
                });

            modelBuilder.Entity("SteamNexus.Models.ComponentClassification", b =>
                {
                    b.Property<int>("ComponentClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponentClassificationId"), 10000L);

                    b.Property<int>("ComputerPartCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ComponentClassificationId");

                    b.HasIndex("ComputerPartCategoryId");

                    b.ToTable("ComponentClassifications");
                });

            modelBuilder.Entity("SteamNexus.Models.ComputerPartCategory", b =>
                {
                    b.Property<int>("ComputerPartCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComputerPartCategoryId"), 10000L);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ComputerPartCategoryId");

                    b.ToTable("ComputerPartCategories");
                });

            modelBuilder.Entity("SteamNexus.Models.GPU", b =>
                {
                    b.Property<int>("GPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPUId"), 10000L);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("GPUId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("SteamNexus.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 10000L);

                    b.Property<string>("AgeRating")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CommentNum")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("LowestPrice")
                        .HasColumnType("int");

                    b.Property<int>("MinReqId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OriginalPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PeakPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("Players")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RecReqId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoPath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("GameId");

                    b.HasIndex("MinReqId");

                    b.HasIndex("RecReqId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SteamNexus.Models.GameLanguage", b =>
                {
                    b.Property<int>("GameLanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameLanguageId"), 10000L);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("Support")
                        .HasColumnType("int");

                    b.HasKey("GameLanguageId");

                    b.HasIndex("GameId");

                    b.HasIndex("LanguageId");

                    b.ToTable("GameLanguages");
                });

            modelBuilder.Entity("SteamNexus.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 10000L);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("SteamNexus.Models.MinimumRequirement", b =>
                {
                    b.Property<int>("MinReqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MinReqId"), 10000L);

                    b.Property<string>("Audio")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CPUId")
                        .HasColumnType("int");

                    b.Property<string>("DirectX")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GPUId")
                        .HasColumnType("int");

                    b.Property<string>("Network")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<string>("Storage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MinReqId");

                    b.HasIndex("CPUId");

                    b.HasIndex("GPUId");

                    b.ToTable("MinimumRequirements");
                });

            modelBuilder.Entity("SteamNexus.Models.PlayersHistory", b =>
                {
                    b.Property<int>("PlayersHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayersHistoryId"), 10000L);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Players")
                        .HasColumnType("int");

                    b.HasKey("PlayersHistoryId");

                    b.HasIndex("GameId");

                    b.ToTable("PlayersHistories");
                });

            modelBuilder.Entity("SteamNexus.Models.PriceHistory", b =>
                {
                    b.Property<int>("PriceHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceHistoryId"), 10000L);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PriceHistoryId");

                    b.HasIndex("GameId");

                    b.ToTable("PriceHistories");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductCPU", b =>
                {
                    b.Property<int>("ProductCPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCPUId"), 10000L);

                    b.Property<int>("CPUId")
                        .HasColumnType("int");

                    b.Property<int>("ProductInformationId")
                        .HasColumnType("int");

                    b.HasKey("ProductCPUId");

                    b.HasIndex("CPUId");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("ProductCPUs");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductGPU", b =>
                {
                    b.Property<int>("ProductGPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductGPUId"), 10000L);

                    b.Property<int>("GPUId")
                        .HasColumnType("int");

                    b.Property<int>("ProductInformationId")
                        .HasColumnType("int");

                    b.HasKey("ProductGPUId");

                    b.HasIndex("GPUId");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("ProductGPUs");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductInformation", b =>
                {
                    b.Property<int>("ProductInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductInformationId"), 10000L);

                    b.Property<int>("ComponentClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Recommend")
                        .HasColumnType("int");

                    b.Property<string>("Specification")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Wattage")
                        .HasColumnType("int");

                    b.HasKey("ProductInformationId");

                    b.HasIndex("ComponentClassificationId");

                    b.ToTable("ProductInformations");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductRAM", b =>
                {
                    b.Property<int>("ProductRAMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductRAMId"), 10000L);

                    b.Property<int>("ProductInformationId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ProductRAMId");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("ProductRAMs");
                });

            modelBuilder.Entity("SteamNexus.Models.RecommendedRequirement", b =>
                {
                    b.Property<int>("RecReqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecReqId"), 10000L);

                    b.Property<string>("Audio")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CPUId")
                        .HasColumnType("int");

                    b.Property<string>("DirectX")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GPUId")
                        .HasColumnType("int");

                    b.Property<string>("Network")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<string>("Storage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RecReqId");

                    b.HasIndex("CPUId");

                    b.HasIndex("GPUId");

                    b.ToTable("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 10000L);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SteamNexus.Models.TagGroup", b =>
                {
                    b.Property<int>("TagGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagGroupId"), 10000L);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("TagGroupId");

                    b.HasIndex("GameId");

                    b.HasIndex("TagId");

                    b.ToTable("TagGroups");
                });

            modelBuilder.Entity("SteamNexus.Models.ComponentClassification", b =>
                {
                    b.HasOne("SteamNexus.Models.ComputerPartCategory", "ComputerPartCategory")
                        .WithMany("ComponentClassifications")
                        .HasForeignKey("ComputerPartCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_ComponentClassifications_ComputerPartCategories");

                    b.Navigation("ComputerPartCategory");
                });

            modelBuilder.Entity("SteamNexus.Models.Game", b =>
                {
                    b.HasOne("SteamNexus.Models.MinimumRequirement", "MinReq")
                        .WithMany("Games")
                        .HasForeignKey("MinReqId")
                        .IsRequired()
                        .HasConstraintName("FK_Games_MinimumRequirements");

                    b.HasOne("SteamNexus.Models.RecommendedRequirement", "RecReq")
                        .WithMany("Games")
                        .HasForeignKey("RecReqId")
                        .IsRequired()
                        .HasConstraintName("FK_Games_RecommendedRequirements");

                    b.Navigation("MinReq");

                    b.Navigation("RecReq");
                });

            modelBuilder.Entity("SteamNexus.Models.GameLanguage", b =>
                {
                    b.HasOne("SteamNexus.Models.Game", "Game")
                        .WithMany("GameLanguages")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_GameLanguages_Games");

                    b.HasOne("SteamNexus.Models.Language", "Language")
                        .WithMany("GameLanguages")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK_GameLanguages_Languages");

                    b.Navigation("Game");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("SteamNexus.Models.MinimumRequirement", b =>
                {
                    b.HasOne("SteamNexus.Models.CPU", "CPU")
                        .WithMany("MinimumRequirements")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_MinimumRequirements_CPUs");

                    b.HasOne("SteamNexus.Models.GPU", "GPU")
                        .WithMany("MinimumRequirements")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_MinimumRequirements_GPUs");

                    b.Navigation("CPU");

                    b.Navigation("GPU");
                });

            modelBuilder.Entity("SteamNexus.Models.PlayersHistory", b =>
                {
                    b.HasOne("SteamNexus.Models.Game", "Game")
                        .WithMany("PlayersHistories")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_PlayersHistories_Games");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus.Models.PriceHistory", b =>
                {
                    b.HasOne("SteamNexus.Models.Game", "Game")
                        .WithMany("PriceHistories")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_PriceHistories_Games");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductCPU", b =>
                {
                    b.HasOne("SteamNexus.Models.CPU", "CPU")
                        .WithMany("ProductCPUs")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCPUs_CPUs");

                    b.HasOne("SteamNexus.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductCPUs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCPUs_ProductInformations");

                    b.Navigation("CPU");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductGPU", b =>
                {
                    b.HasOne("SteamNexus.Models.GPU", "GPU")
                        .WithMany("ProductGPUs")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductGPUs_GPUs");

                    b.HasOne("SteamNexus.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductGPUs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductGPUs_ProductInformations");

                    b.Navigation("GPU");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductInformation", b =>
                {
                    b.HasOne("SteamNexus.Models.ComponentClassification", "ComponentClassification")
                        .WithMany("ProductInformations")
                        .HasForeignKey("ComponentClassificationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductInformations_ComponentClassifications");

                    b.Navigation("ComponentClassification");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductRAM", b =>
                {
                    b.HasOne("SteamNexus.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductRAMs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductRAMs_ProductInformations");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus.Models.RecommendedRequirement", b =>
                {
                    b.HasOne("SteamNexus.Models.CPU", "CPU")
                        .WithMany("RecommendedRequirements")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_RecommendedRequirements_CPUs");

                    b.HasOne("SteamNexus.Models.GPU", "GPU")
                        .WithMany("RecommendedRequirements")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_RecommendedRequirements_GPUs");

                    b.Navigation("CPU");

                    b.Navigation("GPU");
                });

            modelBuilder.Entity("SteamNexus.Models.TagGroup", b =>
                {
                    b.HasOne("SteamNexus.Models.Game", "Game")
                        .WithMany("TagGroups")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_TagGroups_Games");

                    b.HasOne("SteamNexus.Models.Tag", "Tag")
                        .WithMany("TagGroups")
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_TagGroups_Tags");

                    b.Navigation("Game");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SteamNexus.Models.CPU", b =>
                {
                    b.Navigation("MinimumRequirements");

                    b.Navigation("ProductCPUs");

                    b.Navigation("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus.Models.ComponentClassification", b =>
                {
                    b.Navigation("ProductInformations");
                });

            modelBuilder.Entity("SteamNexus.Models.ComputerPartCategory", b =>
                {
                    b.Navigation("ComponentClassifications");
                });

            modelBuilder.Entity("SteamNexus.Models.GPU", b =>
                {
                    b.Navigation("MinimumRequirements");

                    b.Navigation("ProductGPUs");

                    b.Navigation("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus.Models.Game", b =>
                {
                    b.Navigation("GameLanguages");

                    b.Navigation("PlayersHistories");

                    b.Navigation("PriceHistories");

                    b.Navigation("TagGroups");
                });

            modelBuilder.Entity("SteamNexus.Models.Language", b =>
                {
                    b.Navigation("GameLanguages");
                });

            modelBuilder.Entity("SteamNexus.Models.MinimumRequirement", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("SteamNexus.Models.ProductInformation", b =>
                {
                    b.Navigation("ProductCPUs");

                    b.Navigation("ProductGPUs");

                    b.Navigation("ProductRAMs");
                });

            modelBuilder.Entity("SteamNexus.Models.RecommendedRequirement", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("SteamNexus.Models.Tag", b =>
                {
                    b.Navigation("TagGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
