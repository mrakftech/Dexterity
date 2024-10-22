using DailyCo.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Database;
using Dexterity.Extensions;
using Dexterity.UiServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;
using Radzen;
using Services.DbInitaiizer;
using Services.State;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Dexterity
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var configuration = builder.Configuration;
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });
            builder.Services.AddTransient<SnackbarNotificationService>();
          
            
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddRadzenComponents();
           
            SyncfusionLicenseProvider
                .RegisterLicense("MzQwNDg0MEAzMjM2MmUzMDJlMzBTNG1aeW5QUnNCU25pQmhReTRwdUk1VEVscXpLbE1MTUZmanJoYVo3SzhJPQ==");
            builder.Services.AddBlazorContextMenu(options =>
            {
                options.ConfigureTemplate("myTemplate", template =>
                {
                    template.MenuCssClass = "my-menu";
                    template.MenuItemCssClass = "my-menu-item";
                    //...
                });
            });
#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                // Make sure to add "using Microsoft.Maui.LifecycleEvents;" in the top of the file 
                events.AddWindows(windowsLifecycleBuilder =>
                {
                    windowsLifecycleBuilder.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = false;
                        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                        appWindow.Title = "Dexterity";
                        switch (appWindow.Presenter)
                        {
                            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                                overlappedPresenter.SetBorderAndTitleBar(true, true);
                                overlappedPresenter.Maximize();
                                overlappedPresenter.IsResizable = false;
                                overlappedPresenter.IsMaximizable = true;

                                break;
                        }
                    });
                    windowsLifecycleBuilder.OnClosed((window, args) =>
                    {
                        DeleteDailyRoomMeetingIfExists(builder.Services.BuildServiceProvider());
                    });
                });
            });
#endif
#if WINDOWS
            builder.Services.AddTransient<ITrayService, TrayService>();
#endif
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMauiBlazorWebView();
        
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("AppConnection")),
                     ServiceLifetime.Transient
                )
                .AddTransient<IDatabaseSeeder, DatabaseSeeder>();
            builder.Services.AddRepositories();
            builder.Services.AddExternalApis();
            builder.Services.AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                configuration.SnackbarConfiguration.ShowCloseIcon = false;
            });
            builder.Services.AddMudExtensions();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        private static void DeleteDailyRoomMeetingIfExists(IServiceProvider serviceProvider)
        {
            Task.Run(async () =>
            {
                if (!string.IsNullOrWhiteSpace(ApplicationState.Telehealth.MeetingName))
                {
                    var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                    var roomEndpoints = new RoomEnpoints(httpClientFactory);
                    await roomEndpoints.DeleteRoom(ApplicationState.Telehealth.MeetingName);
                    ApplicationState.Telehealth.MeetingName = string.Empty;
                    ApplicationState.Telehealth.MeetingLink = string.Empty;

                }
            }).GetAwaiter().GetResult();
        }
    }
}