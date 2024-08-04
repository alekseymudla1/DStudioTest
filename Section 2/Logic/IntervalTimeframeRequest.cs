namespace Logic
{
	// request in the format:
	// HIT,SYMBOL,INTERVAL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
	public class IntervalTimeframeRequest : SucceedRequest
	{
		protected override string Code => "HIT";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Interval,
			Parameters.BeginDateTime,
			Parameters.EndDateTime,
			Parameters.Datapoints,
			Parameters.BeginFilterTime,
			Parameters.EndFilterTime,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend,
			IntervalType,
			Parameters.BoxTimeStampChecked.BoolTo01String()
		];

		public IntervalTimeframeRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
