import { Component, OnInit } from '@angular/core';
import { MakeService } from "../services/make.service";
import { Vehicle } from "../shared/Vehicle";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes: any;
  models: any[];
  vehicle : Vehicle = {};

  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes =>
      this.makes = makes);

    console.log("MAKES", this.makes);
  }

  onMakeChange() {
    console.log("VEHICLE", this.vehicle);

    var selectedMake = this.makes.find(make => make.id == this.vehicle.make);

    this.models = selectedMake ? selectedMake.models : [];
  }
}
