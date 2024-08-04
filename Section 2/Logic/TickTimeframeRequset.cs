namespace Logic
{
	// request in the format:
	// HTT,SYMBOL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class TickTimeframeRequset : SucceedRequest
	{
		protected override string Code => "HTT";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.BeginDateTime,
			Parameters.EndDateTime,
			Parameters.Datapoints,
			Parameters.BeginFilterTime,
			Parameters.EndFilterTime,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend
		];

		public TickTimeframeRequset(UIParameters parameters) : base(parameters)
		{

		}
	}
}
