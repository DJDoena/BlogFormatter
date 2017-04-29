using System.Collections.Generic;
using DoenaSoft.ToolBox.Generics;

namespace DoenaSoft.BlogFormatter.XmlWriter
{
    /// <summary>
    /// This code writes the ParamList.xml for the BlogFormatter application.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            Param param;

            List<Param> parameters = new List<Param>(27);

            param = new Param();
            param.Name = "Grafiken";
            param.Regex = "\\\\[img\\\\](?'Link'.+?)\\\\[/img\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<img src=\\\"\" + match.Groups[\"Link\"].Value + \"\\\">\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Lange URL mit \"Quotes\"";
            param.Regex = "\\\\[url=\\\"(?'Link'.+?)\\\"\\\\](?'Text'.+?)\\\\[/url\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<a href=\\\"\" + match.Groups[\"Link\"].Value + \"\\\">\" + match.Groups[\"Text\"].Value + \"</a>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Lange URL ohne \"Quotes\"";
            param.Regex = "\\\\[url=(?'Link'.+?)\\\\](?'Text'.+?)\\\\[/url\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<a href=\\\"\" + match.Groups[\"Link\"].Value + \"\\\">\" + match.Groups[\"Text\"].Value + \"</a>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Kurze URL";
            param.Regex = "\\\\[url\\\\](?'Link'.+?)\\\\[/url\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<a href=\\\"\" + match.Groups[\"Link\"].Value + \"\\\">\" + match.Groups[\"Link\"].Value + \"</a>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "WhatYaGot";
            param.Regex = "\\\\[whatyagot2?=(?'Link'.+?)\\\\](?'Id'.+?)\\\\[/whatyagot2?\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<a href=\\\"http://\" + match.Groups[\"Link\"].Value + \"/index.php?lastmedia=\" + match.Groups[\"Id\"].Value + \"\\\"><img src=\\\"http://\" + match.Groups[\"Link\"].Value + \"/images/thumbnails/\" + match.Groups[\"Id\"].Value + \"f.jpg\\\" border=\\\"0\\\"></img></a>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Fetter Text";
            param.Regex = "\\\\[b\\\\](?'Text'.+?)\\\\[/b?\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<strong>\" + match.Groups[\"Text\"].Value + \"</strong>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Kursiver Text";
            param.Regex = "\\\\[i\\\\](?'Text'.+?)\\\\[/i\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<em>\" + match.Groups[\"Text\"].Value + \"</em>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Center Text";
            param.Regex = "\\\\[center\\\\](?'Text'.+?)\\\\[/center?\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<div style=\\\"text-align: center;\\\">\" + match.Groups[\"Text\"].Value + \"</div>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Grinse-Smiley";
            param.Regex = ";D";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\":D\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Youtube";
            param.Regex = "\\\\[youtube\\\\](?'Id'.+?)\\\\[/youtube\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<br /><br />\" +  Environment.NewLine + \"http://www.youtube.com/watch?v=\" + match.Groups[\"Id\"].Value +  Environment.NewLine + \"<br /><br />\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "WhatYaGotBlu";
            param.Regex = "\\\\[whatyagotblu=(?'Link'.+?)\\\\](?'Id'.+?)\\\\[/whatyagotblu\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<table border=\\\"0\\\"><tr><td><a href=\\\"http://\" + match.Groups[\"Link\"].Value + \"/index.php?lastmedia=\" + match.Groups[\"Id\"].Value + \"\\\"><img src=\\\"http://\" + match.Groups[\"Link\"].Value + \"/gfx/Banner_BluRay.png\\\" border=\\\"0\\\" width=\\\"180\\\"><br><img src=\\\"http://\" + match.Groups[\"Link\"].Value + \"/images/thumbnails/\" + match.Groups[\"Id\"].Value + \"f.jpg\\\" border=\\\"0\\\"></img></a></td></tr></table>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "FingerChew";
            param.Regex = ":fingerchew:";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<img src=\\\"http://www.dvdcollectorsonline.com/Smileys/classic/finger-chew.gif\\\">\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Drooling";
            param.Regex = ":drooling:";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<img src=\\\"http://www.dvdcollectorsonline.com/Smileys/classic/drool.gif\\\">\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Devil";
            param.Regex = ":devil:";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<img src=\\\"http://www.dvdcollectorsonline.com/Smileys/classic/smiley_devil.gif\\\">\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Durchgestrichener Text";
            param.Regex = "\\\\[s\\\\](?'Text'.+?)\\\\[/s\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<del>\" + match.Groups[\"Text\"].Value + \"</del>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "DailyMotion";
            param.Regex = "\\\\[dailymotion\\\\](?'Id'.+?)\\\\[/dailymotion\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"[DAILYMOTION \" + match.Groups[\"Id\"].Value + \"]\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Spoiler";
            param.Regex = "\\\\[spoiler(=(?'Hint'.+?))?\\\\](?'Text'.+?)\\\\[/spoiler\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<strong>Spoiler \" + ((match.Groups[\"Hint\"].Success) ? (\"\\\"\" + match.Groups[\"Hint\"].Value + \"\\\" \") : String.Empty) + \"(mark to read):</strong><br><div style=\\\"color: #FFFFFF;\\\">\" + match.Groups[\"Text\"].Value + \"</div>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Spoiler 2";
            param.Regex = "\\\\[spoiler2(=(?'Hint'.+?))?\\\\](?'Text'.+?)\\\\[/spoiler2\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<strong>Spoiler \" + ((match.Groups[\"Hint\"].Success) ? (\"\\\"\" + match.Groups[\"Hint\"].Value + \"\\\" \") : String.Empty) + \"(markieren zum lesen):</strong><br><span style=\\\"color: #FFFFFF;\\\">\" + match.Groups[\"Text\"].Value + \"</span>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Color";
            param.Regex = "\\\\[color=(?'Color'.+?)\\\\](?'Text'.+?)\\\\[/color\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<span style=\\\"color: \" + match.Groups[\"Color\"].Value + \";\\\">\" + match.Groups[\"Text\"].Value + \"</span>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Quote";
            param.Regex = "\\\\[quote\\\\](?'Text'.+?)\\\\[/quote\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<i>Zitat:</i>\" + Environment.NewLine + \"<hr />\" + Environment.NewLine + match.Groups[\"Text\"].Value + Environment.NewLine + \"<hr />\" + Environment.NewLine";
            parameters.Add(param);

            param = new Param();
            param.Name = "H2-Überschrift";
            param.Regex = "\\\\[size=12pt\\\\](?'Text'.+?)\\\\[/size\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<h2>\" + match.Groups[\"Text\"].Value + \"</h2>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "List";
            param.Regex = "\\\\[list\\\\](?'Text'.+?)\\\\[/list\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<ul>\" + match.Groups[\"Text\"].Value + \"</ul>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "ListItem";
            param.Regex = "\\\\[li\\\\](?'Text'.+?)\\\\[/li\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<li>\" + match.Groups[\"Text\"].Value + \"</li>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "ListItem 2";
            param.Regex = "\\\\[\\\\*\\\\](?'Text'.+?)\\r\\n";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase";
            param.Code = "\"<li>\" + match.Groups[\"Text\"].Value.TrimEnd() + \"</li>\" + Environment.NewLine";
            parameters.Add(param);

            param = new Param();
            param.Name = "Tabelle";
            param.Regex = "\\\\[table\\\\](?'Text'.+?)\\\\[/table\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<table>\" + match.Groups[\"Text\"].Value + \"</table>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Tabellenzeile";
            param.Regex = "\\\\[tr\\\\](?'Text'.+?)\\\\[/tr\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<tr>\" + match.Groups[\"Text\"].Value + \"</tr>\"";
            parameters.Add(param);

            param = new Param();
            param.Name = "Tabellenzelle";
            param.Regex = "\\\\[td\\\\](?'Text'.*?)\\\\[/td\\\\]";
            param.RegexOptions = "RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase";
            param.Code = "\"<td>\" + match.Groups[\"Text\"].Value + \"</td>\"";
            parameters.Add(param);

            ParamList paramList = new ParamList();

            paramList.Params = parameters.ToArray();

            Serializer<ParamList>.Serialize("ParamList.xml", paramList);
        }
    }
}