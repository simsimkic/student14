// File:    ReportOfExaminationRepository.cs
// Created: Thursday, May 21, 2020 8:37:22 PM
// Purpose: Definition of Class ReportOfExaminationRepository


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryMedicalDocumentation
{
    public class ReportOfExaminationRepository : IReportOfExaminationRepository
    {
        private string _path = "reportOfExaminations.json";

        public ReportOfExaminationRepository() {
            if (!File.Exists(_path))
            {
                SaveAll(new List<ReportOfExamination>());
            }
        }

        public bool Create(ReportOfExamination obj)
        {
            List<ReportOfExamination> reportOfExaminations = GetAll();
            if (Get(obj.Id) == null)
            {
                reportOfExaminations.Add(obj);
                SaveAll(reportOfExaminations);
                return true;
            }
            return false;
        }

        public bool Update(ReportOfExamination obj)
        {
            List<ReportOfExamination> reportOfExaminations = GetAll();
            ReportOfExamination foundReport = Get(obj.Id);
            if (foundReport != null)
            {
                for (int i = 0; i < reportOfExaminations.Count; i++)
                {
                    if (reportOfExaminations[i].Id.Equals(obj.Id))
                    {
                        reportOfExaminations[i] = obj;
                        SaveAll(reportOfExaminations);
                        return true;
                    }
                }
            }
            return false;
        }

        public ReportOfExamination Get(string id)
        {
            List<ReportOfExamination> reportOfExaminations = GetAll();
            foreach (ReportOfExamination reportOfExamination in reportOfExaminations)
            {
                if (reportOfExamination.Id.Equals(id)) return reportOfExamination;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<ReportOfExamination> reportOfExaminations = GetAll();
            ReportOfExamination reportOfExamination = Get(id);
            if (reportOfExamination != null)
            {
                reportOfExaminations.Remove(reportOfExamination);
                SaveAll(reportOfExaminations);
                return true;
            }
            return false;
        }

        public List<ReportOfExamination> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<ReportOfExamination>>(jsonString);
            return new List<ReportOfExamination>();
        }

        public void SaveAll(List<ReportOfExamination> reportOfExaminations)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, reportOfExaminations);
                }
            }
        }
    }
}