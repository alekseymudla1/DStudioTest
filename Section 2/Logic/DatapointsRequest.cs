namespace Logic
{
	// request in the format:
	// {CODE},SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public abstract class DatapointsRequest : SucceedRequest
	{
		protected DatapointsRequest(UIParameters parameters) : base(parameters)
		{

		}

		protected override string[] Elements => [ Code,
			Parameters.Symbol,
			Parameters.Datapoints,
			Parameters.Direction,
			Parameters.RequestID,
			Parameters.DatapointsPerSend,
			Parameters.AppendTickChecked.BoolTo01String()
		];
	}
}
