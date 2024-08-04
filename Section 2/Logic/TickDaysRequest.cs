namespace Logic
{
	// request in the format:
	// HTD,SYMBOL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class TickDaysRequest : SucceedRequest
	{
		protected override string Code => "HTD";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Days,
			Parameters.Datapoints,
			Parameters.BeginFilterTime,
			Parameters.EndFilterTime,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend
		];

		public TickDaysRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
