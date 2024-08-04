namespace Logic
{
	public class RequestFabric
	{
		private readonly UIParameters _parameters;
		public RequestFabric(UIParameters parameters)
		{
			_parameters = parameters;
		}

		public Request Create()
		{
			return _parameters.HistoryType switch
			{
				"Tick Datapoints" => new TickDatapointsRequest(_parameters),
				"Tick Days" => new TickDaysRequest(_parameters),
				"Tick Timeframe" => new TickTimeframeRequset(_parameters),
				"Interval Datapoints" => new IntervalDatapointsRequset(_parameters),
				"Interval Days" => new IntervalDaysRequset(_parameters),
				"Interval Timeframe" => new IntervalTimeframeRequest(_parameters),
				"Daily Datapoints" => new DailyDatapointsRequest(_parameters),
				"Daily Days" => new DailyTimeframeRequest(_parameters),
				"Weekly Datapoints" => new WeeklyDatapointsRequest(_parameters),
				"Monthly Datapoints" => new MonthlyDatapointsRequest(_parameters),
				_ => new ErrorRequest()
			};
		}
	}
}
