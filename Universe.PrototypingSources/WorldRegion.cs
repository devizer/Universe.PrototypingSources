namespace Universe.PrototypingSources
{
    using System.Collections.Generic;

    public class WorldRegion
    {
        public string Id { get; set; }
        public string IdParent { get; set; }

        public WorldRegion Parent { get; set; }

        public string Name { get; set; }

        public List<CountryWithFlag> CountriesWithFlag { get; set; }

        public bool IsRoot
        {
            get { return IdParent == null; }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(IdParent)}: {IdParent}, {nameof(Name)}: {Name}";
        }

        // For Internal use Only
        public List<string> AllCountryNames { get; set; }

        // For Internal use Only
        public List<string> NotFoundCountryNames { get; set; }


    }
}