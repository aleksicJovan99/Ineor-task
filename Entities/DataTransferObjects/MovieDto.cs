﻿using System.ComponentModel.DataAnnotations;

namespace Entities;
public class MovieDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Rating { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }
}
