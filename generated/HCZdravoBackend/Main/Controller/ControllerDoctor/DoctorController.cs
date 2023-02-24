// File:    DoctorController.cs
// Created: Thursday, May 21, 2020 9:28:53 PM
// Purpose: Definition of Class DoctorController

using Controller.ControllerUser;
using Service.ServiceDoctor;
using System.Collections.Generic;

namespace Controller.ControllerDoctor
{
    public class DoctorController
    {
        private DoctorService _doctorService;

        public DoctorController(DoctorService doctorService) {
            _doctorService = doctorService;
        }

        public void NewDoctor(Doctor doctor)
            => _doctorService.NewDoctor(doctor);


        public void EditDoctor(Doctor doctor)
           => _doctorService.EditDoctor(doctor);

        public void RemoveDoctor(Doctor doctor)
            => _doctorService.RemoveDoctor(doctor);

        public Doctor GetDoctorById(string id)
            => _doctorService.GetDoctorById(id);


        public List<Doctor> GetAllDoctors()
            => _doctorService.GetAllDoctors();

        public List<Doctor> GetAllDoctorsGeneralMedicine()
            => _doctorService.GetAllDoctorsGeneralMedicine();

        public List<Doctor> GetAllSpecialists()
            => _doctorService.GetAllSpecialists();

    }
}