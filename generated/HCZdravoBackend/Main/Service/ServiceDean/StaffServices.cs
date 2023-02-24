// File:    StaffServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Class StaffServices

using Repository.RepositoryDoctor;
using Repository.RepositorySecretary;
using System;
using System.Collections.Generic;

namespace Service.ServiceDean
{
    public class StaffServices
    {
        private IDoctorRepository _doctorRepo;
        private ISecretaryRepository _secretaryRepo;

        public StaffServices(DoctorRepository drrepo, SecretaryRepository secrepo)
        {
            this._doctorRepo = drrepo;
            this._secretaryRepo = secrepo;
        }

        public bool AddDoctor(Doctor doctor)
        {
            return this._doctorRepo.Create(doctor);
        }

        public bool RemoveDoctor(string id)
        {
            return this._doctorRepo.Delete(id);
        }

        public bool SaveDoctor(Doctor doctor)
        {
            return this._doctorRepo.Update(doctor);
        }

        public void MoveToVacation(string id)
        {
            Doctor doctor = this._doctorRepo.Get(id);
            if (doctor == null) return;
            doctor.Status = DoctorStatus.VACATION;
            this._doctorRepo.Update(doctor);
        }

        public void MoveToWorking(string id)
        {
            Doctor doctor = this._doctorRepo.Get(id);
            if (doctor == null) return;
            doctor.Status = DoctorStatus.WORKING;
            this._doctorRepo.Update(doctor);
        }

        public Shift GetDayShift(DateTime day, string doctorId)
        {
            Doctor doctor = this._doctorRepo.Get(doctorId);
            if (doctor == null) return null;
            foreach(Shift sh in doctor.Shifts)
            {
                if(sh.Start.Date == day.Date)
                {
                    return sh;
                }
            }
            return null;
        }

        public void AddShift(Shift shift, Doctor doctor)
        {
            foreach(Shift drshift in doctor.Shifts)
            {
                if (DateTime.Compare(shift.Start, drshift.Start) < 0
                    && DateTime.Compare(shift.End, drshift.End) > 0)
                    return;
                if (DateTime.Compare(shift.Start, drshift.Start) > 0
                    && DateTime.Compare(shift.End, drshift.End) < 0)
                    return;
            }
            doctor.Shifts.Add(shift);
            this._doctorRepo.Update(doctor);
        }

        public void RemoveShift(Shift shift, Doctor doctor)
        {
            doctor.Shifts.Remove(shift);
        }

        public Doctor GetDoctor(string id)
        {
            return this._doctorRepo.Get(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return this._doctorRepo.GetAll();
        }

        public bool AddSecretary(Secretary secretary)
        {
            return this._secretaryRepo.Create(secretary);
        }

        public bool RemoveSecretary(string id)
        {
            return this._secretaryRepo.Delete(id);
        }

        public Secretary GetSecretary(string id)
        {
            return this._secretaryRepo.Get(id);
        }

        public List<Secretary> GetAllSecretaries()
        {
            return this._secretaryRepo.GetAll();
        }

        public bool SaveSecretary(Secretary sec)
        {
            return this._secretaryRepo.Update(sec);
        }

    }
}