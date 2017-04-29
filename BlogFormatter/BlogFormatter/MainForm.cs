using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DoenaSoft.ToolBox.Generics;

namespace DoenaSoft.BlogFormatter
{
    internal partial class MainForm : Form
    {
        #region Readonlies

        private static readonly Regex TitleRegex;

        private static readonly Regex SeasonRegex;

        private readonly IEnumerable<String> ExcludeTitles;

        private readonly CodeHandler CodeHandler;

        #endregion

        #region Initialization

        static MainForm()
        {
            TitleRegex = new Regex("(<em>(?'Text'.+?)</em>)|(<strong>(?'Text'.+?)</strong>)|(<h2>(?'Text'.+?)</h2>)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

            SeasonRegex = new Regex("(?'Text'.+?): ((Season [0-9]+)|(The Complete Series)|(Die komplette Serie))", RegexOptions.Compiled);
        }

        public MainForm()
        {
            InitializeComponent();

            OutputTextBox.Text = String.Empty;

            CodeHandler = new CodeHandler();

            ProcessButton.Enabled = (Initialize(out ExcludeTitles) == false);
        }

        private Boolean Initialize(out IEnumerable<String> excludeTitles)
        {
            String errors = null;

            try
            {
                excludeTitles = null;

                if (CodeHandler.TryCompile(out errors))
                {
                    ExcludeTitles xml = Serializer<ExcludeTitles>.Deserialize("ExcludeTitles.xml");

                    excludeTitles = xml.Titles ?? Enumerable.Empty<String>();
                }
            }
            catch (Exception ex)
            {
                excludeTitles = null;

                errors = ex.Message;
            }

            if (errors != null)
            {
                OutputTextBox.Text = errors;
            }

            return (errors != null);
        }

        #endregion

        #region EventHandler

        private void OnProcessButtonClick(Object sender
            , EventArgs e)
        {
            OutputTextBox.Text = CodeHandler.Execute(InputTextBox.Text);

            TryAdditles();
        }

        private void OnCopyOutputButtonClick(Object sender
            , EventArgs e)
        {
            SetTextToClipboard(OutputTextBox.Text);
        }

        private void OnCopyKewordsButtonClick(Object sender
            , EventArgs e)
        {
            SetTextToClipboard(KeywordsTextBox.Text);
        }

        private void OnClearInputButtonClick(Object sender
            , EventArgs e)
        {
            InputTextBox.Text = String.Empty;
        }

        #endregion

        #region TryAdditles

        private void TryAdditles()
        {
            KeywordsTextBox.Text = String.Empty;

            HashSet<String> keywords = new HashSet<String>();

            MatchCollection matches = TitleRegex.Matches(OutputTextBox.Text);

            for (Int32 i = 0; i < matches.Count; i++)
            {
                String title = matches[i].Groups["Text"].Value;

                TryAddTitle(keywords, title);
            }

            KeywordsTextBox.Text = String.Join(", ", keywords.ToArray());
        }

        private void TryAddTitle(HashSet<String> keywords
            , String title)
        {
            title = CutOffSeasonIndicator(title);

            if (Include(title))
            {
                keywords.Add(title);
            }
        }

        private static String CutOffSeasonIndicator(String text)
        {
            Match match = SeasonRegex.Match(text);

            if (match.Success)
            {
                text = match.Groups["Text"].Value;
            }

            return (text);
        }

        private Boolean Include(String text)
            => (ExcludeTitles.Contains(text) == false);

        #endregion

        private static void SetTextToClipboard(String text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                Clipboard.SetText(text);
            }
        }
    }
}