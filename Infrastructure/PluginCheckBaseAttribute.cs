﻿using DSharpPlus.CommandsNext.Attributes;

/**
 *	PluginCheckDatabaseAttribute.cs
 *	Licensed by YumeChan-DT (Nodsoft Systems) under GNU-LGPL v2.1
 **/

namespace YumeChan.PluginBase.Infrastructure
{
	/// <summary>
	/// Provides a base class for all Plugins implementing Command pre-execution checks.
	/// </summary>
	public abstract class PluginCheckBaseAttribute : CheckBaseAttribute
	{
		/// <summary>
		/// Error returned if this check fails.
		/// </summary>
		public abstract string ErrorMessage { get; protected set; }
	}
}
