import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Citizen } from '../models/citizen';

@Injectable({
  providedIn: 'root'
})

export class AuthentificationService {

  private baseUrl = 'api/authentification';

  private readonly apiHost = 'https://localhost:5004';

  constructor(private httpClient: HttpClient) {
  }

  login(user: User): Observable<Citizen> {
    return this.httpClient.post<Citizen>(`${this.apiHost}/${this.baseUrl}`, user);
  }
}
