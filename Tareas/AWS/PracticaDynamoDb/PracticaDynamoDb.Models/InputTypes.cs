namespace PracticaDynamoDb.Models
{
    public class DisponibleEn
    {
        public static string Netflix = "Netflix";
        public static string PrimeVideo = "Prime_Video";
        public static string HBO = "HBO" ;
        public static string Crunchyroll = "Crunchyroll" ;
    };

    public enum ResultsType
    {
        List, 
        Search
    }
}
