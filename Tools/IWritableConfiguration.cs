using System.Threading.Tasks;

namespace YumeChan.PluginBase.Tools;

public interface IWritableConfiguration
{
	public string CurrentPrefix { get; }


	public string this[string parameter] { get; set; }

	public Task LoadFromFileAsync();
	public Task SaveToFileAsync();

	public object GetValue(string parameter);
	public T GetValue<T>(string parameter);

	public void SetValue(string parameter, object value);
	public void SetValue<T>(string parameter, T value);

	public IWritableConfiguration GetSection(string sectionName);
}
