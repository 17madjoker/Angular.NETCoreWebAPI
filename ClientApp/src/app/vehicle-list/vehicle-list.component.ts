import { Component, OnInit } from '@angular/core';
import {Vehicle} from "../models/vehicle";
import {VehicleService} from "../services/vehicle.service";
import {KeyValuePair} from "../models/keyValuePair";

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html'
})
export class VehicleListComponent implements OnInit {

  private readonly PAGE_SIZE = 4;

  constructor(private vehicleService: VehicleService) { }

  queryResult: any = {};
  makes: KeyValuePair[];
  models: KeyValuePair[];
  query: any = {
    pageSize: this.PAGE_SIZE,
  };

  ngOnInit() {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes as KeyValuePair[]);

    this.vehicleService.getModels()
      .subscribe(models => this.models = models as KeyValuePair[]);

    this.getVehicles();
  }

  onFilterChange() {
    this.query.page = 1;
    this.getVehicles();
  }

  sortBy(sortBy: string) {
    if (this.query.sortBy === sortBy) {
      this.query.isSortAsc = !this.query.isSortAsc;
    } else {
      this.query.sortBy = sortBy;
      this.query.isSortAsc = true;
    }

    this.getVehicles();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE,
    };
    this.getVehicles();
  }

  private getVehicles() {
    this.vehicleService.getVehicles(this.query)
      .subscribe(result => this.queryResult = result);
  }

  onPageChange(page) {
    this.query.page = page;
    this.getVehicles();
  }
}
