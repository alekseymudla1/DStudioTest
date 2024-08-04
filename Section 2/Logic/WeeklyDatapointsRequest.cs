namespace Logic
{
	// request in the format:
	// HWX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
	public class WeeklyDatapointsRequest : DatapointsRequest
	{
		protected override string Code => "HWX";

		public WeeklyDatapointsRequest(UIParameters parameters) : base(parameters)
		{

		}
	}
}
