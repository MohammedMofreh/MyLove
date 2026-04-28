namespace MyLove.Models
{
    public class WeddingCountdownViewModel
    {
        public DateTime WeddingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ServerNow { get; set; }

        public int TotalDaysJourney => Math.Max(1, (int)Math.Ceiling((WeddingDate - StartDate).TotalDays));
        public int DaysPassed => Math.Max(0, (int)Math.Floor((ServerNow - StartDate).TotalDays));
        public int DaysRemaining => Math.Max(0, (int)Math.Ceiling((WeddingDate - ServerNow).TotalDays));
        public double ProgressPercent =>
            Math.Clamp((ServerNow - StartDate).TotalSeconds / (WeddingDate - StartDate).TotalSeconds * 100.0, 0, 100);
    }
}
