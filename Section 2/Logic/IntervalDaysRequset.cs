namespace Logic
{
	// request in the format:
	// HID,SYMBOL,INTERVAL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
	public class IntervalDaysRequset : SucceedRequest
	{
		protected override string Code => "HID";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Interval,
			Parameters.Days,
			Parameters.Datapoints,
			Parameters.BeginFilterTime,
			Parameters.EndFilterTime,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend,
			IntervalType,
			Parameters.BoxTimeStampChecked.BoolTo01String()
		];

		public IntervalDaysRequset(UIParameters parameters) : base(parameters)
		{

		}
	}
}
