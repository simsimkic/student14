// File:    IApprovalRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Interface IApprovalRepository

using Repository;
using System.Collections.Generic;

public interface IApprovalRepository : IRepository<DrugApproval>
{
    bool Create(DrugApproval obj);

    bool Delete(string id);

    bool Update(DrugApproval obj);

    DrugApproval Get(string id);

    List<DrugApproval> GetAll();
    

}
