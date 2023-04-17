namespace InternDiaryV2.Entities
{
    public class DiaryDay
    {
        public int Id { get; set; }
        public int DiaryId { get; set; }
        public int DayId { get; set; }

        public Diary Diary { get; set; } = null!;
        public Day Day { get; set; } = null!;
    }
}