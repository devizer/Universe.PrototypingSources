namespace Universe.PrototypingSources
{
    public class HumanName
    {
        public string Name { get; set; }
        public int Popularity { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }

        public HumanName(string name, int popularity, Gender gender, string description)
        {
            Name = name;
            Popularity = popularity;
            Gender = gender;
            Description = description;
        }

        public bool IsPetForm
        {
            get { return Description.StartsWith("Pet"); }
        }
    }
}