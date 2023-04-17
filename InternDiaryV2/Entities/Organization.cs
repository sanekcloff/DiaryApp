using System.Collections.Generic;

namespace InternDiaryV2.Entities
{
    public class Organization
    {
        public Organization()
        {
            Curators = new HashSet<Curator>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<Curator> Curators { get; set; }
    }
}