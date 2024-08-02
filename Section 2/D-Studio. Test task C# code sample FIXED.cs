private void btnGetData_Click(object sender, EventArgs e)
{

	// send it to the feed via the socket // clear previous request data
	lstData.Items.Clear();

	var parameters = new UIParameters(
			cboHistoryType.Text,
			txtSymbol.Text,
			txtDatapoints.Text,
			txtDirection.Text,
			txtRequestID.Text,
			txtDatapointsPerSend.Text,
			txtDays.Text,
			txtBeginFilterTime.Text,
			txtEndFilterTime.Text,
			txtBeginDateTime.Text,
			txtEndDateTime.Text,
			txtInterval.Text,
			chkBoxTimeStamp.Checked,
			chbAppendTick.Checked,
			rbVolume.Checked,
			rbTick.Checked
		);

	var request = new RequestFabric(parameters).Create();


	// verify we have formed a request string
	if (request.IsError)
	{
		UpdateListview(request, parameters);
	}
	else
	{
		// send it to the feed via the socket
		SendRequestToIQFeed(request);
	}

	// tell the socket we are ready to receive data
	WaitForData("History");
}

private void UpdateListview(Request request, UIParameters parameters)
{
	string error = String.Format("{0}\r\nRequest type selected was: {1}", sRequest, cboHistoryType.Text);
	UpdateListview(error);
}

public record UIParameters(
	string HistoryType,
	string Symbol,
	string Datapoints,
	string Direction,
	string RequestID,
	string DatapointsPerSend,
	string Days,
	string BeginFilterTime,
	string EndFilterTime,
	string BeginDateTime,
	string EndDateTime,
	string Interval,
	bool BoxTimeStampChecked,
	bool AppendTickChecked,
	bool VolumeChecked,
	bool TickChecked);

public abstract class Request
{
	protected abstract string Template { get; init; }
	protected readonly UIParameters _parameters;

	public abstract string Request { get; }

	public abstract bool IsError { get; }

	protected Request()
	{

	}

	protected Request(UIParameters parameters)
	{
		_parameters = parameters;
	}

	protected string IntervalType => VolumeChecked ? "v" : TickChecked ? "t" : "s";
}

public class TickDatapointsRequest : Request
{
	public TickDatapointsRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HTX,{0},{1},{2},{3},{4}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Datapoints,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend);
}

public class TickDaysRequest : Request
{
	public TickDaysRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HTD,{0},{1},{2},{3},{4},{5},{6},{7}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Days,
				_parameters.Datapoints,
				_parameters.BeginFilterTime,
				_parameters.EndFilterTime,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend);
}

public class TickTimeframeRequset : Request
{
	public TickTimeframeRequset(UIParameters parameters) : base(parameters)
	{
		Template = "HTT,{0},{1},{2},{3},{4},{5},{6},{7},{8}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.BeginDateTime,
				_parameters.EndDateTime,
				_parameters.Datapoints,
				_parameters.BeginFilterTime,
				_parameters.EndFilterTime,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend);
}

public class IntervalDatapointsRequset : Request
{
	public IntervalDatapointsRequset(UIParameters parameters) : base(parameters)
	{
		Template = "HIX,{0},{1},{2},{3},{4},{5},{6},{7}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Interval,
				_parameters.Datapoints,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend,
				IntervalType,
				_parameters.BoxTimeStampChecked ? 1 : 0);
}

public class IntervalDaysRequset : Request
{
	public IntervalDaysRequset(UIParameters parameters) : base(parameters)
	{
		Template = "HID,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Interval,
				_parameters.Days,
				_parameters.Datapoints,
				_parameters.BeginFilterTime,
				_parameters.EndFilterTime,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend,
				IntervalType,
				_parameters.BoxTimeStampChecked ? 1 : 0);
}

public class IntervalTimeframeRequest : Request
{
	public IntervalTimeframeRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HIT,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Interval,
				_parameters.BeginDateTime,
				_parameters.EndDateTime,
				_parameters.Datapoints,
				_parameters.BeginFilterTime,
				_parameters.EndFilterTime,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend,
				IntervalType,
				_parameters.BoxTimeStampChecked ? 1 : 0);
}

public abstract class DatapointsRequest : Request
{
	public DatapointsRequest(UIParameters parameters) : base(parameters)
	{
		
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.Datapoints,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend,
				_parameters.AppendTickChecked ? 1 : 0);
}

public abstract class DailyDatapointsRequest : DatapointsRequest
{
	public DailyDatapointsRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HDX,{0},{1},{2},{3},{4},{5}\r\n";
	}
}

public abstract class WeeklyDatapointsRequest : DatapointsRequest
{
	public WeeklyDatapointsRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HWX,{0},{1},{2},{3},{4},{5}\r\n";
	}
}

public abstract class MonthlyDatapointsRequest : DatapointsRequest
{
	public MonthlyDatapointsRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HMX,{0},{1},{2},{3},{4},{5}\r\n";
	}
}

public class DailyTimeframeRequest: Request
{
	public DailyTimeframeRequest(UIParameters parameters) : base(parameters)
	{
		Template = "HDT,{0},{1},{2},{3},{4},{5},{6},{7}\r\n";
	}

	public bool IsError => false;

	public string Request =>
			String.Format(Template,
				_parameters.Symbol,
				_parameters.BeginDateTime,
				_parameters.EndDateTime,
				_parameters.Datapoints,
				_parameters.Direction,
				_parameters.RequestID,
				_parameters.DatapointsPerSend,
				_parameters.AppendTickChecked ? 1 : 0);
}

public class ErrorRequest : Request
{
	public bool IsError => true;
	public string Request => "Error Processing Request.";
}

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

