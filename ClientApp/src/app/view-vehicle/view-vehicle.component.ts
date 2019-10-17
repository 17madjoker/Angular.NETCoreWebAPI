import { VehicleService } from "../services/vehicle.service";
import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {PhotoService} from "../services/photo.service";
import 'bootstrap';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
})
export class ViewVehicleComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private photoService: PhotoService) {

    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
      if (isNaN(this.vehicleId) || this.vehicleId <= 0) {
        router.navigate(['/vehicles']);
        return;
      }
    });
  }

  @ViewChild("fileInput", {static: false}) fileInput: ElementRef;
  vehicle: any;
  vehicleId: number;
  photos: any;

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicleId)
      .subscribe(
        v => this.vehicle = v,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/vehicles']);
            return;
          }
        });

    this.photoService.getPhotos(this.vehicleId)
      .subscribe(photos => this.photos = photos);
  }

  delete() {
    if (confirm("Are you sure?")) {
      this.vehicleService.deleteVehicle(this.vehicle.id)
        .subscribe(x => {
          this.router.navigate(['/vehicles']);
        });
    }
  }

  uploadPhoto() {
    var nativeElement : HTMLInputElement = this.fileInput.nativeElement;

    this.photoService.upload(this.vehicleId, nativeElement.files[0])
      .subscribe(photo => {
        this.photos.push(photo);
      });
  }
}
