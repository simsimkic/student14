// File:    DrugServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Class DrugServices

using Repository.RepositoryDean;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.ServiceDean
{
    public class DrugServices : IInventoryServices<Drug>
    {

        private IDrugRepository _drugRepo;

        public DrugServices(DrugRepository repo)
        {
            this._drugRepo = repo;
        }

        public void ApproveDrug(string id)
        {
            List<Drug> Drugs = _drugRepo.GetAll();
            Drug drug = Drugs.FirstOrDefault(x => x.Id.Equals(id));
            if (drug == null) return;
            drug.Approved = true;
            this._drugRepo.Update(drug);
        }
        public bool Add(Drug obj)
        {
            return this._drugRepo.Create(obj);
        }

        public bool Set(Drug obj)
        {
            return this._drugRepo.Update(obj);
        }

        public List<Drug> GetAll()
        {
            return this._drugRepo.GetAll();
        }

        public Drug Get(string id)
        {
            return this._drugRepo.Get(id);
        }

        public bool Remove(string id)
        {
            return this._drugRepo.Delete(id);
        }

    }
}