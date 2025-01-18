namespace CodingTest.HackerNew
{
    public class HackerNew
    {
        private long _time;

        public string? Title { get; set; }

        public string? Url { get; set; }

        public string? By { get; set; }

        public int? Score { get; set; }

        public long Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public string UnixTimeToDateTime
        {
            get
            {
                var offset = DateTimeOffset.FromUnixTimeSeconds(Time);
                return offset.DateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffK");
            }
        }
    }
}
