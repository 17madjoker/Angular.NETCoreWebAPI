import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { tap } from 'rxjs/operators/';
import {SaveVehicle} from "../models/vehicle";

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get("/api/makes", {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  getModels() {
    return this.http.get("/api/models", {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  getFeatures() {
    return this.http.get("/api/features", {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  createVehicle(vehicle: SaveVehicle) {
    delete vehicle.id;
    return this.http.post("/api/vehicles", vehicle, {responseType: 'json'})
      .pipe(
        tap(
          newVehicle => console.log(newVehicle),
          error => console.log(error)
        )
      );
  }

  updateVehicle(vehicle : SaveVehicle) {
    return this.http.put("/api/vehicles/" + vehicle.id, vehicle, {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  deleteVehicle(id: number) {
    return this.http.delete("/api/vehicles/" + id, {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  getVehicle(id: number) {
    return this.http.get("/api/vehicles/" + id, {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  getVehicles(filter) {
    return this.http.get("/api/vehicles/" + "?" + this.toQueryString(filter), {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );
  }

  toQueryString(obj) {
    var params = [];
    for (var prop in obj) {
      var value = obj[prop];

      if (value != null && value != undefined) {
        params.push(encodeURIComponent(prop) + "=" + encodeURIComponent(value));
      }
    }

    return params.join("&");
  }

  // return this.http.jsonp("/api/makes", 'callback').pipe(
  //    // then handle the error
  //   );

  // return this.http.get("/api/makes")
  //   .pipe(map(res => res.jsonp()));
}
