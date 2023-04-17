namespace InternDiaryV2.Entities
{
    public class PracticeDiary
    {
        public int Id { get; set; }

        public int PracticeId { get; set; }
        public int DiaryId { get; set; }

        public Practice Practice { get; set; } = null!;
        public Diary Diary { get; set; } = null!;
    }
}