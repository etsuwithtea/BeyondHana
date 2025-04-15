using Microsoft.Extensions.Logging;

namespace BeyondHana;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                // Add custom fonts
                fonts.AddFont("Itim-Regular.ttf", "ItimRegular");
                fonts.AddFont("Caveat-Regular.ttf", "CaveatRegular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
