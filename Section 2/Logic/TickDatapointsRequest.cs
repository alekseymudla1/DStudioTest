namespace Logic
{
	// request in the format:
	// HTX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class TickDatapointsRequest : SucceedRequest
	{
		protected override string Code => "HTX";

		public TickDatapointsRequest(UIParameters parameters) : base(parameters)
		{

		}

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Datapoints,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend
			];

		public override bool IsError => false;
	}
}
