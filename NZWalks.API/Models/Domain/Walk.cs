﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
         public Guid DifficultyID { get; set; }
         
        //Navigation Properties
        //->Allow to Navigate from one Entity to Another
        //->Walks Domain Model will have Region Navigation Property 
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
