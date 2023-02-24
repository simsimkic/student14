// File:    OperatingRoomReport.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class OperatingRoomReport


using System;

public class OperatingRoomReport : Report
{
    public Room OperatingRoom { get; set; }
    
    public OperatingRoomReport(string reportId) : base(reportId) { }
    public OperatingRoomReport(Room operatingRoom, DateTime startDate, DateTime endDate, string reportId, string content):base(startDate,endDate,reportId, content)
    {
        OperatingRoom = operatingRoom;
    }


}
