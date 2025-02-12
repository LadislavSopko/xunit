using System;
using Xunit.Internal;

namespace Xunit.v3;

/// <summary>
/// Base message for all messages related to test assemblies.
/// </summary>
public class _TestAssemblyMessage : _MessageSinkMessage
{
	string? assemblyUniqueID;

	/// <summary>
	/// Gets the assembly's unique ID. Can be used to correlate test messages with the appropriate
	/// assembly that they're related to. Assembly metadata (as <see cref="_IAssemblyMetadata"/>) is
	/// provided via <see cref="_DiscoveryStarting"/> (during discovery) and/or
	/// <see cref="_TestAssemblyStarting"/> (during execution) and should be cached as needed.
	/// </summary>
	public string AssemblyUniqueID
	{
		get => assemblyUniqueID ?? throw new InvalidOperationException($"Attempted to get {nameof(AssemblyUniqueID)} on an uninitialized '{GetType().FullName}' object");
		set => assemblyUniqueID = Guard.ArgumentNotNullOrEmpty(value, nameof(AssemblyUniqueID));
	}

	/// <inheritdoc/>
	public override string ToString() =>
		$"{GetType().Name}({assemblyUniqueID.Quoted()})";
}

