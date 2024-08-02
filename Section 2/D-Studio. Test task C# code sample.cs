private void btnGetData_Click(object sender, EventArgs e)
{
    // clear previous request data
    string sRequest = "";
    lstData.Items.Clear();

    // format request string based upon user input
    if (cboHistoryType.Text.Equals("Tick Datapoints"))
    {
        // request in the format:
        // HTX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTX,{0},{1},{2},{3},{4}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Tick Days"))
    {
        // request in the format:
        // HTD,SYMBOL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTD,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtDays.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Tick Timeframe"))
    {
        // request in the format:
        // HTT,SYMBOL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTT,{0},{1},{2},{3},{4},{5},{6},{7},{8}\r\n", txtSymbol.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Interval Datapoints"))
    {
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HIX,SYMBOL,INTERVAL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE<CR><LF>
        sRequest = String.Format("HIX,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtInterval.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Interval Days"))
    {
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HID,SYMBOL,INTERVAL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
        sRequest = String.Format("HID,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}\r\n", txtSymbol.Text, txtInterval.Text, txtDays.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Interval Timeframe"))
    {
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HIT,SYMBOL,INTERVAL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
        sRequest = String.Format("HIT,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\r\n", txtSymbol.Text, txtInterval.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Daily Datapoints"))
    {
        // request in the format:
        // HDX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HDX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Daily Timeframe"))
    {
        // request in the format:
        // HDT,SYMBOL,BEGINDATE,ENDDATE,MAXDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HDT,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Weekly Datapoints"))
    {
        // request in the format:
        // HWX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HWX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Monthly Datapoints"))
    {
        // request in the format:
        // HMX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HMX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else
    {
        // something unexpected happened
        sRequest = "Error Processing Request.";
    }

    // verify we have formed a request string
    if (sRequest.StartsWith("H"))
    {
        // send it to the feed via the socket
        SendRequestToIQFeed(sRequest);
    }
    else
    {
        string sError = String.Format("{0}\r\nRequest type selected was: {1}", sRequest, cboHistoryType.Text);
        UpdateListview(sError);
    }

    // tell the socket we are ready to receive data
    WaitForData("History");
}
