// File:    ApprovalServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Class ApprovalServices

using Repository.RepositoryDean;
using System;
using System.Collections.Generic;

namespace Service.ServiceDean
{
    public class ApprovalServices
    {
        private IApprovalRepository _approvalRepo;
        private DrugServices _drugServices;

        public ApprovalServices(ApprovalRepository repo, DrugServices dserv)
        {
            this._approvalRepo = repo;
            this._drugServices = dserv;
        }

        public bool Add(DrugApproval approval)
        {
            return this._approvalRepo.Create(approval);
        }

        public List<DrugApproval> GetAll()
        {
            return this._approvalRepo.GetAll();
        }

        public List<DrugApproval> GetPending()
        {
            List<DrugApproval> Result = new List<DrugApproval>();
            foreach(DrugApproval approval in this._approvalRepo.GetAll())
            {
                if(approval.Status == ApprovalStatus.PENDING)
                {
                    Result.Add(approval);
                }
            }
            return Result;
        }

        public List<DrugApproval> GetAccepted()
        {
            List<DrugApproval> Result = new List<DrugApproval>();
            foreach (DrugApproval approval in this._approvalRepo.GetAll())
            {
                if (approval.Status == ApprovalStatus.APPROVED)
                {
                    Result.Add(approval);
                }
            }
            return Result;
        }

        public List<DrugApproval> GetRejected()
        {
            List<DrugApproval> Result = new List<DrugApproval>();
            foreach(DrugApproval approval in this._approvalRepo.GetAll())
            {
                if(approval.Status == ApprovalStatus.REJECTED)
                {
                    Result.Add(approval);
                }
            }
            return Result;
        }

        public DrugApproval Get(string id)
        {
            return this._approvalRepo.Get(id);
        }

        public bool Remove(string id)
        {
            return this._approvalRepo.Delete(id);
        }

        public void Accept(string id, string comment)
        {
            DrugApproval appr = this._approvalRepo.Get(id);
            if (appr == null) return;
            appr.Status = ApprovalStatus.APPROVED;
            appr.Comment = comment;
            this._approvalRepo.Update(appr);
            this._drugServices.ApproveDrug(appr.DrugtoBeApproved.Id);
        }

        public void Reject(string id, string comment)
        {
            DrugApproval appr = this._approvalRepo.Get(id);
            if (appr == null) return;
            appr.Status = ApprovalStatus.REJECTED;
            appr.Comment = comment;
            this._approvalRepo.Update(appr);
        }

        public void MoveToPending(string id)
        {
            DrugApproval appr = this._approvalRepo.Get(id);
            if (appr == null) return;
            appr.Status = ApprovalStatus.PENDING;
            this._approvalRepo.Update(appr);
        }
    }
}