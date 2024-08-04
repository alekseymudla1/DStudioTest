using Logic;

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
	string error = String.Format("{0}\r\nRequest type selected was: {1}", request, parameters.HistoryType);
	UpdateListview(error);
}