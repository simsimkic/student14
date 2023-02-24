// File:    AppointmentService.cs
// Created: Sunday, May 24, 2020 2:19:07 PM
// Purpose: Definition of Class AppointmentService

using Main.View;
using Repository.RepositoryAppointment;
using Repository.RepositoryDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace Service.ServiceAppointment
{
    public class AppointmentService
    {
        private IDoctorRepository _iDoctorRepository;
        private IOperationRepository _iOperationRepository;
        private IExaminationRepository _iExaminationRepository;
        public AppointmentService(OperationRepository operationRepository, ExaminationRepository examinationRepository, DoctorRepository doctorRepository)
        {
            _iOperationRepository = operationRepository;
            _iExaminationRepository = examinationRepository;
            _iDoctorRepository = doctorRepository;
        }
        
        public string GenerateRandomAppointmentId()
        {
            RandomStringGenerator randomId = new RandomStringGenerator(11);
            while (_iExaminationRepository.Get(randomId.RandomString) != null && _iOperationRepository.Get(randomId.RandomString)!=null)
            {
                randomId = new RandomStringGenerator(11);
            }
            return randomId.RandomString;
        }

        public List<Appointment> GetAllDoctorsAppointments(Doctor doctor)
        { 
            List<Appointment> doctorsAppointments = new List<Appointment>();
            List<Operation> doctorsOperations = _iOperationRepository.GetAllDoctorsOperations(doctor);
            List<Examination> doctorsExaminations = _iExaminationRepository.GetAllDoctorsExaminations(doctor);
            if (doctorsOperations != null)
                doctorsAppointments.AddRange(doctorsOperations);
            if (doctorsExaminations != null)
                doctorsAppointments.AddRange(doctorsExaminations);
            return doctorsAppointments;

        }

        public List<Appointment> GetAllDoctorsAppointmentsForToday(Doctor doctor)
        {
            List<Appointment> doctorsAppointmentsForToday = new List<Appointment>();
            foreach (Appointment appointment in GetAllDoctorsAppointments(doctor))
            {
                if (appointment.Date.Date.Equals(DateTime.Today.Date)) doctorsAppointmentsForToday.Add(appointment);
            }
            return doctorsAppointmentsForToday;
        }

        public List<Appointment> GetAllDoctorsAppointmentsByDate(Doctor doctor, DateTime date)
        {
            List<Appointment> doctorsAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllDoctorsAppointments(doctor))
            {
                if (appointment.Date.Date == date.Date) doctorsAppointments.Add(appointment);
            }
            return doctorsAppointments;
        }

        public List<Appointment> GetAllDoctorsAppointmentsForTimePeriod(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            List<Appointment> doctorsAppointmentsForTimePeriod = new List<Appointment>();
            foreach (Appointment appointment in GetAllDoctorsAppointments(doctor))
            {
                if (CheckTimePeriod(startDate,endDate,appointment)) doctorsAppointmentsForTimePeriod.Add(appointment);
            }
            return doctorsAppointmentsForTimePeriod;
        }


        public List<Appointment> GetAllPatientsAppointments(RegisteredPatient patient)
        {
            List<Appointment> patientsAppointments = new List<Appointment>();
            List<Operation> patientOperations = _iOperationRepository.GetAllPatientOperations(patient);
            List<Examination> patientExaminations = _iExaminationRepository.GetAllPatientExaminations(patient);
            if (patientOperations != null)
                patientsAppointments.AddRange(patientOperations);
            if (patientExaminations != null)
                patientsAppointments.AddRange(patientExaminations);
            return patientsAppointments;
        }
       

        public List<Appointment> GetAllPatientsAppointmentsForToday(RegisteredPatient patient)
        {
            List<Appointment> patientsAppointmentsForToday = new List<Appointment>();
            foreach (Appointment appointment in _iOperationRepository.GetAll())
            {
                if (appointment.RegisteredPatient.Equals(patient) && appointment.Date.Equals(DateTime.Today)) patientsAppointmentsForToday.Add(appointment);
            }
            return patientsAppointmentsForToday;
        }

        public List<Appointment> GetAllPatientsAppointmentsForTimePeriod(RegisteredPatient patient, DateTime startDate, DateTime endDate)
        {
            List<Appointment> patientsAppointmentsForTimePeriod = new List<Appointment>();
            foreach (Appointment appointment in GetAllPatientsAppointments(patient))
            {
                if (CheckTimePeriod(startDate, endDate, appointment)) patientsAppointmentsForTimePeriod.Add(appointment);
            }
            return patientsAppointmentsForTimePeriod;
        }


        public Dictionary<Term,Doctor> GetAllFreeTermsForToday()
        {
            Dictionary<Term, Doctor> termDoctorDictionary = new Dictionary<Term, Doctor>(); 
            foreach (Doctor doctor in _iDoctorRepository.GetAll())
            {
                foreach (Term term in GetAllDoctorsFreeTermsForToday(doctor))
                    termDoctorDictionary.Add(term, doctor);
            }
            return termDoctorDictionary;
        }
        public bool IsDoctorWorking(Doctor doctor, DateTime date)
            => doctor.Status.Equals(DoctorStatus.WORKING);
        

        public List<Term> GetDoctorsTermsForShift(Doctor doctor, DateTime date)
        {
            List<Term> allTermsForDate = new AllTermsInADay(date).Term;
            Shift doctorsShift = GetDoctorsShiftForDate(doctor,date);
            List<Term> doctorsTermsInShift = new List<Term>();
            foreach(Term term in allTermsForDate)
            {
                if (CheckTermsExistanceInShift(term, doctorsShift.Start, doctorsShift.End))
                    doctorsTermsInShift.Add(term);
            }
            return doctorsTermsInShift;
        }

        public bool CheckTermsExistanceInShift(Term term, DateTime startShift, DateTime endShift)
        {
            return (term.Start >= startShift && term.End <= endShift);
        }


        public List<Term> GetAllFreeTermsForTimePeriod(DateTime startDate, DateTime endDate)
        {
            List<Term> freeTermsForTimePeriod = new List<Term>();
            foreach(Doctor doctor in _iDoctorRepository.GetAll())
            {
                List<Term> doctorsFreeTermsForTimePeriod = GetAllDoctorsFreeTermsForTimePeriod(startDate, endDate, doctor);
                if (doctorsFreeTermsForTimePeriod != null) freeTermsForTimePeriod.AddRange(doctorsFreeTermsForTimePeriod);
            }
            return freeTermsForTimePeriod;
        }

        public Shift GetDoctorsShiftForDate(Doctor doctor, DateTime date)
        {
            foreach (Shift shift in doctor.Shifts)
            {
                if (shift.Start.Date == date.Date) return shift;
            }
            return null;
        }
        public bool CheckAppointmentInTerm(Term term, Appointment appointment)
            => (term.Start >= appointment.Term.Start && term.End <= appointment.Term.End);
        
        public List<Term> GetAllDoctorsFreeTermsForToday(Doctor doctor)
        {
            List<Term> freeTerms = GetDoctorsTermsForShift(doctor, DateTime.Today);
            List<Term> allTerms = GetDoctorsTermsForShift(doctor, DateTime.Today);
            foreach (Appointment appointment in GetAllDoctorsAppointmentsForToday(doctor))
            {
                foreach (Term term in allTerms)
                {
                    if (CheckAppointmentInTerm(term, appointment))
                        freeTerms.Remove(term);
                }
            }
            return freeTerms;
        }


        public List<DateTime> GetAllDatesBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            List<DateTime> datesBetween = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                datesBetween.Add(date);
            return datesBetween;
        }

        
        public List<Term> GetAllDoctorsFreeTermsForTimePeriod(DateTime startDate, DateTime endDate, Doctor doctor)
        {
            List<Term> doctorsFreeTermsForTimePeriod = new List<Term>();
            foreach(DateTime date in GetAllDatesBetweenTwoDates(startDate, endDate))
            {
                List<Term> doctorsFreeTermsInDay = GetAllDoctorsFreeTermsForDate(doctor,date);
                if (doctorsFreeTermsInDay != null) doctorsFreeTermsForTimePeriod.AddRange(doctorsFreeTermsInDay);
            }
            return doctorsFreeTermsForTimePeriod;
        }
        
        public bool AreDoctorsFreeTermsNull(List<Term> freeTerms)
            => freeTerms==null;

        public Appointment SuggestAppointment(DateTime startDate, DateTime endDate, Doctor doctor, RegisteredPatient registeredPatient)
        {
            List<Term> doctorsFreeTermsForTimePeriod = GetAllDoctorsFreeTermsForTimePeriod(startDate, endDate, doctor);
            if (!AreDoctorsFreeTermsNull(doctorsFreeTermsForTimePeriod))
                return new Appointment(false, GenerateRandomAppointmentId(), AppointmentType.EXAMINATION,registeredPatient, doctorsFreeTermsForTimePeriod[0], doctor, doctorsFreeTermsForTimePeriod[0].Start.Date);
            return null;
        }

        public Appointment GetDoctorsAppointmentASAP(Doctor doctor, RegisteredPatient registeredPatient)
        {
            List<Term> doctorsFreeTermsForTimePeriod = GetAllDoctorsFreeTermsForTimePeriod(DateTime.Today.AddDays(1), DateTime.MaxValue, doctor);
            if (doctorsFreeTermsForTimePeriod != null)
                return new Appointment(false, GenerateRandomAppointmentId(), AppointmentType.EXAMINATION, registeredPatient, doctorsFreeTermsForTimePeriod[0], doctor, doctorsFreeTermsForTimePeriod[0].Start.Date);
            return null;            
        }

        public List<Term> GetAllDoctorsFreeTermsForDate(Doctor doctor, DateTime date)
        {
            List<Term> allTerms = GetDoctorsTermsForShift(doctor, date);
            List<Term> freeTerms = GetDoctorsTermsForShift(doctor, date);
            foreach (Appointment appointment in GetAllDoctorsAppointmentsByDate(doctor, date))
            {
                foreach(Term term in allTerms)
                {
                    if (CheckAppointmentInTerm(term, appointment))
                        freeTerms.Remove(term);
                }
            }
            return freeTerms;
        }


        public bool CheckTimePeriod(DateTime startDate, DateTime endDate, Appointment appointment)
        {
            if (appointment.Date >= startDate && appointment.Date <= endDate) return true;
            return false;
        }

        public List<Appointment> GetAllAppointmens()
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Operation> operations = _iOperationRepository.GetAll();
            List<Examination> examinations = _iExaminationRepository.GetAll();

            foreach(Operation op in operations)
                appointments.Add(op);

            foreach (Examination exam in examinations)
                appointments.Add(exam);

            return appointments;

        }

    }
}