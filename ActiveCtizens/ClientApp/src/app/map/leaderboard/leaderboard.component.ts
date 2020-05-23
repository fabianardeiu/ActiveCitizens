import { Component, OnInit } from '@angular/core';
import { MatBottomSheetRef, MatBottomSheet } from '@angular/material/bottom-sheet';
import { CitizenService } from '../../services/citizen.service';
import { LeaderboardCitizen } from '../../models/leaderboard-citizen';

@Component({
    selector: 'app-leaderboard',
    templateUrl: './leaderboard.component.html',
    styleUrls: ['./leaderboard.component.scss']
})

export class LeaderboardComponent implements OnInit{
  displayedColumns: string[] = ['rank', 'name', 'solvedMarks', 'createdMarks', 'score'];

  citizens: LeaderboardCitizen[] = [];

  constructor(private _bottomSheetRef: MatBottomSheetRef<LeaderboardComponent>,
    private citizenService: CitizenService) {
  }

  ngOnInit(): void {
    this.citizenService.getLeadboard().subscribe(l => this.citizens = l);
  }

  openLink(event: MouseEvent): void {
    this._bottomSheetRef.dismiss();
    event.preventDefault();
  }

}
