// File:    DoctorService.cs
// Created: Tuesday, May 19, 2020 8:50:33 PM
// Purpose: Definition of Class DoctorService

using Repository.RepositoryDoctor;
using System;
using System.Collections.Generic;

namespace Service.ServiceDoctor
{
    public class DoctorService
    {
        private IDoctorRepository _iDoctorRepository;

        public DoctorService(DoctorRepository doctorRepository) {
            _iDoctorRepository = doctorRepository;
        }

        public void NewDoctor(Doctor doctor)
            => _iDoctorRepository.Create(doctor);

        public void EditDoctor(Doctor doctor)
            => _iDoctorRepository.Update(doctor);

        public void RemoveDoctor(Doctor doctor)
            => _iDoctorRepository.Delete(doctor.Pin);

        public Doctor GetDoctorById(string id)
            => _iDoctorRepository.Get(id);

        public List<Doctor> GetAllDoctors()
            => _iDoctorRepository.GetAll();

        public List<Doctor> GetAllDoctorsGeneralMedicine()
        {
            List<Doctor> doctorsGeneralMedicine = new List<Doctor>();
            foreach (Doctor doctor in GetAllDoctors())
            {
                if (doctor.Specialization.Equals("OPSTA_PRAKSA"))
                    doctorsGeneralMedicine.Add(doctor);
            }
            return doctorsGeneralMedicine;
        }

        public List<Doctor> GetAllSpecialists()
        {
            List<Doctor> doctorSpecialists = new List<Doctor>();
            foreach (Doctor doctor in GetAllDoctors()) {
                if (!doctor.Specialization.Equals("OPSTA_PRAKSA"))
                    doctorSpecialists.Add(doctor);
            }
            return doctorSpecialists;
        }

        public Shift getDoctorsShiftForDate(Doctor doctor, DateTime date) {
            foreach (Shift shift in doctor.Shifts) {
                if (shift.Start.Date == date)
                    return shift;
            }
            return null;
        }

    }
}