using Shared.Attributes;

namespace Services.Features.Appointments.Dtos.Availability;

public class RecurringExceptionDto
{
    public DateTime StartDate { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, 1, 9, 00, 0);
    public DateTime EndDate { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, 1, 9, 00, 0);
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public RecurrenceType RecurrenceType { get; set; }
    public DayOfWeek? DayOfWeek { get; set; } // Only used for weekly recurrence
    public int? DayOfMonth { get; set; } // Only used for monthly recurrence
    public string Type { get; set; }
    public string Reason { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }
    public int? RangeStartDay { get; set; } // Start day of the range (e.g., for monthly range)
    public int? RangeEndDay { get; set; }   // End day of the range (e.g., for monthly range)

    public RecurringExceptionDto()
    {
    }

    public RecurringExceptionDto(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, Guid hcpId,
        RecurrenceType recurrenceType, DayOfWeek? dayOfWeek = null, int? dayOfMonth = null, string type = null,
        string reason = null, int? rangeStartDay = null, int? rangeEndDay = null)
    {
        StartDate = startDate;
        EndDate = endDate;
        StartTime = startTime;
        EndTime = endTime;
        RecurrenceType = recurrenceType;
        DayOfWeek = dayOfWeek;
        DayOfMonth = dayOfMonth;
        Type = type;
        Reason = reason;
        HcpId = hcpId;
        RangeStartDay = rangeStartDay;
        RangeEndDay = rangeEndDay;
    }

    public bool IsException(DateTime date)
    {
        // Check if the date is within the overall range
        if (date < StartDate || date > EndDate)
            return false;

        // Check recurrence type
        switch (RecurrenceType)
        {
            case RecurrenceType.Daily:
                return true; // Daily recurrence applies to all days

            case RecurrenceType.Weekly:
                return date.DayOfWeek == DayOfWeek; // Weekly recurrence on a specific day

            case RecurrenceType.Monthly:
                if (RangeStartDay.HasValue && RangeEndDay.HasValue)
                {
                    // Monthly recurrence with a range of days (e.g., from the 10th to the 15th)
                    return date.Day >= RangeStartDay && date.Day <= RangeEndDay;
                }
                else if (DayOfMonth.HasValue)
                {
                    // Monthly recurrence on a specific day (e.g., the 15th)
                    return date.Day == DayOfMonth;
                }
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(RecurrenceType), "Invalid recurrence type.");
        }

        return false;
    }

    public bool IsExceptionTime(DateTime dateTime)
    {
        // Check if the date and time fall within the exception period
        return IsException(dateTime.Date) && dateTime.TimeOfDay >= StartTime && dateTime.TimeOfDay <= EndTime;
    }
    
    
    public List<DateTime> GenerateEvents()
    {
        var events = new List<DateTime>();
        var currentDate = StartDate;

        // Iterate through each day in the range
        while (currentDate <= EndDate)
        {
            if (IsException(currentDate))
            {
                // Add the event at the start time
                events.Add(currentDate.Date + StartTime);
            }

            // Move to the next day
            currentDate = currentDate.AddDays(1);
        }

        return events;
    }
}

public enum RecurrenceType
{
    Daily,
    Weekly,
    Monthly
}