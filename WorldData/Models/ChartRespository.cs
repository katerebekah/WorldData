using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorldData.Models
{
    public class ChartRespository
    {
        private ChartContext context;
        
        public ChartRespository()
        {
            context = new ChartContext();
        }

        public ChartRespository(ChartContext _context) 
        {
            context = _context;
        }

        //Get All Countries
        //Get Country By Name (search)
        //Get All Cities By Country
        //Get City By Name (Search)
        //Get City By Id 
        
        //Get City Api URLS in Chart

        //Add City to Chart
        //Remove City from Chart
        //Update City Priority In Chart

    }
}