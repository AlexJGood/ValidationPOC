using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidationPOC.Domain
{
    public class Forecast
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }


        public WantToBeComplex beComplex { get; set; }

        public ForecastDay[] ForecastDays
        {
            get; set;

        }


    }
}
