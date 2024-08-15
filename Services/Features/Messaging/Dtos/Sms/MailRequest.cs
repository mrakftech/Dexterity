﻿using System.ComponentModel.DataAnnotations;

namespace Services.Features.Messaging.Dtos.Sms;

public class MailRequest
{
    [Required(ErrorMessage = "Required")] public string To { get; set; }
    [Required(ErrorMessage = "Required")] public string Subject { get; set; }
    [Required(ErrorMessage = "Required")] public string Body { get; set; }
}