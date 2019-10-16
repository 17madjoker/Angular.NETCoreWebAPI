using System.Collections.Generic;
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

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            CreateMap<Make, MakeResource>();
            
            CreateMap<Make, KeyValuePairResource>();
            
            CreateMap<Model, KeyValuePairResource>();
            
            CreateMap<Feature, KeyValuePairResource>();
            
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vehRes => vehRes.Contact,
                    operObj => operObj
                        .MapFrom(veh => new ContactResource { Name = veh.ContactName, Phone = veh.ContactPhone, Email = veh.ContactEmail}))
                .ForMember(vehRes => vehRes.Features,
                    operObj => operObj.MapFrom(veh => veh.Features.Select(vFeature => vFeature.FeatureId)));
            
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vehRes => vehRes.Contact,
                    operObj => operObj
                        .MapFrom(veh => new ContactResource {Name = veh.ContactName, Phone = veh.ContactPhone, Email = veh.ContactEmail}))
                .ForMember(vehRes => vehRes.Features,
                    operObj => operObj
                        .MapFrom(veh => veh.Features
                            .Select(vFeature => new KeyValuePairResource {Id = vFeature.FeatureId, Name = vFeature.Feature.Name})))
                .ForMember(vehRes => vehRes.Make,
                    operObj => operObj.MapFrom(veh => veh.Model.Make));
            
            // From Resource to API mapping

            CreateMap<VehicleQueryResource, VehicleQuery>();
            
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(veh => veh.Id, operObj => operObj.Ignore())
                .ForMember(veh => veh.ContactName,
                    operObj => operObj.MapFrom(vehRes => vehRes.Contact.Name))
                .ForMember(veh => veh.ContactEmail,
                    operObj => operObj.MapFrom(vehRes => vehRes.Contact.Email))
                .ForMember(veh => veh.ContactPhone,
                    operObj => operObj.MapFrom(vehRes => vehRes.Contact.Phone))
                .ForMember(veh => veh.Features, operObj => operObj.Ignore())
                .AfterMap((vehRes, veh) =>
                {
                    // Remove unselected features
                    
                    var removedFeatures = new List<VehicleFeature>();
                    
                    foreach (var feature in veh.Features)
                    {
                        if (!vehRes.Features.Contains(feature.FeatureId))
                            removedFeatures.Add(feature);
                    }

                    foreach (var feature in removedFeatures)
                        veh.Features.Remove(feature);
                    
                    // Remove unselected features LINQ
                    
//                    var removedFeatures = vehicle.Features.Where(feature => !vehicleResource.Features.Contains(feature.FeatureId));
//
//                    foreach (var feature in removedFeatures)
//                        vehicle.Features.Remove(feature);
                    
                    // Add new features

//                    foreach (var featureId in vehicleResource.Features)
//                    {
//                        if (vehicle.Features.All(feature => feature.FeatureId != featureId))
//                            vehicle.Features.Add(new VehicleFeature {FeatureId = featureId});
//                    }

//                    Add new features LINQ

                    var addedFeatures = vehRes.Features.Where(featureId =>
                        veh.Features.All(feature => feature.FeatureId != featureId))
                            .Select(featureId => new VehicleFeature{ FeatureId = featureId});
                    
                    foreach (var feature in addedFeatures)
                        veh.Features.Add(feature);
                });
        }
    }
}