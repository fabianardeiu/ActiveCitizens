import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddMarkerDialogData } from './add-marker-dialog-data';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Marker } from '../models/marker';

@Component({
    selector: 'app-add-marker-pop-up',
    templateUrl: './add-marker-pop-up.component.html',
    styleUrls: ['./add-marker-pop-up.component.scss']
})

export class AddMarkerPopUpComponent implements OnInit {
  marker: Marker;
  markerForm: FormGroup;
  imageRequired: boolean;
  constructor(
    public dialogRef: MatDialogRef<AddMarkerPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddMarkerDialogData,
    private fb: FormBuilder,) {
  }

  ngOnInit(): void {
    this.marker = new Marker();
    this.markerForm = this.fb.group({
      description: ['', [Validators.required]],
      image: ['', [Validators.required]]
    });
  }

  onFileChanged(event) {
    let reader = new FileReader();
    let file = event.target.files[0];
    reader.onload = () => {
      this.marker.image = reader.result.slice(23);
    };
    reader.readAsDataURL(file);
    this.imageRequired = false;
  }

  onConfirm() {
    if (this.markerForm.valid) {
      this.marker.description = this.markerForm.get('description').value;
      this.marker.latitude = this.data.marker.latitude;
      this.marker.longitude = this.data.marker.longitude;
      this.dialogRef.close(this.marker);
      this.marker = new Marker();
    } else {
      if (this.marker.image == null) {
        this.imageRequired = true;
      }
    }
  }

  onDecline() {
    this.dialogRef.close(false);
  }
}
