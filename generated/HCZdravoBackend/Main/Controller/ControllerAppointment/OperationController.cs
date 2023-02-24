// File:    OperationController.cs
// Created: Wednesday, May 20, 2020 10:20:07 PM
// Purpose: Definition of Class OperationController


using Service.ServiceAppointment;
using System;
using System.Collections.Generic;

namespace Controller.ControllerAppointment
{
    public class OperationController
    {
        private OperationService _operationService;

        public OperationController(OperationService operationService)
        {
            _operationService = operationService;
        }

        public bool ScheduleOperation(Operation operation)
            => _operationService.ScheduleOperation(operation);
        

        public bool RescheduleOperation(Operation scheduledOperation)
            => _operationService.RescheduleOperation(scheduledOperation);
        

        public bool CancelOperation(string scheduledOperationId)
            => _operationService.CancelOperation(scheduledOperationId);
        

        public bool ScheduleEmergencyOperation(Operation emergencyOperation)
            => _operationService.ScheduleEmergencyOperation(emergencyOperation);
        

        public Operation GetOperationById(String id)
            => _operationService.GetOperationById(id);
        

        public List<Operation> GetAllOperations()
            => _operationService.GetAllOperations();
        

        public List<Operation> GetAllPatientOperations(RegisteredPatient patient)
            => _operationService.GetAllPatientOperations(patient);
        

        public List<Operation> GetAllDoctorsOperations(Doctor doctor)
            => _operationService.GetAllDoctorsOperations(doctor);
        

        public List<Operation> GetAllDoctorsOperationsForTimePeriod(Doctor doctor, DateTime startDate, DateTime endDate)
            => _operationService.GetAllDoctorsOperationsForTimePeriod(doctor, startDate, endDate);
        

        public List<Operation> GetAllDoctorsOperationsForToday(Doctor doctor)
            => _operationService.GetAllDoctorsOperationsForToday(doctor);

        public List<Operation> GetAllOperationByDate(DateTime date)
            => _operationService.GetAllOperationsByDate(date);

        public List<Operation> GetAllOperationForTimePeriod(DateTime startDate, DateTime endDate)
            => _operationService.GetAllOperationsForTimePeriod(startDate, endDate);
    }
}