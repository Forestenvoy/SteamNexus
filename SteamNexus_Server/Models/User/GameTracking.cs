﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus_Server.Models;

public partial class GameTracking
{
    [Key]
    public int GameTrackingId { get; set; }

    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    [Required]
    public int GameId { get; set; }

    public virtual Game Game { get; set; }

    [MaxLength(500)]
    public string Title { get; set; }

    // 追蹤日期(自動)
    public DateTime TrackingDate { get; set; } = DateTime.Now;

}