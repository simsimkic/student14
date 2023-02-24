using Service.ServiceDean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controller.ControllerDean
{
    public class StaffController
    {
        private StaffServices _staffServices;

        public StaffController(StaffServices sserv)
        {
            this._staffServices = sserv;
        }

        public bool AddDoctor(Doctor doctor)
        {
            return this._staffServices.AddDoctor(doctor);
        }

        public bool RemoveDoctor(string id)
        {
            return this._staffServices.RemoveDoctor(id);
        }

        public void MoveToVacation(string id)
        {
            this._staffServices.MoveToVacation(id);
        }

        public void MoveToWorking(string id)
        {
            this._staffServices.MoveToWorking(id);
        }

        public void AddShift(Shift shift, Doctor doctor)
        {
            this._staffServices.AddShift(shift, doctor);
        }

        public void RemoveShift(Shift shift, Doctor doctor)
        {
            this._staffServices.RemoveShift(shift, doctor);
        }

        public Doctor GetDoctor(string id)
        {
            return this._staffServices.GetDoctor(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return this._staffServices.GetAllDoctors();
        }

        public bool AddSecretary(Secretary secretary)
        {
            return this._staffServices.AddSecretary(secretary);
        }

        public bool RemoveSecretary(string id)
        {
            return this._staffServices.RemoveSecretary(id);
        }

        public Secretary GetSecretary(string id)
        {
            return this._staffServices.GetSecretary(id);
        }

        public List<Secretary> GetAllSecretaries()
        {
            return this._staffServices.GetAllSecretaries();
        }
    }
}
