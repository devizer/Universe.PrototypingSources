# Universe.PrototypingSources 
It is intended for prototyping. It provides Names and Countries' Flags, grouped into two-level world regions

## This version contains:
 * 450 Male &amp; 450 Female names. Properties of Names: Name, Gender, IsPetForm, etc
 * 211 Countries and EU flags in SVG format. Properties of Flags: Name, WikiUrl, FlagAsSvg, FlagWidth, FlagHeight, etc
 * Two-level World Regions (Europe, Asia, America, etc) with corresponsing countries and their flags

## Root Data Sources
* `SourceOfCountriesWithFlags.Countries`: 211 countries' flags in SVG-format without regard to world regions below
* `SourceOfWorldRegions.WorldRegions`: Countries abouve grouped into two level regions heirarchy
* `SourceOfNames.Names`: 450 male & 450 female names

## Tested on
* .Net Core 1.0+
* .Net Framework 4.5+
* .Net Portable
* .Net 2.0 - 4.0. Conditional defenition symbol is required: either NET20, NET35 or NET40
