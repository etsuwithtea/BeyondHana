using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;


namespace BeyondHana;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()           
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
                // Add custom fonts
                fonts.AddFont("Itim-Regular.ttf", "ItimRegular");
                fonts.AddFont("Caveat-Regular.ttf", "CaveatRegular");
            });
        // Add the Audio plugin
        builder.AddAudio();
        //builder.Services.AddSingleton(AudioManager.Current);
        //builder.Services.AddTransient<Views.TitlePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
