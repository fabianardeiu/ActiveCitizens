import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MarkerService } from '../../services/marker.service';
import { Marker } from '../../models/marker';
import { AddMarkerPopUpComponent } from '../add-marker-pop-up/add-marker-pop-up.component';
import { Router } from '@angular/router';
import { SolveMarker } from '../../models/solve-marker';

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
    this.marker.createdByCitizen = this.citizen;
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
    let solveMarker = new SolveMarker();
    solveMarker.markerId = marker.id;
    solveMarker.citizen = this.citizen;
    this.markerService.solveMarker(solveMarker).subscribe(res => {
      this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).solved = true;
      this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).resolvedAt = res.resolvedAt;
      this.markers.find(m => m.latitude == marker.latitude && m.longitude == marker.longitude).resolvedByCitizen = res.resolvedByCitizen;
    });
  }

  getDirection(marker: Marker) {
    navigator.geolocation.getCurrentPosition(pos => {
      //this.origin = { lat: pos.coords.latitude, lng: pos.coords.longitude };
      this.origin = { lat: 45.75999716308822, lng: 21.238251328468326 };
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
