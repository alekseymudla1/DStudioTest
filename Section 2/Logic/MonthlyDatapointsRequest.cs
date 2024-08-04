namespace Logic
{
	// request in the format:
	// HMX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class MonthlyDatapointsRequest : DatapointsRequest
	{
		protected override string Code => "HMX";

		public MonthlyDatapointsRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
