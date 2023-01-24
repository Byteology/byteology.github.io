﻿namespace Byteology.Website.Inquiry.Service;

using System.ComponentModel.DataAnnotations;

public class InquiryData
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
    public string? Email { get; set; }

    [Required]
    public string? Message { get; set; }

    [Range(typeof(bool), "true", "true")]
    public bool Consent { get; set; }

    public string? Honeycomb { get; set; }
}