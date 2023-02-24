// File:    AppointmentRepository.cs
// Created: Sunday, May 24, 2020 5:51:27 PM
// Purpose: Definition of Class AppointmentRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryAppointment
{
    public class ExaminationRepository : IExaminationRepository
    {
        private string _path = "examinations.json";
        public ExaminationRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Examination>());
            }

        }
        public bool Create(Examination obj)
        {
            List<Examination> examinations = GetAll();
            if (Get(obj.Id) == null)
            {
                examinations.Add(obj);
                SaveAll(examinations);
                return true;
            }
            return false;
        }
        public bool Delete(string id)
        {
            Examination examination = Get(id);
            if (examination != null)
            {
                List<Examination> examinations = GetAll();
                examinations.Remove(examination);
                SaveAll(examinations);
                return true;
            }
            return false;
        }

        public bool Update(Examination obj)
        {
            List<Examination> examinations = GetAll();
            Examination foundExamination = Get(obj.Id);
            if (foundExamination != null)
            {
                for (int i = 0; i < examinations.Count; i++)
                {
                    if (examinations[i].Id.Equals(obj.Id)) examinations[i] = obj;
                }
                SaveAll(examinations);
                return true;
            }
            return false;
        }


        public Examination Get(string id)
        {
            List<Examination> examinations = GetAll();
            foreach (Examination examination in examinations)
            {
                if (examination.Id.Equals(id)) return examination;

            }

            return null;
        }

        public List<Examination> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Examination>>(jsonString);
            return new List<Examination>();
        }

        public void SaveAll(List<Examination> examinations)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, examinations);
                }
            }
        }
        public List<Examination> GetAllDoctorsExaminations(Doctor doctor)
        {
            List<Examination> allDoctorsExaminations = new List<Examination>();
            foreach (Examination examination in GetAll())
            {
                if (doctor.Pin.Equals(examination.Doctor.Pin)) allDoctorsExaminations.Add(examination);

            }
            return allDoctorsExaminations;
        }
        public List<Examination> GetAllPatientExaminations(RegisteredPatient patient)
        {
            List<Examination> allPatientsExaminations = new List<Examination>();
            foreach (Examination examination in GetAll())
            {
                if (patient.Pin.Equals(examination.RegisteredPatient.Pin)) allPatientsExaminations.Add(examination);
            }
            return allPatientsExaminations;
        }
    }
}