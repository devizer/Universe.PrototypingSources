namespace Universe.PrototypingSources
{
    using System;
    using System.Reflection;
    using System.Resources;

    public class CountryWithFlag
    {
        public string Name { get; set; }
        public string WikiUrl { get; set; }
        public decimal GDP { get; set; }

        public string FlagKey { get; set; }

        public string SvgFlagUrl { get; set; }
        public int FlagWidth { get; set; }
        public int FlagHeight { get; set; }


        public string FlagAsSvg
        {
            get
            {
                string ret = GetResMan().GetString(this.FlagKey);
                if (ret == null)
                    throw new InvalidOperationException(string.Format(
                        "It seems generated data is corrupter. Flag of {0} is not found in {1} by '{2}' key.",
                        Name, ResourceKey, FlagKey));

                return ret;
            }
        }

        protected bool Equals(CountryWithFlag other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CountryWithFlag) obj);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }


        private const string ResourceKey = "Universe.PrototypeSources.Wiki_Flags_Of_Countries";
        private static ResourceManager _ResMan;
        static readonly object _Sync = new object();

        static ResourceManager GetResMan()
        {
#if NETCOREAPP1_0 || NETCOREAPP1_1 || NETCOREAPP2_0
            Assembly a = typeof(CountryWithFlag).GetTypeInfo().Assembly;
#elif NET20 || NET35 || NET40 
            Assembly a = typeof(CountryWithFlag).Assembly;
#else
            Assembly a = typeof(CountryWithFlag).GetTypeInfo().Assembly;
#endif

            lock (_Sync)
            {
                if (_ResMan != null) return _ResMan;
                foreach (string name in a.GetManifestResourceNames())
                {
                    if (name.EndsWith(ResourceKey + ".resources"))
                    {
                        string baseName = name.Substring(0, name.Length - ".resources".Length);
                        ResourceManager m = new ResourceManager(baseName, a);
                        _ResMan = m;
                        return _ResMan;
                    }
                }
            }

            throw new InvalidOperationException(string.Format(
                "Embedded resource {0} was not found in each folder of Assembly {1}",
                ResourceKey, a.FullName));
        }
    }
}