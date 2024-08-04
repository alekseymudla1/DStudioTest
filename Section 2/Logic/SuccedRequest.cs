using System.Text;

namespace Logic
{
	public abstract class SucceedRequest : Request
	{
		protected abstract string Code { get; }

		protected abstract string[] Elements { get; }

		protected SucceedRequest(UIParameters parameters) : base(parameters)
		{

		}

		// validate interval type
		protected string IntervalType => Parameters.VolumeChecked ? "v" : Parameters.TickChecked ? "t" : "s";

		public override bool IsError => false;

		public override string RequestString => new StringBuilder(String.Join(",", Elements)).Append("\r\n").ToString();
	}
}
