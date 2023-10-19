﻿using Microsoft.Extensions.Logging;
using MauiApp1.ViewModel;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        //System.Diagnostics.Debug.WriteLine("MauiProgram");
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<DetailPage>();
		builder.Services.AddTransient<DetailViewModel>();

		return builder.Build();
	}
}
