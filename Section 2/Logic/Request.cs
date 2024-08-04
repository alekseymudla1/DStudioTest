namespace Logic
{
	public abstract class Request
	{

		protected readonly UIParameters Parameters;

		public abstract string RequestString { get; }

		public abstract bool IsError { get; }

		protected Request()
		{
		}

		protected Request(UIParameters parameters)
		{
			Parameters = parameters;
		}
	}
}
