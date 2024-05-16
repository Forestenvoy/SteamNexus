﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SteamNexus_Server.Data;

#nullable disable

namespace SteamNexus_Server.Migrations
{
    [DbContext(typeof(SteamNexusDbContext))]
    [Migration("20240515160123_amendDescription")]
    partial class amendDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SteamNexus_Server.Models.Advertisement", b =>
                {
                    b.Property<int>("AdvertisementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvertisementId"), 10000L);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("SteamNexus_Server.Models.CPU", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.CommonQuestion", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.ComponentClassification", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.ComputerPartCategory", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.GPU", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 10000L);

                    b.Property<string>("AgeRating")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("AppId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CommentNum")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int?>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("LowestPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("OriginalPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PeakPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("Players")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoPath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.GameLanguage", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.Language", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"), 10000L);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("TotalWattage")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.MenuDetail", b =>
                {
                    b.Property<int>("MenuDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuDetailId"), 10000L);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductInformationId")
                        .HasColumnType("int");

                    b.HasKey("MenuDetailId");

                    b.HasIndex("MenuId");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("MenuDetails");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.MinimumRequirement", b =>
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

                    b.Property<int>("GameId")
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

                    b.Property<string>("OriCpu")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("OriGpu")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("OriRam")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<string>("Storage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MinReqId");

                    b.HasIndex("CPUId");

                    b.HasIndex("GPUId");

                    b.HasIndex("GameId");

                    b.ToTable("MinimumRequirements");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.PlayersHistory", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.PriceHistory", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.ProductCPU", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.ProductGPU", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.ProductInformation", b =>
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

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Wattage")
                        .HasColumnType("int");

                    b.HasKey("ProductInformationId");

                    b.HasIndex("ComponentClassificationId");

                    b.ToTable("ProductInformations");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductRAM", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.RecommendedRequirement", b =>
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

                    b.Property<int>("GameId")
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

                    b.Property<string>("OriCpu")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("OriGpu")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("OriRam")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("RAM")
                        .HasColumnType("int");

                    b.Property<string>("Storage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RecReqId");

                    b.HasIndex("CPUId");

                    b.HasIndex("GPUId");

                    b.HasIndex("GameId");

                    b.ToTable("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 10000L);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Tag", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.TagGroup", b =>
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

            modelBuilder.Entity("SteamNexus_Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 10000L);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ComponentClassification", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.ComputerPartCategory", "ComputerPartCategory")
                        .WithMany("ComponentClassifications")
                        .HasForeignKey("ComputerPartCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_ComponentClassifications_ComputerPartCategories");

                    b.Navigation("ComputerPartCategory");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.GameLanguage", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("GameLanguages")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_GameLanguages_Games");

                    b.HasOne("SteamNexus_Server.Models.Language", "Language")
                        .WithMany("GameLanguages")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK_GameLanguages_Languages");

                    b.Navigation("Game");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.MenuDetail", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Menu", "Menu")
                        .WithMany("MenuDetails")
                        .HasForeignKey("MenuId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuDetails_Menus");

                    b.HasOne("SteamNexus_Server.Models.ProductInformation", "ProductInformation")
                        .WithMany("MenuDetails")
                        .HasForeignKey("ProductInformationId")
                        .HasConstraintName("FK_MenuDetails_ProductInformations");

                    b.Navigation("Menu");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.MinimumRequirement", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.CPU", "CPU")
                        .WithMany("MinimumRequirements")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_MinimumRequirements_CPUs");

                    b.HasOne("SteamNexus_Server.Models.GPU", "GPU")
                        .WithMany("MinimumRequirements")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_MinimumRequirements_GPUs");

                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("MinimumRequirements")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_MinimumRequirements_Games");

                    b.Navigation("CPU");

                    b.Navigation("GPU");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.PlayersHistory", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("PlayersHistories")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_PlayersHistories_Games");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.PriceHistory", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("PriceHistories")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_PriceHistories_Games");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductCPU", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.CPU", "CPU")
                        .WithMany("ProductCPUs")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCPUs_CPUs");

                    b.HasOne("SteamNexus_Server.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductCPUs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCPUs_ProductInformations");

                    b.Navigation("CPU");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductGPU", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.GPU", "GPU")
                        .WithMany("ProductGPUs")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductGPUs_GPUs");

                    b.HasOne("SteamNexus_Server.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductGPUs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductGPUs_ProductInformations");

                    b.Navigation("GPU");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductInformation", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.ComponentClassification", "ComponentClassification")
                        .WithMany("ProductInformations")
                        .HasForeignKey("ComponentClassificationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductInformations_ComponentClassifications");

                    b.Navigation("ComponentClassification");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductRAM", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.ProductInformation", "ProductInformation")
                        .WithMany("ProductRAMs")
                        .HasForeignKey("ProductInformationId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductRAMs_ProductInformations");

                    b.Navigation("ProductInformation");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.RecommendedRequirement", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.CPU", "CPU")
                        .WithMany("RecommendedRequirements")
                        .HasForeignKey("CPUId")
                        .IsRequired()
                        .HasConstraintName("FK_RecommendedRequirements_CPUs");

                    b.HasOne("SteamNexus_Server.Models.GPU", "GPU")
                        .WithMany("RecommendedRequirements")
                        .HasForeignKey("GPUId")
                        .IsRequired()
                        .HasConstraintName("FK_RecommendedRequirements_GPUs");

                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("RecommendedRequirements")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_RecommendedRequirements_Games");

                    b.Navigation("CPU");

                    b.Navigation("GPU");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.TagGroup", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Game", "Game")
                        .WithMany("TagGroups")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_TagGroups_Games");

                    b.HasOne("SteamNexus_Server.Models.Tag", "Tag")
                        .WithMany("TagGroups")
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_TagGroups_Tags");

                    b.Navigation("Game");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.User", b =>
                {
                    b.HasOne("SteamNexus_Server.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.CPU", b =>
                {
                    b.Navigation("MinimumRequirements");

                    b.Navigation("ProductCPUs");

                    b.Navigation("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ComponentClassification", b =>
                {
                    b.Navigation("ProductInformations");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ComputerPartCategory", b =>
                {
                    b.Navigation("ComponentClassifications");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.GPU", b =>
                {
                    b.Navigation("MinimumRequirements");

                    b.Navigation("ProductGPUs");

                    b.Navigation("RecommendedRequirements");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Game", b =>
                {
                    b.Navigation("GameLanguages");

                    b.Navigation("MinimumRequirements");

                    b.Navigation("PlayersHistories");

                    b.Navigation("PriceHistories");

                    b.Navigation("RecommendedRequirements");

                    b.Navigation("TagGroups");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Language", b =>
                {
                    b.Navigation("GameLanguages");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Menu", b =>
                {
                    b.Navigation("MenuDetails");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.ProductInformation", b =>
                {
                    b.Navigation("MenuDetails");

                    b.Navigation("ProductCPUs");

                    b.Navigation("ProductGPUs");

                    b.Navigation("ProductRAMs");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SteamNexus_Server.Models.Tag", b =>
                {
                    b.Navigation("TagGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
