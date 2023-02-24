// File:    IRatingsRepository.cs
// Created: Wednesday, May 27, 2020 1:17:02 AM
// Purpose: Definition of Interface IRatingsRepository

using System.Collections.Generic;

namespace Repository.RepositoryPatient
{
    public interface IRatingsRepository : IRepository<Rating>
    {
        bool Create(Rating obj);

        bool Delete(string id);

        bool Update(Rating obj);

        Rating Get(string id);

        List<Rating> GetAll();

        List<Rating> GetAllDoctorsRatings(Doctor doctor);

        List<Rating> GetAllPatientsRatings(RegisteredPatient patient);

    }
}