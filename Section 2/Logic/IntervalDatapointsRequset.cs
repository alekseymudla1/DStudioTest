namespace Logic
{
	// request in the format:
	// HIX,SYMBOL,INTERVAL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE<CR><LF>
	public class IntervalDatapointsRequset : SucceedRequest
	{
		protected override string Code => "HIX";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Interval,
			Parameters.Datapoints,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend,
			IntervalType,
			Parameters.BoxTimeStampChecked.BoolTo01String()
		];

		public IntervalDatapointsRequset(UIParameters parameters) : base(parameters)
		{

		}
	}
}
