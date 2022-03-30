namespace YumeChan.PluginBase.Tools;

public interface IJsonConfigProvider<out TPlugin> where TPlugin : IPlugin
{
	IWritableConfiguration GetConfiguration(string filename, bool autosave = true, bool autoreload = true);
}