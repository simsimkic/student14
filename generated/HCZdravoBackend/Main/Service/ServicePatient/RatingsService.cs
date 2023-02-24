// File:    RatingsService.cs
// Created: Sunday, May 24, 2020 5:36:48 PM
// Purpose: Definition of Class RatingsService

using Repository.RepositoryPatient;
using System;
using System.Collections.Generic;

namespace Service.ServicePatient
{
    public class RatingsService
    {
        private IRatingsRepository _iRatingsRepository;
        public RatingsService(RatingsRepository ratingsRepository)
        {
            _iRatingsRepository = ratingsRepository;
        }
        public List<Rating> GetAllDoctorsRatings(Doctor doctor)
            => _iRatingsRepository.GetAllDoctorsRatings(doctor);

        public bool RateDoctor(Rating rating)
            => _iRatingsRepository.Create(rating);

        public List<Rating> GetAllPatientsRatings(RegisteredPatient patient)
            => _iRatingsRepository.GetAllPatientsRatings(patient);


        public bool EditRating(Rating rating)
            => _iRatingsRepository.Update(rating);

        public Rating GetRatingById(String id)
            => _iRatingsRepository.Get(id);

        public bool RemoveRating(string ratingId)
            => _iRatingsRepository.Delete(ratingId);

        public List<Rating> GetAllRatings()
            => _iRatingsRepository.GetAll();

    }
}