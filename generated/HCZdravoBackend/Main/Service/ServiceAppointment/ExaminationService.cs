// File:    ExaminationService.cs
// Created: Wednesday, May 20, 2020 8:35:16 PM
// Purpose: Definition of Class ExaminationService

using Repository.RepositoryAppointment;
using Repository.RepositoryDoctor;
using System;
using System.Collections.Generic;

namespace Service.ServiceAppointment
{
    public class ExaminationService
    {
        private IExaminationRepository _iExaminationRepository;
        private AppointmentService _appointmentService;

        public ExaminationService(ExaminationRepository examinationRepository, OperationRepository operationRepository, DoctorRepository doctorRepository)
        {
            _iExaminationRepository = examinationRepository;
            _appointmentService = new AppointmentService(operationRepository, examinationRepository, doctorRepository);
        }

        public bool ScheduleExam(Examination examination)
            => _iExaminationRepository.Create(examination);

        public bool RescheduleExam(Examination scheduledExamination)
            => _iExaminationRepository.Update(scheduledExamination);

        public bool ScheduleEmergencyExam(Examination emeregencyExamination)
            => _iExaminationRepository.Create(emeregencyExamination);

        public bool CancelExam(string scheduledExaminationId)
            => _iExaminationRepository.Delete(scheduledExaminationId);

        public Examination GetExamById(String id)
            => _iExaminationRepository.Get(id);

        public List<Examination> GetAllExams()
            => _iExaminationRepository.GetAll();
        public List<Examination> GetAllExamsByDate(DateTime date)
        {
            List<Examination> allExamsForDate = new List<Examination>();
            foreach (Examination examination in GetAllExams())
            {
                if (examination.Date.Date.Equals(date.Date)) allExamsForDate.Add(examination);
            }
            return allExamsForDate;
        }
        public List<Examination> GetAllPatientsExams(RegisteredPatient patient)
            => _iExaminationRepository.GetAllPatientExaminations(patient);
        public List<Examination> GetAllDoctorsExams(Doctor doctor)
            => _iExaminationRepository.GetAllDoctorsExaminations(doctor);

        public List<Examination> GetAllPatientsExamsForToday(RegisteredPatient patient)
        {
            List<Examination> patientsExaminationsForToday = new List<Examination>();
            foreach (Examination examination in GetAllPatientsExams(patient))
            {
                if (examination.Date.Date.Equals(DateTime.Today)) patientsExaminationsForToday.Add(examination);
            }
            return patientsExaminationsForToday;
        }
        public List<Examination> GetAllDoctorsExamsForToday(Doctor doctor)
        {
            List<Examination> examinationsForToday = new List<Examination>();
            foreach (Examination exam in GetAllDoctorsExams(doctor))
            {
                if (exam.Date.Date.Equals(DateTime.Today.Date)) examinationsForToday.Add(exam);

            }
            return examinationsForToday;
        }

        public List<Examination> GetAllPatientsExaminationsForTimePeriod(RegisteredPatient patient, DateTime startDate, DateTime endDate)
        {
            List<Examination> patientsExaminationsForTimePeriod = new List<Examination>();
            foreach (Examination examination in GetAllPatientsExams(patient))
            {
                if (CheckTimePeriod(startDate, endDate, examination)) patientsExaminationsForTimePeriod.Add(examination);
            }
            return patientsExaminationsForTimePeriod;
        }
        public List<Examination> GetAllDoctorsExamsForTimePeriod(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            List<Examination> doctorsExamsForTimePeriod = new List<Examination>();
            foreach (Examination examination in GetAllDoctorsExams(doctor))
            {
                if (CheckTimePeriod(startDate, endDate, examination)) doctorsExamsForTimePeriod.Add(examination);
            }
            return doctorsExamsForTimePeriod;
        }

        public Examination GetDoctorsAppointmentASAP(Doctor doctor, RegisteredPatient registeredPatient)
        {
            Appointment appointment = _appointmentService.GetDoctorsAppointmentASAP(doctor, registeredPatient);
            if (appointment != null)
                return new Examination(doctor.DefaultExamRoom, appointment);
            return null;
        }

        public List<Examination> GetAllExamsForTimePeriod(DateTime startDate, DateTime endDate)
        {
            List<Examination> examsForTimePeriod = new List<Examination>();
            foreach (Examination examination in GetAllExams())
            {
                if (CheckTimePeriod(startDate, endDate, examination)) examsForTimePeriod.Add(examination);
            }
            return examsForTimePeriod;
        }


        public Examination SuggestExam(DateTime startDate, DateTime endDate, Doctor doctor, RegisteredPatient registeredPatient)
        {
            Appointment appointment = _appointmentService.SuggestAppointment(startDate, endDate, doctor, registeredPatient);
            if (appointment != null) 
                return new Examination(doctor.DefaultExamRoom, appointment);
            return null;
        }

        private bool CheckTimePeriod(DateTime startDate, DateTime endDate, Examination examination)
        {
            if (examination.Date >= startDate && examination.Date <= endDate) return true;
            return false;
        }
    }
}