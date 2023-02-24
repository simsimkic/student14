// File:    DeanReportServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Class DeanReportServices

using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using Repository.RepositoryReport;
using Service.ServiceAppointment;
using Service.ServiceRoom;
using System;
using System.Collections.Generic;

namespace Service.ServiceDean
{
    public class DeanReportServices
    {
        private ExaminationService _examService;
        private OperationService _opService;
        private IScheduleReportRepository _scheduleReportRepo;

        public DeanReportServices(ScheduleReportRepository schrepo, ExaminationService exserv, OperationService opserv)
        {
            this._examService = exserv;
            this._opService = opserv;
            this._scheduleReportRepo = schrepo;
        }

        private bool SaveReport(ScheduleReport report)
        {
            return this._scheduleReportRepo.Update(report);
        }

        public ScheduleReport GenerateScheduleReport(DateTime from, DateTime until, Room room)
        {
            string id = from.ToString("MM/dd/yyyy").Replace("/", "") + until.ToString("MM/dd/yyyy").Replace("/", "") + room.Id;
            string content = "";
            switch (room.RoomType)
            {
                case RoomType.EXAMROOM:
                    {
                        List<Examination> exams = this._examService.GetAllExams();
                        foreach (Examination e in exams)
                        {
                            if (e.ExamRoom.Id.Equals(room.Id))
                            {
                                content += "Od: " + e.Term.Start.ToString("MM/dd/yyyy HH:mm") + " Do: " + e.Term.End.ToString("MM/dd/yyyy HH:mm") + "\n";
                            }
                        }

                    }
                    break;
                case RoomType.OPERATINGROOM:
                    {
                        List<Operation> operations = this._opService.GetAllOperations();
                        foreach (Operation o in operations)
                        {
                            if (o.OperatingRoom.Id.Equals(room.Id))
                            {
                                content += "Od: " + o.Term.Start.ToString("MM/dd/yyyy HH:mm") + " Do: " + o.Term.End.ToString("MM/dd/yyyy HH:mm") + "\n";
                            }
                        }
                    }
                    break;

                default:
                    {
                        content += "Ova prostorija je uvek slobodna";
                    }
                    break;
            }
            return new ScheduleReport(from, until, id, content);
        }

        private ReportPDF ConvertToPDF(Report report)
        {
            ReportPDF pdf = new ReportPDF(new PdfDocument(), report.Id);
            pdf.Document.Info.Title = report.Id;
            PdfPage page = pdf.Document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 28, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            tf.DrawString(report.Content, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            return pdf;
        }

        public void DownloadReport(ScheduleReport report)
        {
            if (report == null) return;
            ReportPDF pdf = ConvertToPDF(report);
            this._scheduleReportRepo.SaveAsPDF(pdf);
        }

        public List<ScheduleReport> GetAllReports()
        {
            return this._scheduleReportRepo.GetAll();
        }

        public ScheduleReport GetReport(string id)
        {
            return this._scheduleReportRepo.Get(id);
        }


    }
}