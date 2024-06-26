﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus_Server.Models;

public partial class GPU
{
    [Key]
    public int GPUId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int Score { get; set; }

    public virtual ICollection<MinimumRequirement> MinimumRequirements { get; set; } = new List<MinimumRequirement>();

    public virtual ICollection<RecommendedRequirement> RecommendedRequirements { get; set; } = new List<RecommendedRequirement>();

    public virtual ICollection<ProductGPU> ProductGPUs { get; set; } = new List<ProductGPU>();

}