// File:    RatingsController.cs
// Created: Sunday, May 24, 2020 5:26:43 PM
// Purpose: Definition of Class RatingsController

using Service.ServicePatient;
using System;
using System.Collections.Generic;

namespace Controller.ControllerPatient
{
    public class RatingsController
    {
        private RatingsService _ratingsService;

        public RatingsController(RatingsService ratingsService)
        {
            _ratingsService = ratingsService;
        }

        public List<Rating> GetAllDoctorsRatings(Doctor doctor)
            => _ratingsService.GetAllDoctorsRatings(doctor);
        

        public bool RateDoctor(Rating rating)
            => _ratingsService.RateDoctor(rating);
        

        public List<Rating> GetAllPatientsRatings(RegisteredPatient patient)
            => _ratingsService.GetAllPatientsRatings(patient);
        

        public bool EditRating(Rating rating)
            => _ratingsService.EditRating(rating);
        

        public Rating GetRatingById(string ratingId)
            => _ratingsService.GetRatingById(ratingId);
        

        public void RemoveRating(string ratingId)
            => _ratingsService.RemoveRating(ratingId);
        

        public List<Rating> GetAllRatings()
            => _ratingsService.GetAllRatings();
        
    }
}