﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus_Server.Models;

public partial class ComputerPartCategory
{
    [Key]
    public int ComputerPartCategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<ComponentClassification> ComponentClassifications { get; set; } = new List<ComponentClassification>();

    public enum Type
    {
        CPU = 10000, // 中央處理器
        GPU = 10001, // 顯示卡
        RAM = 10002, // 記憶體
        MB = 10003, // 主機板
        SSD = 10004, // 固態硬碟
        HDD = 10005, // 傳統硬碟
        AirCooler = 10006, // 風冷散熱器
        LiquidCooler = 10007, // 水冷散熱器
        CASE = 10008, // 機殼
        PSU = 10009, // 電供
        OS = 10010 // 作業系統
    }
}