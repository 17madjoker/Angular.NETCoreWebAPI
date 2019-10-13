using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularCoreApp.Models
{
    [Table("VehiclesFeatures")]
    public class VehicleFeature
    {
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}