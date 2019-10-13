import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../services/vehicle.service";
import { Vehicle } from "../shared/Vehicle";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes: any;
  features: any;
  models: any[];
  vehicle : Vehicle = {
    features: []
  };

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes =>
      this.makes = makes);

    this.vehicleService.getFeatures().subscribe(features =>
      this.features = features);

    console.log("MAKES", this.makes);
    console.log("FEATURES", this.features);
  }

  onMakeChange() {
    console.log("VEHICLE", this.vehicle);

    var selectedMake = this.makes.find(make => make.id == this.vehicle.makeId);

    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId : number, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index,1);
    }

  }
}
