// File:    AppointmentController.cs
// Created: Friday, May 22, 2020 7:40:25 PM
// Purpose: Definition of Class AppointmentController

using Service.ServiceAppointment;
using System;
using System.Collections.Generic;

namespace Controller.ControllerAppointment
{
    public class AppointmentController
    {
        private AppointmentService _appointmentService;
        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public List<Appointment> GetAllDoctorsAppointments(Doctor doctor)
            => _appointmentService.GetAllDoctorsAppointments(doctor);
        

        public List<Appointment> GetAllDoctorsAppointmentsToday(Doctor doctor)
            => _appointmentService.GetAllDoctorsAppointmentsForToday(doctor);
        

        public List<Appointment> GetAllDoctorsAppointmentsForTimePeriod(Doctor doctor, DateTime starDate, DateTime endDate)
            => _appointmentService.GetAllDoctorsAppointmentsForTimePeriod(doctor, starDate, endDate);
        

        public List<Appointment> GetAllPatientsAppointments(RegisteredPatient patient)
            => _appointmentService.GetAllPatientsAppointments(patient);


        public List<Appointment> GetAllPatientsAppointmentsForToday(RegisteredPatient patient)
            => _appointmentService.GetAllPatientsAppointmentsForToday(patient);
        

        public List<Appointment> GetAllPatientsAppointmentsForTimePeriod(RegisteredPatient patient, DateTime startDate, DateTime endDate)
            => _appointmentService.GetAllPatientsAppointmentsForTimePeriod(patient, startDate, endDate);
        

        public Dictionary<Term,Doctor> GetAllFreeTermsForToday()
            => _appointmentService.GetAllFreeTermsForToday();
        

        public List<Term> GetAllFreeTermsForTimePeriod(DateTime startDate, DateTime endDate)
            => _appointmentService.GetAllFreeTermsForTimePeriod(startDate, endDate);
        

        public List<Term> GetAllDoctorsFreeTermsForToday(Doctor doctor)
            => _appointmentService.GetAllDoctorsFreeTermsForToday(doctor);
        
        
        public List<Term> GetAllDoctorsFreeTermsForTimePeriod(DateTime startDate, DateTime endDate, Doctor doctor)
            => _appointmentService.GetAllDoctorsFreeTermsForTimePeriod(startDate, endDate, doctor);
        

        public List<Term> GetAllDoctorsFreeTermsForDate(Doctor doctor, DateTime date)
            => _appointmentService.GetAllDoctorsFreeTermsForDate(doctor, date);

        public List<Appointment> GetAllAppointments()
            => _appointmentService.GetAllAppointmens();

    }
}