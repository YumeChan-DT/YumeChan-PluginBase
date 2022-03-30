using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace YumeChan.PluginBase.Tools;

public interface IWritableConfiguration : IConfiguration
{
	/// <summary>
	/// Current JSON path prefix in the configuration file.
	/// </summary>
	public string CurrentPrefix { get; }

	/// <summary>
	/// Loads the configuration from the JSON file.
	/// </summary>
	public Task LoadFromFileAsync();
	
	/// <summary>
	/// Save the configuration to the JSON file.
	/// </summary>
	public Task SaveToFileAsync();

	/// <summary>
	/// Gets the value of type <see cref="object"/> from the specified key.
	/// </summary>
	/// <param name="path">Key to read value from</param>
	/// <returns>Value of specified key</returns>
	public object GetValue(string path);
	
	/// <summary>
	/// Gets the value of type <see cref="T"/> from the specified key.
	/// </summary>
	/// <param name="path">Key to read value from</param>
	/// <typeparam name="T">Type to read value as</typeparam>
	/// <returns>Value of specified key</returns>
	public T GetValue<T>(string path);

	/// <summary>
	/// Sets the value of type <see cref="object"/> for the specified key.
	/// </summary>
	/// <param name="path">Key to set value to</param>
	/// <param name="value">Value to set</param>
	public void SetValue(string path, object value);
	
	/// <summary>
	/// Sets the value of type <see cref="T"/> for the specified key.
	/// </summary>
	/// <param name="path">Key to set value to</param>
	/// <param name="value">Value to set</param>
	/// <typeparam name="T">Type to set value as</typeparam>
	public void SetValue<T>(string path, T value);

	/// <summary>
	/// Gets section of the configuration with the specified prefix.
	/// </summary>
	/// <param name="prefix">Name of section</param>
	/// <returns>Section of type <see cref="IWritableConfiguration"/></returns>
	public new IWritableConfiguration GetSection(string prefix);
}
