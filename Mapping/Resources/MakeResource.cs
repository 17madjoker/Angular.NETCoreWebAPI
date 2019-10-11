using System.Collections.Generic;
using AngularCoreApp.Models;

namespace AngularCoreApp.Mapping.Resources
{
    public class MakeResource
    {
        public MakeResource()
        {
            Models = new List<ModelResource>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ModelResource> Models { get; set; }
    }
}