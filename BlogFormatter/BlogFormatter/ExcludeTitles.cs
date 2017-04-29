using System;
using System.Xml.Serialization;

namespace DoenaSoft.BlogFormatter
{
    public class ExcludeTitles
    {
        [XmlArrayItem("Title")]
        public String[] Titles;
    }
}