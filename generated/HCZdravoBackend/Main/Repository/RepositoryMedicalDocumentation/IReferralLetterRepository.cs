// File:    IReferralLetterRepository.cs
// Created: Wednesday, May 27, 2020 2:01:33 AM
// Purpose: Definition of Interface IReferralLetterRepository

using Microsoft.SqlServer.Server;
using System.Collections.Generic;

namespace Repository.RepositoryMedicalDocumentation
{
    public interface IReferralLetterRepository : IRepository<ReferralLetter>
    {
        bool Create(ReferralLetter obj);

        bool Delete(string id);

        bool Update(ReferralLetter obj);

        ReferralLetter Get(string id);

        List<ReferralLetter> GetAll();

        void SaveAll(List<ReferralLetter> referralLetters);
    }
}