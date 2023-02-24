// File:    ScheduleReportRepository.cs
// Created: Thursday, May 28, 2020 10:28:33 PM
// Purpose: Definition of Class ScheduleReportRepository

using Newtonsoft.Json;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.RepositoryReport
{
    public class ScheduleReportRepository : IScheduleReportRepository
    {
        private string _path = "schedulereports.json";
        
        private void SaveAll(List<ScheduleReport> Reports)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, Reports);
                }
            }
        }

        public bool Create(ScheduleReport obj)
        {
            List<ScheduleReport> Reports = GetAll();
            if(!Reports.Contains(obj))
            {
                Reports.Add(obj);
                SaveAll(Reports);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<ScheduleReport> Reports = GetAll();
            ScheduleReport report = Reports.FirstOrDefault(x => x.Id.Equals(id));
            if(report != null)
            {
                Reports.Remove(report);
                SaveAll(Reports);
                return true;
            }
            return false;
        }

        public bool Update(ScheduleReport obj)
        {
            List<ScheduleReport> Reports = GetAll();
            ScheduleReport report = Reports.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if(report != null)
            {
                report = obj;
                SaveAll(Reports);
                return true;
            }
            return false;
        }

        public ScheduleReport Get(string id)
        {
            List<ScheduleReport> Reports = GetAll();
            return Reports.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<ScheduleReport> GetAll()
        {
            string json = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if(!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<List<ScheduleReport>>(json);
            }
            return new List<ScheduleReport>();
        }

        public void SaveAsPDF(ReportPDF pdf)
        {
            string filename = "deanreport" + pdf.Id + ".pdf";
            pdf.Document.Save(filename);
        }
    }
}