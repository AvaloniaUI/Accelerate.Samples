using Android.App;
using Android.Content.PM;
using Avalonia.Media.Android;
using Avalonia.Android;
using Avalonia.Vulkan;

namespace Avalonia.Media.Demo.Android;

[Activity(
    Label = "Avalonia.Media.Demo.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .UseAndroidPlayer(this)
            .With(new VulkanOptions()
            {
                VulkanDeviceCreationOptions = new VulkanDeviceCreationOptions()
                {
                    DeviceExtensions = new[] { "VK_ANDROID_external_memory_android_hardware_buffer", "VK_EXT_queue_family_foreign" }
                },
                VulkanInstanceCreationOptions = new VulkanInstanceCreationOptions()
                {
                    UseDebug = true
                }
            })
            .WithInterFont()
            .LogToTrace();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
