using JetBrains.Annotations;

/*
 *	IRunnerContext.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under MIT	License.
 */

namespace YumeChan.PluginBase.Tools;

/// <summary>
/// Provides contextual information about the YumeCore's host (Runner).
/// </summary>
/// <remarks>
///	This class should be implemented directly by the Runner, and the Core should not touch any implementation details.
/// </remarks>
[PublicAPI]
public interface IRunnerContext
{
	RunnerType RunnerType { get; }
	
	string RunnerName { get; }
	string RunnerVersion { get; }
}

/// <summary>
/// Defines the type of a runner.
/// </summary>
[PublicAPI]
public enum RunnerType
{
	/// <summary>
	/// Not a known runner, or following types are not applicable to the host.
	/// </summary>
	Other,
	
	/// <summary>
	/// Represents a runner that is a console application.
	/// </summary>
	Console,
	
	/// <summary>
	/// Represents a runner that is a Web application.
	/// </summary>
	Net
}