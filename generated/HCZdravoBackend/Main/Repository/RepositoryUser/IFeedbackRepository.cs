// File:    IFeedbackRepository.cs
// Created: Wednesday, May 27, 2020 12:24:45 AM
// Purpose: Definition of Interface IFeedbackRepository

using Repository;
using System.Collections.Generic;

public interface IFeedbackRepository : IRepository<Feedback>
{
    bool Create(Feedback obj);

    bool Delete(string id);

    bool Update(Feedback obj);

    Feedback Get(string id);

    List<Feedback> GetAll();

    void SaveAll(List<Feedback> obj);

}
