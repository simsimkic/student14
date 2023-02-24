// File:    PatientChartRepository.cs
// Created: Thursday, May 21, 2020 8:37:19 PM
// Purpose: Definition of Class PatientChartRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Repository.RepositoryMedicalDocumentation
{
    public class PatientChartRepository : IPatientChartRepository
    {
        private string _path = "patientCharts.json";

        public PatientChartRepository() {
            if (!File.Exists(_path))
            {
                SaveAll(new List<PatientChart>());
            }
        }

        public bool Create(PatientChart obj)
        {
            List<PatientChart> patientCharts = GetAll();
            if (Get(obj.Id) == null)
            {
                patientCharts.Add(obj);
                SaveAll(patientCharts);
                return true;
            }
            return false;
        }

        public bool Update(PatientChart obj)
        {
            List<PatientChart> patientCharts = GetAll();
            PatientChart foundPatientChart = Get(obj.Id);
            if (foundPatientChart != null)
            {
                for (int i = 0; i < patientCharts.Count; i++)
                {
                    if (patientCharts[i].Id.Equals(obj.Id))
                    {
                        patientCharts[i] = obj;
                        SaveAll(patientCharts);
                        return true;
                    }
                }
            }
            return false;
        }

        public PatientChart Get(string id)
        {
            List<PatientChart> patientCharts = GetAll();
            foreach (PatientChart patientChart in patientCharts)
            {
                if (patientChart.Id.Equals(id)) return patientChart;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<PatientChart> patientCharts = GetAll();
            PatientChart patientChart = Get(id);
            if (patientChart != null)
            {
                patientCharts.Remove(patientChart);
                SaveAll(patientCharts);
                return true;
            }
            return false;
        }

        public List<PatientChart> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<PatientChart>>(jsonString);
            return new List<PatientChart>();
        }

        public void SaveAll(List<PatientChart> patientCharts)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, patientCharts);
                }
            }
        }
    }
}