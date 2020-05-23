import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from './map/map.component';
import { AddMarkerPopUpComponent } from './add-marker-pop-up/add-marker-pop-up.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [
    MapComponent,
    AddMarkerPopUpComponent,
    LeaderboardComponent],
  entryComponents: [
    AddMarkerPopUpComponent,
    LeaderboardComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatBottomSheetModule,
    MatListModule
  ],
  exports: [MapComponent, AddMarkerPopUpComponent, LeaderboardComponent]
})
export class MapModule { }
