﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamNexus_Server.Models;

public partial class ComponentClassification
{
    [Key]
    public int ComponentClassificationId { get; set; }

    [Required]
    public int ComputerPartCategoryId { get; set; }
    public virtual ComputerPartCategory ComputerPartCategory { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<ProductInformation> ProductInformations { get; set; } = new List<ProductInformation>();
}
