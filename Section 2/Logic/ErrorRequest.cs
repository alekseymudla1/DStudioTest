namespace Logic
{
	public class ErrorRequest : Request
	{
		public override bool IsError => true;
		public override string RequestString => "Error Processing Request.";
	}
}
