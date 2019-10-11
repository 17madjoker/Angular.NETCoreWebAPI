using System.Linq;
using AngularCoreApp.Mapping.Resources;
using AngularCoreApp.Models;
using AutoMapper;

namespace AngularCoreApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // From API to Resource mapping

//            CreateMap<Make, MakeResource>().ForMember(vr => vr.Models,
//                opt => opt.MapFrom(v => v.Models.Select(vf => new Model {Id = vf.Id, Name = vf.Name})));

            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
        }
    }
}