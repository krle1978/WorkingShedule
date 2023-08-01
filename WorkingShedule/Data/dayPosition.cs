namespace WorkingShedule.Data
{
    internal class dayPosition
    {
        public string? DayinWeek { get; set; }
        public string? shiftName { get; set; }
        public string? HoursInDay { get; set; }

        public string HoursInDayCalc()
        {
            string beginTime = "0", endTime = "0";
            if ((string?)shiftName == "x" || shiftName.ToString().Split(' ')[0] == "Urlaub")
            {
                beginTime = "0:0";
                endTime = "0:0";
            }
            else if (shiftName.ToString().Split(' ')[0] == "Bäcker" || shiftName.ToString().Split(' ')[0] == "Imbis")
            {
                beginTime = shiftName.ToString().Split(' ')[1];
                endTime = shiftName.ToString().Split(' ')[3];
                
            }
            else if (shiftName.ToString().Split(' ')[0] == "Schicht")
            {
                beginTime = shiftName.ToString().Split(' ')[2];
                endTime = shiftName.ToString().Split(' ')[4];
                
            }
            else
            {
                beginTime = shiftName.ToString().Split('-')[0];
                endTime = shiftName.ToString().Split('-')[1];
                
            }
            DateTime beginTime2 = DateTime.Parse(beginTime);
            DateTime endTime2 = DateTime.Parse(endTime);
            HoursInDay = $"{(endTime2 - beginTime2).Hours}:{(endTime2 - beginTime2).Minutes}";
            return HoursInDay;
        }
    }
}