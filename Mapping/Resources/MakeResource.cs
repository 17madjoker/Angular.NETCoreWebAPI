using System.Collections.Generic;
using AngularCoreApp.Models;

namespace AngularCoreApp.Mapping.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        public MakeResource()
        {
            Models = new List<KeyValuePairResource>();
        }
        
        public ICollection<KeyValuePairResource> Models { get; set; }
    }
}