namespace DataLayer.ResponseClasses
{
    public class BSETickerAdv
    {
        public string Fifty2WkHigh_adj { get; set; }
        public string Fifty2WkHigh_adjDt { get; set; }
        public string Fifty2WkLow_adj { get; set; }
        public string Fifty2WkLow_adjDt { get; set; }
        public string Fifty2WkHigh_unadj { get; set; }
        public string Fifty2WkLow_unadj { get; set; }
        public string MonthHighLow { get; set; }
        public string WeekHighLow { get; set; }
        public object UnderlyingVal { get; set; }
        public object CktFilter { get; set; }
    }
}
