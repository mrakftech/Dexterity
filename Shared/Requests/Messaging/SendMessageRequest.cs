using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Messaging;

public class SendMessageRequest
{
    [Required] public string Content { get; set; }
    [Required] public string Mobile { get; set; }
}