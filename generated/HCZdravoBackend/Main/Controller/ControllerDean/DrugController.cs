// File:    DrugController.cs
// Created: Thursday, May 21, 2020 4:55:01 PM
// Purpose: Definition of Class DrugController

using Service.ServiceDean;
using System;
using System.Collections.Generic;

namespace Controller.ControllerDean
{
    public class DrugController
    {
        private DrugServices _drugServices;

        public DrugController(DrugServices dserv)
        {
            this._drugServices = dserv;
        }

        public bool Add(Drug drug)
        {
            return this._drugServices.Add(drug);
        }

        public bool Remove(string id)
        {
            return this._drugServices.Remove(id);
        }

        public bool Set(Drug drug)
        {
            return this._drugServices.Set(drug);
        }

        public Drug Get(string id)
        {
            return this._drugServices.Get(id);
        }

        public List<Drug> GetAll()
        {
            return this._drugServices.GetAll();
        }
    }
}