// File:    DrugApprovalRequest.cs
// Created: Monday, June 01, 2020 4:57:22 PM
// Purpose: Definition of Class DrugApprovalRequest



public class DrugApproval
{
    public string Title { get; set; }
    public string RequestBody { get; set; }
    public ApprovalStatus Status { get; set; }
    public string Comment { get; set; }
    public string Id { get; set; }

    public Drug DrugtoBeApproved { get; set; }

    public DrugApproval() { }

    public DrugApproval(string title, string requestBody, string id, Drug drugToBeApproved) {
        Title = title;
        RequestBody = requestBody;
        Status = ApprovalStatus.PENDING;
        Id = id;
        DrugtoBeApproved = new Drug(drugToBeApproved.Id);
    }

}
