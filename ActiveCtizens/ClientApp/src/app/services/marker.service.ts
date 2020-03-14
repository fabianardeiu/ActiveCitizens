import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Marker } from '../models/marker';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class MarkerService {
  private baseUrl = 'api/marker';
  private readonly apiHost = 'https://localhost:5004';

  constructor(private httpClient: HttpClient) {
  }

  getAll(): Observable<Marker[]> {
    return this.httpClient.get<Marker[]>(`${this.apiHost}/${this.baseUrl}`);
  }

  createMaker(marker: Marker) {
    return this.httpClient.post(`${this.apiHost}/${this.baseUrl}`, marker);

  }
}
