namespace Logic
{
	// request in the format:
	// HDT,SYMBOL,BEGINDATE,ENDDATE,MAXDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class DailyTimeframeRequest : SucceedRequest
	{
		protected override string Code => "HDT";

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.BeginDateTime,
			Parameters.EndDateTime,
			Parameters.Datapoints,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend,
			Parameters.AppendTickChecked.BoolTo01String()
		];

		public DailyTimeframeRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
