namespace YumeChan.PluginBase.Tools;
// ReSharper disable once UnusedTypeParameter

/// <summary>
/// Provides a configuration provider for JSON key-value based configuration files.
/// </summary>
/// <typeparam name="TPlugin">Type of the plugin's manifest.</typeparam>

public interface IJsonConfigProvider<out TPlugin> where TPlugin : IPlugin
{
	/// <summary>
	/// Provides a configuration instance for the specified filename.
	/// </summary>
	/// <param name="filename">JSON filename</param>
	/// <param name="autosave">Enable autosave on configuration modifications (e.g: runtime SetValue calls) (defaults to enabled)</param>
	/// <param name="autoreload">Enable autoreload on configuration modifications (e.g: modified from disk, or another instance) (defaults to enabled)</param>
	IWritableConfiguration GetConfiguration(string filename, bool autosave = true, bool autoreload = true);
}