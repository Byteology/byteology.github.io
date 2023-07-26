namespace Byteology.Website.Shared.MarkdownRendering;

using System.Text;
using System.Text.RegularExpressions;
using Markdig;

public partial class MarkdownParser
{
	[GeneratedRegex(@"(<\s*h(?<openHDecimal>\d)\s*>)|(<\s*h(?<openHDecimal>\d)\s+[^>]*>)|(<\s*/\s*h(?<closeHDecimal>\d)\s*>)|(<\s*(?<hr>hr)\s*>)|(<\s*(?<hr>hr)\s*/\s*>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getSplitRegex();


	private ParsingState _parsingState = new();
	private string _rawData;
	private StringBuilder _intro { get; } = new();
	private StringBuilder _content { get; } = new();

	private List<int> _lastHeadingId = new();
	private List<PaperIndexData> _indexData = new();

	public MarkdownParser(string markdown, MarkdownPipeline markdownPipeline)
	{
		string htmlString = Markdown.ToHtml(markdown, markdownPipeline).Trim();
		_rawData = htmlString;
		_content.AppendLine("<section>");

		Match match = getSplitRegex().Match(htmlString);

		while (match.Success)
		{
			MatchInfo matchInfo = new(match);
			match = match.NextMatch();

			fillData(matchInfo);

			if (matchInfo.IsOpenTag)
				handleOpenHeading(matchInfo);
			else if (matchInfo.IsCloseTag)
				handleCloseHeading(matchInfo);
			else if (matchInfo.IsRulerTag)
				handleRuler(matchInfo);
		}

		appendRemainingData();
	}

	public string GetIntro() => _intro.ToString();
	public string GetContent() => _content.ToString();
	public IEnumerable<PaperIndexData> GetIndexData() => _indexData;

	private void fillData(MatchInfo matchInfo)
	{
		if (matchInfo.Index == _parsingState.ParsedCharacters)
			return;

		if (_parsingState.HeadingOpened)
			return;

		string data = string.Empty;
		if (matchInfo.Index > _parsingState.ParsedCharacters)
			data = _rawData[_parsingState.ParsedCharacters..matchInfo.Index];

		if (!string.IsNullOrWhiteSpace(data))
			appendData(data);

		_parsingState.ParsedCharacters = matchInfo.Index;
	}
	private void handleRuler(MatchInfo matchInfo)
	{
		_parsingState.IntroFilled = true;

		if (_parsingState.CardOpened)
			closeCard();

		if (_parsingState.SubsectionOpened)
			closeSubsection();

		if (_parsingState.SectionStarted)
			openNewSection();

		_parsingState.ParsedCharacters = matchInfo.Index + matchInfo.Value.Length;

	}
	private void handleOpenHeading(MatchInfo matchInfo)
	{
		if (matchInfo.HDecimal > 1)
			_parsingState.IntroFilled = true;

		_parsingState.HeadingOpened = true;
		_parsingState.OpenedHeadingDecimalRelativeIndex = matchInfo.OpenHeadingDecimalRelativeIndex;

		if (matchInfo.HDecimal == 2)
		{
			if (_parsingState.CardOpened)
				closeCard();

			if (_parsingState.SubsectionOpened)
				closeSubsection();

			if (_parsingState.SectionStarted)
				openNewSection();
		}
		else if (matchInfo.HDecimal == 3)
		{
			if (_parsingState.CardOpened)
				closeCard();
			if (_parsingState.SubsectionOpened)
				closeSubsection();

			openSubsection();
		}
		else if (matchInfo.HDecimal == 4)
		{
			if (_parsingState.CardOpened)
				closeCard();

			openCard();
		}
	}
	private void handleCloseHeading(MatchInfo matchInfo)
	{
		_parsingState.HeadingOpened = false;
		if (matchInfo.HDecimal > 1)
		{
			string headingValue = constructHeading(matchInfo);
			appendData(headingValue);
		}

		_parsingState.ParsedCharacters = matchInfo.Index + matchInfo.Value.Length;
	}

	private string constructHeading(MatchInfo matchInfo)
	{
		string heading = _rawData[_parsingState.ParsedCharacters..(matchInfo.Index + matchInfo.Value.Length)];

		if (matchInfo.HDecimal > 1 && matchInfo.HDecimal < 4)
		{
			string headingName = getNextHeadingName(matchInfo.HDecimal - 2);
			heading = heading.Insert(_parsingState.OpenedHeadingDecimalRelativeIndex + 1, $" name=\"{headingName}\" ");
			_indexData.Add(new PaperIndexData(headingName, heading));
		}

		return heading;
	}
	private string getNextHeadingName(int level)
	{
		if (level > _lastHeadingId.Count - 1)
			_lastHeadingId.Add(1);
		else if (level == _lastHeadingId.Count - 1)
			_lastHeadingId[level]++;
		else
		{
			_lastHeadingId[level]++;
			_lastHeadingId.RemoveRange(level + 1, _lastHeadingId.Count - level - 1);
		}

		return "section-" + string.Join('-', _lastHeadingId.Select(x => x.ToString()));
	}


	private void closeCard()
	{
		appendData("</b-card>");
		_parsingState.CardOpened = false;
	}
	private void closeSubsection()
	{
		appendData("</b-subsection>");
		_parsingState.SubsectionOpened = false;
	}
	private void openNewSection()
	{
		appendData("</section>");
		appendData("<section>");
		_parsingState.SectionStarted = false;
	}
	private void openSubsection()
	{
		appendData("<b-subsection>");
		_parsingState.SubsectionOpened = true;
	}
	private void openCard()
	{
		appendData("<b-card>");
		_parsingState.CardOpened = true;
	}

	private void appendData(string data)
	{
		if (_parsingState.IntroFilled)
		{
			_content.AppendLine(data);
			_parsingState.SectionStarted = true;
		}
		else
			_intro.AppendLine(data);
	}
	private void appendRemainingData()
	{
		if (_parsingState.ParsedCharacters != _rawData.Length)
			appendData(_rawData[_parsingState.ParsedCharacters..]);

		_parsingState.ParsedCharacters = _rawData.Length;

		if (_parsingState.SectionStarted)
			_content.AppendLine("</section>");
		else
			_content.Remove(_content.Length - "<section>\n".Length, "<section>\n".Length);
	}

	private sealed class MatchInfo
	{
		public bool IsOpenTag { get; }
		public bool IsCloseTag { get; }
		public bool IsRulerTag { get; }
		public int HDecimal { get; }
		public int OpenHeadingDecimalRelativeIndex { get; }
		public string Value { get; }
		public int Index { get; }

		public MatchInfo(Match match)
		{
			Value = match.Value;
			Index = match.Index;

			Group openHeadingDecimalGroup = match.Groups["openHDecimal"];
			Group closedHeadingDecimalGroup = match.Groups["closeHDecimal"];
			Group hrGroup = match.Groups["hr"];

			if (openHeadingDecimalGroup.Success)
			{
				HDecimal = int.Parse(openHeadingDecimalGroup.Value);
				OpenHeadingDecimalRelativeIndex = openHeadingDecimalGroup.Index - match.Index;
				IsOpenTag = true;
				IsCloseTag = false;
				IsRulerTag = false;
			}
			else if (closedHeadingDecimalGroup.Success)
			{
				HDecimal = int.Parse(closedHeadingDecimalGroup.Value);
				IsOpenTag = false;
				IsCloseTag = true;
				IsRulerTag = false;
			}
			else if (hrGroup.Success)
			{
				HDecimal = 0;
				IsOpenTag = false;
				IsCloseTag = false;
				IsRulerTag = true;
			}
		}
	}

	private sealed class ParsingState
	{
		public int ParsedCharacters { get; set; }
		public bool HeadingOpened { get; set; }
		public int OpenedHeadingDecimalRelativeIndex { get; set; }
		public bool IntroFilled { get; set; }
		public bool SubsectionOpened { get; set; }
		public bool CardOpened { get; set; }
		public bool SectionStarted { get; set; }
	}
}