// File:    ApprovalRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Class ApprovalRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.RepositoryDean
{
    public class ApprovalRepository : IApprovalRepository
    {
        private string _path = "approvals.json";
        private IDrugRepository _drugRepo;

        public ApprovalRepository(DrugRepository repo)
        {
            this._drugRepo = repo;
            if(!File.Exists(_path))
            {
                SaveAll(new List<DrugApproval>());
            }
        }
        
        private void SaveAll(List<DrugApproval> Approvals)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, Approvals);
                }
            }
        }

        public bool Create(DrugApproval obj)
        {
            List<DrugApproval> Approvals = GetAll();
            if(!Approvals.Contains(obj))
            {
                Approvals.Add(obj);
                SaveAll(Approvals);
                return true;
            }
            return false;
        }

        public bool Update(DrugApproval obj)
        {
            List<DrugApproval> Approvals = GetAll();
            DrugApproval approval = Approvals.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if(approval != null)
            {
                approval = obj;
                SaveAll(Approvals);
                return true;
            }
            return false;
        }

        public DrugApproval Get(string id)
        {
            List<DrugApproval> Approvals = GetAll();
            DrugApproval approval = Approvals.FirstOrDefault(x => x.Id.Equals(id));
            if (approval == null) return null;
            approval.DrugtoBeApproved = this._drugRepo.Get(approval.DrugtoBeApproved.Id);
            return approval;
        }
        

        public bool Delete(string id)
        {
            List<DrugApproval> Approvals = GetAll();
            DrugApproval approval = Approvals.FirstOrDefault(x => x.Id.Equals(id));
            if(approval != null)
            {
                Approvals.Remove(approval);
                SaveAll(Approvals);
                return true;
            }
            return false;
        }

        public List<DrugApproval> GetAll()
        {
            string json = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(json))
            {
                List<DrugApproval> Approvals = JsonConvert.DeserializeObject<List<DrugApproval>>(json);
                foreach(DrugApproval approval in Approvals)
                {
                    approval.DrugtoBeApproved = this._drugRepo.Get(approval.DrugtoBeApproved.Id);
                }
                return Approvals;
            }
            return new List<DrugApproval>();
        }
    }
}