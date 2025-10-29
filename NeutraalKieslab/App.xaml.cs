using System.Windows;

namespace NeutraalKieslab;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Initialize application-wide settings
        InitializeGlobalSettings();
    }

    private static void InitializeGlobalSettings()
    {
        // Set application-wide font rendering for better text clarity
        System.Windows.Media.RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.Default;
    }

    protected override void OnExit(ExitEventArgs e)
    {
        // Cleanup code if needed
        base.OnExit(e);
    }
}