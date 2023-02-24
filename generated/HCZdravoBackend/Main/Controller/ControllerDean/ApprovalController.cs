using Service.ServiceDean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controller.ControllerDean
{
    public class ApprovalController
    {
        private ApprovalServices _approvalServices;

        public ApprovalController(ApprovalServices apserv)
        {
            this._approvalServices = apserv;
        }

        public bool Add(DrugApproval approval)
        {
            return this._approvalServices.Add(approval);
        }

        public bool Remove(string id)
        {
            return this._approvalServices.Remove(id);
        }

        public void Accept(string id, string comment)
        {
            this._approvalServices.Accept(id, comment);
        }

        public void Reject(string id, string comment)
        {
            this._approvalServices.Reject(id, comment);
        }

        public void MoveToPending(string id)
        {
            this._approvalServices.MoveToPending(id);
        }

        public List<DrugApproval> GetPending()
        {
            return this._approvalServices.GetPending();
        }

        public List<DrugApproval> GetAccepted()
        {
            return this._approvalServices.GetAccepted();
        }

        public List<DrugApproval> GetRejected()
        {
            return this._approvalServices.GetRejected();
        }

        public List<DrugApproval> GetAll()
        {
            return this._approvalServices.GetAll();
        }

        public DrugApproval Get(string id)
        {
            return this._approvalServices.Get(id);
        }
    }
}
