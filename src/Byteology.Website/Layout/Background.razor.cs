namespace Byteology.Website.Layout;

using System.Globalization;
using System.Text;

public partial class Background : ComponentBase
{
	private int _opacity = 0;

	private readonly Random _random = new(181582722);

	private string getFireflyStyle()
	{
		int top = _random.Next(0, 100);
		int left = _random.Next(0, 100);

		int duration = _random.Next(60, 240);
		int delay = _random.Next(-500, 0);
		int originX = _random.Next(-25, 25);
		int originY = _random.Next(-25, 25);

		float blurRadius = (float)Math.Round(_random.NextSingle() + 0.25f, 5);
		float fadeInDelay = _random.NextSingle() * 2 + 0.25f;

		StringBuilder result = new();
		result.Append($"--top: {top}%;");
		result.Append($"--left: {left}%;");
		result.Append($"--orbit-duration: {duration}s;");
		result.Append($"--orbit-delay: {delay}s;");
		result.Append($"--orbit-point: {originX}vw {originY}vh;");
		result.Append($"--blur-radius: {blurRadius.ToString(CultureInfo.InvariantCulture)}vmin;");
		result.Append($"--opacity: {_opacity};");
		result.Append($"--fade-in-delay: {fadeInDelay.ToString("0.00", CultureInfo.InvariantCulture)}s;");

		return result.ToString();
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (firstRender)
		{
			_opacity = 1;
			StateHasChanged();
		}
	}
}
