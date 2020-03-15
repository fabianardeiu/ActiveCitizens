import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Marker } from './models/marker';
import { MatDialog } from '@angular/material/dialog';
import { AddMarkerPopUpComponent } from './add-marker-pop-up/add-marker-pop-up.component';
import { MarkerService } from './services/marker.service';
import { Location } from './models/location';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
   
  apiHost: string;
  markerUrl: string;
  markers: Marker[] = [];
  marker: Marker;

  //map Configuration
  zoom = 14;
  lat: number = 45.751517;
  lng: number = 21.224905;

  origin: any;
  destination: any;

  constructor(private dialog: MatDialog,
    private markerService: MarkerService) {
  }

  ngOnInit(): void {
    this.markerService.getAll().subscribe(res => console.log(res));
  }

  createMarker(event) {
    this.marker = new Marker();
    this.marker.latitude = event.coords.lat;
    this.marker.longitude = event.coords.lng;
    this.marker.solved = false;
    this.createMarkerDialog(this.marker);
  }

  createMarkerDialog(marker: Marker) {
    let dialogRef = this.dialog.open(AddMarkerPopUpComponent, {
      width: '400px',
      data: {
        marker: marker
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.markers.push(result);
        this.markerService.createMaker(result).subscribe(res => console.log(res));
      }
    });
    dialogRef = null;
  }

  solve(marker: Marker) {
    this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).solved = true;
  }

  getDirection(marker: Marker) {
    navigator.geolocation.getCurrentPosition(pos => {
      this.origin = { lat: pos.coords.latitude, lng: pos.coords.longitude };
      this.destination = { lat: marker.latitude, lng: marker.longitude };
    })
  }

  cancelDirection() {
    this.origin = undefined;
    this.destination = undefined;
  }
}
