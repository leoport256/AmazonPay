using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace AmazonPayHttpClient.Contracts.Newtonsoft;

/// <summary>
/// Report Types
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ProcessingStatus
{
	/// <summary>
	/// The report is being processed.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	IN_PROGRESS,

	/// <summary>
	/// The report has completed processing.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	COMPLETED,

	/// <summary>
	/// The report was aborted due to a fatal error.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	FAILED,

	/// <summary>
	/// The report was cancelled. There are two ways a report can be cancelled: an explicit cancellation request before the report starts processing, or an automatic cancellation if there is no data to return.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	CANCELLED
}