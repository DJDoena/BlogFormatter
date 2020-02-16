using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using DoenaSoft.ToolBox.Generics;
using Microsoft.CSharp;

namespace DoenaSoft.BlogFormatter
{
    internal sealed class CodeHandler
    {
        #region Constants

        private const String ClassName = "RegexReplacer";

        private const String MethodName = "Replace";

        #endregion

        #region Fields

        private static Regex m_LineRegex;

        #endregion

        #region Properties

        private StringBuilder Errors { get; set; }

        private IEnumerable<MethodInfo> Methods { get; set; }

        private static Regex LineRegex
        {
            get
            {
                if (m_LineRegex == null)
                {
                    m_LineRegex = new Regex("^(?'Line'.*?)\r\n", RegexOptions.Compiled | RegexOptions.Multiline);
                }

                return (m_LineRegex);
            }
        }

        #endregion

        #region Initialization

        public CodeHandler()
        {
            Methods = Enumerable.Empty<MethodInfo>();
        }

        #endregion

        #region Public Methods

        public Boolean TryCompile(out String errors)
        {
            errors = null;

            Methods = TryCompile();

            if (Errors.Length != 0)
            {
                Methods = Enumerable.Empty<MethodInfo>();

                errors = Errors.ToString();
            }

            return (Errors.Length == 0);
        }

        public String Execute(String text)
        {
            foreach (MethodInfo method in Methods)
            {
                text = (String)(method.Invoke(null, new[] { text }));
            }

            var lines = new List<string>();

            using (var sr = new StringReader(text))
            {
                while (sr.Peek() != -1)
                {
                    lines.Add(sr.ReadLine());
                }
            }

            var paragraphClosed = true;

            string previousLine = null;

            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                if (paragraphClosed && !string.IsNullOrWhiteSpace(line))
                {
                    if (previousLine != null)
                    {
                        sb.AppendLine(previousLine);
                    }

                    sb.AppendLine("<p>");

                    paragraphClosed = false;

                    previousLine = line;

                    continue;
                }
                else if (!paragraphClosed && string.IsNullOrWhiteSpace(line))
                {
                    if (previousLine != null)
                    {
                        sb.AppendLine(previousLine);

                        previousLine = null;
                    }

                    sb.AppendLine("</p>");

                    paragraphClosed = true;

                    continue;
                }
                else if (previousLine != null)
                {
                    sb.Append(previousLine);
                    sb.AppendLine("<br />");

                    previousLine = line;
                }
            }

            if (previousLine != null)
            {
                sb.AppendLine(previousLine);
                sb.AppendLine("</p>");
            }

            text = sb.ToString();

            return (text);
        }

        #endregion

        #region TryCompile

        private IEnumerable<MethodInfo> TryCompile()
        {
            ParamList parameters = Serializer<ParamList>.Deserialize("ParamList.xml");

            IEnumerable<MethodInfo> methods = (parameters.Params != null) ? TryCompile(parameters.Params) : (Enumerable.Empty<MethodInfo>());

            return (methods);
        }

        private IEnumerable<MethodInfo> TryCompile(Param[] parameters)
        {
            List<MethodInfo> methods = new List<MethodInfo>(parameters.Length);

            Errors = new StringBuilder();

            foreach (Param param in parameters)
            {
                if (param != null)
                {
                    TryCompile(methods, param);
                }
            }

            return (methods);
        }

        private void TryCompile(List<MethodInfo> methods
            , Param param)
        {
            CompilerResults cr;
            if (TryCompile(param, out cr))
            {
                Type t = cr.CompiledAssembly.GetType(ClassName);

                MethodInfo mi = t.GetMethod(MethodName);

                methods.Add(mi);
            }
        }

        private Boolean TryCompile(Param param
            , out CompilerResults cr)
        {
            String code;
            cr = Compile(param, out code);

            if ((cr.Errors != null) && (cr.Errors.Count > 0))
            {
                foreach (CompilerError error in cr.Errors)
                {
                    Errors.AppendLine($"{error.ErrorText} (ln {error.Line}, col {error.Column})");
                }

                Errors.AppendLine();

                Int32 lineNumber = 1;

                code = LineRegex.Replace(code, match => $"{lineNumber++}: {match.Groups["Line"].Value}{Environment.NewLine}");

                Errors.AppendLine(code);

                return (false);
            }

#if DEBUG

            CopyAssembly(param, cr);

#endif

            return (true);
        }

#if DEBUG

        private static void CopyAssembly(Param param, CompilerResults cr)
        {
            String fileName = GetAssemblyName(param, cr.PathToAssembly);

            fileName = Path.Combine(Environment.CurrentDirectory, fileName);

            File.Copy(cr.PathToAssembly, fileName, true);
        }

        private static String GetAssemblyName(Param param
            , String assemblyName)
            => ((param.Name != null) ? (GetAssemblyName(param.Name)) : ((new FileInfo(assemblyName)).Name));

        private static String GetAssemblyName(String paramName)
        {
            Char[] invalidChars = Path.GetInvalidFileNameChars();

            Char[] chars = paramName.Select(c => invalidChars.Contains(c) ? '_' : c).ToArray();

            String fileName = new String(chars);

            fileName += ".dll";

            return (fileName);
        }

#endif

        private CompilerResults Compile(Param param
            , out String code)
        {
            code = GetCode(param);

            CSharpCodeProvider cscp = new CSharpCodeProvider();

            CompilerParameters cp = CompilerParameters();

            cp.ReferencedAssemblies.Add("System.dll");

            CompilerResults cr = cscp.CompileAssemblyFromSource(cp, code);

            return (cr);
        }

        private static CompilerParameters CompilerParameters()
        {
            CompilerParameters cp = new CompilerParameters();

#if DEBUG

            cp.GenerateInMemory = false;
            cp.TempFiles = new TempFileCollection(Path.GetTempPath(), true);
            cp.IncludeDebugInformation = true;

#else

            cp.GenerateInMemory = true;
            cp.IncludeDebugInformation = false;

#endif


            return (cp);
        }

        private static String GetCode(Param param)
        {
            StringBuilder code = new StringBuilder();

            code.AppendLine("using System;");
            code.AppendLine("using System.Text.RegularExpressions;");
            code.AppendLine();
            code.AppendLine($"public static class {ClassName}");
            code.AppendLine("{");
            code.AppendLine($"  private static readonly Regex s_Regex = new Regex(\"{param.Regex}\", {param.RegexOptions});");
            code.AppendLine();
            code.AppendLine("  private static String Replace(Match match)");
            code.AppendLine("  {");
            code.AppendLine($"    String replace = {param.Code};");
            code.AppendLine();
            code.AppendLine($"    return (replace);");
            code.AppendLine("  }");
            code.AppendLine();
            code.AppendLine($"  public static String {MethodName}(String text)");
            code.AppendLine("  {");
            code.AppendLine($"    String replace = s_Regex.Replace(text, Replace);");
            code.AppendLine();
            code.AppendLine("    return (replace);");
            code.AppendLine("  }");
            code.AppendLine("}");

            return (code.ToString());
        }

        #endregion
    }
}