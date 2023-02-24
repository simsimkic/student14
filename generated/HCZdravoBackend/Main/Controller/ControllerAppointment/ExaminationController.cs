// File:    ExaminationController.cs
// Created: Wednesday, May 20, 2020 10:20:07 PM
// Purpose: Definition of Class ExaminationController


using Service.ServiceAppointment;
using System;
using System.Collections.Generic;

namespace Controller.ControllerAppointment
{
    public class ExaminationController
    {
        private ExaminationService _examinationService;
        public ExaminationController(ExaminationService examinationService)
        {
            _examinationService = examinationService;
        }
        public bool ScheduleExam(Examination examination)
            => _examinationService.ScheduleExam(examination);
        

        public bool RescheduleExam(Examination scheduledExamination)
            => _examinationService.RescheduleExam(scheduledExamination);
        

        public bool CancelExam(string scheduledExaminationId)
            => _examinationService.CancelExam(scheduledExaminationId);
        
        public bool ScheduleEmergencyExam(Examination emergencyExam)
            => _examinationService.ScheduleEmergencyExam(emergencyExam);
        

        public List<Examination> GetAllExaminations()
            => _examinationService.GetAllExams();
        

        public List<Examination> GetAllPatientsExams(RegisteredPatient patient)
            => _examinationService.GetAllPatientsExams(patient);
        

        public List<Examination> GetAllDoctorsExams(Doctor doctor)
            => _examinationService.GetAllDoctorsExams(doctor);
        

        public Examination GetExamById(String id)
            => _examinationService.GetExamById(id);
        

        public List<Examination> GetAllDoctorsExamsForToday(Doctor doctor)
            => _examinationService.GetAllDoctorsExamsForToday(doctor);
        

        public List<Examination> GetAllDoctorsExamsForTimePeriod(Doctor doctor, DateTime startDate, DateTime endDate)
            => _examinationService.GetAllDoctorsExamsForTimePeriod(doctor, startDate, endDate);
        

        public Examination SuggestExam(DateTime startDate, DateTime endDate, Doctor doctor, RegisteredPatient registeredPatient)
            => _examinationService.SuggestExam(startDate, endDate, doctor, registeredPatient);
        

        public Examination GetDoctorsAppointmentASAP(Doctor doctor, RegisteredPatient registeredPatient)
            => _examinationService.GetDoctorsAppointmentASAP(doctor, registeredPatient);
        

        public List<Examination> GetAllExamsForTimePeriod(DateTime startDate, DateTime endDate)
            => _examinationService.GetAllExamsForTimePeriod(startDate, endDate);

        public List<Examination> GetAllExamsByDate(DateTime date)
            => _examinationService.GetAllExamsByDate(date);


    }
}