// File:    AppointmentRepository.cs
// Created: Sunday, May 24, 2020 5:51:27 PM
// Purpose: Definition of Class AppointmentRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryAppointment
{
    public class OperationRepository : IOperationRepository
    {
        private string _path = "operations.json";
        public OperationRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Operation>());
            }

        }

        public bool Create(Operation obj)
        {
            List<Operation> operations = GetAll();
            if (Get(obj.Id) == null)
            {
                operations.Add(obj);
                SaveAll(operations);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<Operation> operations = GetAll();
            Operation operation = Get(id);
            if (operations != null)
            {
                operations.Remove(operation);
                SaveAll(operations);
                return true;
            }
            return false;
        }


        public bool Update(Operation obj)
        {
            List<Operation> operations = GetAll();
            Operation foundOperation = Get(obj.Id);
            if (foundOperation != null)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    if (operations[i].Id.Equals(obj.Id)) operations[i] = obj;
                }
                SaveAll(operations);
                return true;
            }
            return false;
        }

        public Operation Get(string id)
        {
            List<Operation> operations = GetAll();
            foreach (Operation operation in operations)
            {
                if (operation.Id.Equals(id)) return operation;
            }
            return null;
        }


        public List<Operation> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Operation>>(jsonString);
            return new List<Operation>();
        }

        public void SaveAll(List<Operation> operations)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, operations);
                }
            }
        }

        public List<Operation> GetAllDoctorsOperations(Doctor doctor)
        {
            List<Operation> allDoctorsOperations = new List<Operation>();
            foreach (Operation operation in GetAll())
            {
                if (doctor.Pin.Equals(operation.Doctor.Pin)) allDoctorsOperations.Add(operation);

            }
            return allDoctorsOperations;
        }
        public List<Operation> GetAllPatientOperations(RegisteredPatient patient)
        {
            List<Operation> allPatientsOperations = new List<Operation>();
            foreach (Operation operation in GetAll())
            {
                if (patient.Pin.Equals(operation.RegisteredPatient.Pin)) allPatientsOperations.Add(operation);

            }
            return allPatientsOperations;
        }
    }
}