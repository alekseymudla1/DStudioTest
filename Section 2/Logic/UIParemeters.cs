namespace Logic
{
	public record UIParameters(
		string HistoryType,
		string Symbol,
		string Datapoints,
		string Direction,
		string RequestID,
		string DatapointsPerSend,
		string Days,
		string BeginFilterTime,
		string EndFilterTime,
		string BeginDateTime,
		string EndDateTime,
		string Interval,
		bool BoxTimeStampChecked,
		bool AppendTickChecked,
		bool VolumeChecked,
		bool TickChecked);
}
