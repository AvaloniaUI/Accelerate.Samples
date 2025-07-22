using System;
using Avalonia;
using Avalonia.LinuxFramebuffer;

namespace Avalonia.Media.Demo.LinuxFB;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        // DRI paths can change. Try all the devices under /dev/dri/* if the default doesn't work.
        .StartLinuxDrm(args: args, card: "/dev/dri/card1", scaling: 1.0);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
