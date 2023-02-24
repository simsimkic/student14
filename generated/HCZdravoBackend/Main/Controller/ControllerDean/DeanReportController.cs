using Service.ServiceDean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controller.ControllerDean
{
    public class DeanReportController
    {
        private DeanReportServices _deanReportServices;

        public DeanReportController(DeanReportServices drs)
        {
            this._deanReportServices = drs;
        }

        public void DownloadReport(ScheduleReport report)
        {
            this._deanReportServices.DownloadReport(report);
        }

        public List<ScheduleReport> GetAll()
        {
            return this._deanReportServices.GetAllReports();
        }

        public ScheduleReport Get(string id)
        {
            return this._deanReportServices.GetReport(id);
        }

        public ScheduleReport Get(DateTime start, DateTime end, Room room)
        {
            return this._deanReportServices.GenerateScheduleReport(start, end, room);
        }

    }
}
