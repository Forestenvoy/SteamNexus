﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus_Server.Models;

public partial class Advertisement
{
    [Key]
    [Required]
    public int AdvertisementId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(300)]
    public string Url { get; set; }

    [Required]
    [MaxLength(300)]
    public string ImagePath { get; set; }

    #nullable enable

    [MaxLength(200)]
    public string? Discription { get; set; }


}