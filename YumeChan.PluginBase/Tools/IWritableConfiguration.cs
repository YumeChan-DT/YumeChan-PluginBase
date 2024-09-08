using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

/*
 *	IWritableConfiguration.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase.Tools;

/// <summary>
/// Specifies a writable configuration object,
/// which can be used to read and write values by key based on a JSON file.
/// </summary>
[PublicAPI]
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
	/// Saves the configuration to the JSON file.
	/// </summary>
	public Task SaveToFileAsync();

	/// <summary>
	/// Gets the value of type <see cref="object"/> from the specified key.
	/// </summary>
	/// <param name="path">Key to read value from</param>
	/// <returns>Value of specified key</returns>
	public object? GetValue(string path);
	
	/// <summary>
	/// Gets the value of type <see cref="TValue"/> from the specified key,
	/// or null if the value cannot be casted or is not found.
	/// </summary>
	/// <param name="path">Key to read value from</param>
	/// <typeparam name="TValue">Type to read value as</typeparam>
	/// <returns>Value of specified key or null</returns>
	public TValue? GetValue<TValue>(string path);

	/// <summary>
	/// Sets the value of type <see cref="object"/> for the specified key.
	/// </summary>
	/// <param name="path">Key to set value to</param>
	/// <param name="value">Value to set</param>
	public void SetValue(string path, object? value);
	
	/// <summary>
	/// Sets the value of type <see cref="TValue"/> for the specified key.
	/// </summary>
	/// <param name="path">Key to set value to</param>
	/// <param name="value">Value to set</param>
	/// <typeparam name="TValue">Type to set value as</typeparam>
	public void SetValue<TValue>(string path, TValue? value);

	/// <summary>
	/// Gets section of the configuration with the specified prefix.
	/// </summary>
	/// <param name="prefix">Name of section</param>
	/// <returns>Section of type <see cref="IWritableConfiguration"/></returns>
	public new IWritableConfiguration GetSection(string prefix);
}
