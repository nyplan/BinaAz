﻿namespace BinaAz.Application.DTOs.User;

public class MeDto
{
    public string? CompanyName { get; set; }
    public string? RelevantPerson { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public double Balance { get; set; }

    public string? ImageUrl { get; set; }
}