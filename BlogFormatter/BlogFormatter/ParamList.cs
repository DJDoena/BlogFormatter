using System;
using System.Xml.Serialization;

namespace DoenaSoft.BlogFormatter
{
    public class ParamList
    {
        [XmlArrayItem("Param")]
        public Param[] Params;
    }

    public class Param
    {
        public String Name;

        public String Regex;

        public String RegexOptions;

        public String Code;
    }
}