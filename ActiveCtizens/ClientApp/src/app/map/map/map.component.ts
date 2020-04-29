import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MarkerService } from '../../services/marker.service';
import { Marker } from '../../models/marker';
import { AddMarkerPopUpComponent } from '../add-marker-pop-up/add-marker-pop-up.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  apiHost: string;
  markerUrl: string;
  markers: Marker[] = [];
  marker: Marker;
  citizen: string = localStorage.getItem('citizen');
  //map Configuration
  zoom = 14;
  lat: number = 45.751517;
  lng: number = 21.224905;

  origin: any;
  destination: any;

  constructor(private dialog: MatDialog,
    private markerService: MarkerService,
    private router: Router,) {
  }

  ngOnInit(): void {
    this.markerService.getAll().subscribe(res => res.forEach(m => {
      m.image = "data:image/jpeg;base64," + m.image;
      this.markers = res;
    }))
  }

  createMarker(event) {
    this.marker = new Marker();
    this.marker.latitude = event.coords.lat;
    this.marker.longitude = event.coords.lng;
    this.marker.solved = false;
    this.marker.citizen = localStorage.getItem('citizen');
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
        this.markerService.createMarker(result).subscribe(res => {
          res.image = "data:image/jpeg;base64," + res.image;
          this.markers.push(res);
        })
      }
    });
    dialogRef = null;
  }

  solve(marker: Marker) {
    this.markerService.solveMarker(marker.id).subscribe(res => {
      this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).solved = true;
      this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).resolvedAt = res.resolvedAt;
    });
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

  logout() {
    this.router.navigate(['']);
  }
}
