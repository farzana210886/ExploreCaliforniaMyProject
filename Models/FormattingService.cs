namespace ExploreCaliforniaMyProject.Models
{
    public class FormattingService
    {
      public string AsReadableDate(DateTime date)
        {
            return date.ToString("D");
        }
    }
}
