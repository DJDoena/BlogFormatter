using System;
using System.IO;
using System.Text;
using DoenaSoft.ToolBox.Generics;

namespace DoenaSoft.BlogFormatter.XmlWriterWriter
{
    /// <summary>
    /// This code writes the Program.cs for the XmlWriter application.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            StringBuilder code = WriteHeader();

            ParamList parameters = Serializer<ParamList>.Deserialize("ParamList.xml");

            if (parameters.Params?.Length > 0)
            {
                WriteParams(code, parameters);
            }

            WriteFooter(code);

            WriteFile(code);
        }

        private static StringBuilder WriteHeader()
        {
            StringBuilder code = new StringBuilder();

            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine();
            code.AppendLine("namespace DoenaSoft.BlogFormatter.XmlWriter");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// This code writes the ParamList.xml for the BlogFormatter application.");
            code.AppendLine("    /// </summary>");
            code.AppendLine("    public static class Program");
            code.AppendLine("    {");
            code.AppendLine("        public static void Main()");
            code.AppendLine("        {");
            return code;
        }

        private static void WriteParams(StringBuilder code
            , ParamList parameters)
        {
            code.AppendLine("            Param param;");
            code.AppendLine();
            code.AppendLine($"            List<Param> parameters = new List<Param>({parameters.Params.Length});");

            foreach (Param param in parameters.Params)
            {
                WriteParam(code, param);
            }

            code.AppendLine();
            code.AppendLine("            ParamList paramList = new ParamList();");
            code.AppendLine();
            code.AppendLine("            paramList.Params = parameters.ToArray();");
            code.AppendLine();
            code.AppendLine("            Serializer<ParamList>.Serialize(\"ParamList.xml\", paramList);");
        }

        private static void WriteParam(StringBuilder code
            , Param param)
        {
            code.AppendLine();
            code.AppendLine("            param = new Param();");
            code.AppendLine($"            param.Name = \"{ToLiteral(param.Name)}\";");
            code.AppendLine($"            param.Regex = \"{ToLiteral(param.Regex)}\";");
            code.AppendLine($"            param.RegexOptions = \"{ToLiteral(param.RegexOptions)}\";");
            code.AppendLine($"            param.Code = \"{ToLiteral(param.Code)}\";");
            code.AppendLine("            parameters.Add(param);");
        }

        private static String ToLiteral(String input)
            => (input?.Replace("\\", "\\\\").Replace("\"", "\\\"") ?? String.Empty);

        private static void WriteFooter(StringBuilder code)
        {
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.Append("}");
        }

        private static void WriteFile(StringBuilder code)
        {
            using (FileStream fs = new FileStream("Program.cs", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(code.ToString());
                }
            }
        }
    }
}