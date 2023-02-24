// File:    OperationService.cs
// Created: Wednesday, May 20, 2020 8:35:16 PM
// Purpose: Definition of Class OperationService

using Repository.RepositoryAppointment;
using System;
using System.Collections.Generic;

namespace Service.ServiceAppointment
{
    public class OperationService
    {
        private IOperationRepository _iOperationRepository;

        public OperationService(OperationRepository operationRepository)
        {
            _iOperationRepository = operationRepository;
        }

        public bool ScheduleOperation(Operation operation)
            => _iOperationRepository.Create(operation);

        public bool RescheduleOperation(Operation scheduledOperation)
            => _iOperationRepository.Update(scheduledOperation);


        public bool CancelOperation(string scheduledOperationId)
            => _iOperationRepository.Delete(scheduledOperationId);

        public bool ScheduleEmergencyOperation(Operation operation)
            => _iOperationRepository.Create(operation);


        public Operation GetOperationById(String id)
            => _iOperationRepository.Get(id);

        public List<Operation> GetAllOperations()
            => _iOperationRepository.GetAll();

        public List<Operation> GetAllPatientOperations(RegisteredPatient patient)
            => _iOperationRepository.GetAllPatientOperations(patient);

        public List<Operation> GetAllDoctorsOperations(Doctor doctor)
            => _iOperationRepository.GetAllDoctorsOperations(doctor);


        public List<Operation> GetAllPatientsOperationsForToday(RegisteredPatient patient)
        {
            List<Operation> patientsOperationsForToday = new List<Operation>();
            foreach (Operation operation in GetAllPatientOperations(patient))
            {
                if (operation.Date.Date.Equals(DateTime.Today)) patientsOperationsForToday.Add(operation);
            }
            return patientsOperationsForToday;
        }
        public List<Operation> GetAllDoctorsOperationsForToday(Doctor doctor)
        {
            List<Operation> operationsForToday = new List<Operation>();
            foreach (Operation operation in GetAllDoctorsOperations(doctor))
            {
                if (operation.Date.Date.Equals(DateTime.Today)) operationsForToday.Add(operation);
            }

            return operationsForToday;
        }

        public List<Operation> GetAllPatientsOperationsForTimePeriod(RegisteredPatient patient, DateTime startDate, DateTime endDate)
        {
            List<Operation> patientsOperationsForTimePeriod = new List<Operation>();
            foreach (Operation operation in GetAllPatientOperations(patient))
            {
                if (CheckTimePeriod(startDate, endDate, operation)) patientsOperationsForTimePeriod.Add(operation);
            }
            return patientsOperationsForTimePeriod;
        }

        public List<Operation> GetAllDoctorsOperationsForTimePeriod(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            List<Operation> doctorsOperationsForTimePeriod = new List<Operation>();
            foreach (Operation operation in GetAllDoctorsOperations(doctor))
            {
                if (CheckTimePeriod(startDate, endDate, operation)) doctorsOperationsForTimePeriod.Add(operation);
            }
            return doctorsOperationsForTimePeriod;
        }


        public List<Operation> GetAllOperationsByDate(DateTime date)
        {
            List<Operation> operationsForDate = new List<Operation>();
            foreach(Operation operation in GetAllOperations())
            {
                if (operation.Date.Date.Equals(date.Date)) operationsForDate.Add(operation);
            }
            return operationsForDate;
        }
        public List<Operation> GetAllOperationsForTimePeriod(DateTime startDate, DateTime endDate)
        {
            List<Operation> operationsForTimePeriod = new List<Operation>();
            foreach (Operation operation in GetAllOperations())
            {
                if (CheckTimePeriod(startDate, endDate, operation)) operationsForTimePeriod.Add(operation);
            }
            return operationsForTimePeriod;
        }

        public bool CheckTimePeriod(DateTime startDate, DateTime endDate, Operation operation)
        {
            if (operation.Date >= startDate && operation.Date <= endDate) return true;
            return false;
        }

    }
}