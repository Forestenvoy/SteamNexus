﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus.Models;

public partial class ProductGPU
{
    [Key]
    public int ProductGPUId { get; set; }

    [Required]
    public int ProductInformationId { get; set; }

    [Required]
    public int GPUId { get; set; }

    public virtual GPU GPU { get; set; }

    public virtual ProductInformation ProductInformation { get; set; }
}