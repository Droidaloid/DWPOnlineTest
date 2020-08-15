using System;
using System.Collections.Generic;

namespace DWPOnlineTest
{
    /*
    * This class uses the haversine formula to calculate the distance between 2 points 
    * on the earth (in miles) when provided with the latitude and longitude
    *
    * See: https://www.geeksforgeeks.org/program-distance-two-points-earth/
    */

    public class HaversineCalculator
    {

        private readonly Coordinates London = new Coordinates(51.509865, -0.118092);

        private double toRadians(double angle)
        {
            return (angle * Math.PI) / 180;
        } 

        public double distanceFromLondon(double latitude,  double longitude)
        {
            double 
                lat1 = toRadians(latitude), 
                lat2 = toRadians(London.Latitude), 
                lon1 = toRadians(longitude), 
                lon2 = toRadians(London.Longitude); 
            

            
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1; 
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +  Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2),2); 

            double c = 2 * Math.Asin(Math.Sqrt(a)); 

            double earthRadiusMiles = 3956;

            return (c * earthRadiusMiles); 
        }

    }
     

}