namespace Shared.Constants.Module;

public static class AppointmentConstants
{
    public static class Status
    {
        public const string Active = "Active";
        public const string Cancelled = "Cancelled/DNA";
    }
    public static class WaitingStatus
    {
        public const string Expected = "Expected";
        public const string Arrived = "Arrived";
        public const string InConsultation = "In Consultation";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
        public const string Dna = "Did Not Attend (DNA)";
    }
}