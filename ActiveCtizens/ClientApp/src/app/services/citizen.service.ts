import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LeaderboardCitizen } from '../models/leaderboard-citizen';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CitizenService {
  private baseUrl = 'api/citizen';
  private readonly apiHost = 'https://localhost:5004';

  constructor(private httpClient: HttpClient) {
  }

  getLeadboard(): Observable<LeaderboardCitizen[]> {
    return this.httpClient.get<LeaderboardCitizen[]>(`${this.apiHost}/${this.baseUrl}/leaderboard`);
  }
}
