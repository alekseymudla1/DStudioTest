namespace Logic
{
	// request in the format:
	// HDX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class DailyDatapointsRequest : DatapointsRequest
	{
		protected override string Code => "HDX";

		public DailyDatapointsRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
