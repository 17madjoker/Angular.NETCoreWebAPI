import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../services/vehicle.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs";
import 'rxjs/add/observable/forkJoin';

import { SaveVehicle, Vehicle } from "../models/vehicle";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes: any;
  features: any;
  models: any[];
  vehicle: SaveVehicle  = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: '',
    }
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService
  ) {
    route.params.subscribe(p => {
      this.vehicle.id = +p["id"];
    });
  }

  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if (this.vehicle.id) {
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));
    }

    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];

      if (this.vehicle.id) {
        this.setVehicle(data[2] as Vehicle);
        this.fillModels();
      }
    }, err => {
      this.router.navigate([""]);
    });
  }

  onMakeChange() {
    this.fillModels();
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

  submit() {
    if (this.vehicle.id) {
      this.vehicleService.updateVehicle(this.vehicle)
        .subscribe(res => {
          this.router.navigate([""]);
        });
    } else {
      this.vehicleService.createVehicle(this.vehicle)
        .subscribe(res => {
          this.router.navigate([""]);
        });
    }
  }

  delete() {
    if (confirm("Are you sure?")) {
      this.vehicleService.deleteVehicle(this.vehicle.id)
        .subscribe(res => {
          this.router.navigate([""]);
        });
    }
  }

  private fillModels() {
    var selectedMake = this.makes.find(make => make.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  private setVehicle(vehicle : Vehicle) {
    this.vehicle.id = vehicle.id;
    this.vehicle.makeId = vehicle.make.id;
    this.vehicle.modelId = vehicle.model.id;
    this.vehicle.isRegistered =  vehicle.isRegistered;
    this.vehicle.contact =  vehicle.contact;
    for (let f in vehicle.features) {
      this.vehicle.features.push(vehicle.features[f].id);
    }
  }
}
