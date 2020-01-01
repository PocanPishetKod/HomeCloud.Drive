import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDirectoryDescryptor } from '../models/directoryDescryptor';
import { DirectoryDescryptorRouteDescryptor } from './routerDescryptors';

@Injectable({
  providedIn: 'root'
})
export class DirectoryDescryptorRestService {
  private routeDescryptor: DirectoryDescryptorRouteDescryptor;

  constructor(private httpClient: HttpClient) {
    this.routeDescryptor = new DirectoryDescryptorRouteDescryptor();
  }

  public getDirectoryDescryptors(parentDirectoryDescryptorId?: number): Observable<IDirectoryDescryptor[]> {
    return this.httpClient.get<IDirectoryDescryptor[]>(this.routeDescryptor.getManyRoute(parentDirectoryDescryptorId));
  }

  public async getDirectoryDescryptorsAsync(parentDirectoryDescryptorId?: number): Promise<IDirectoryDescryptor[]> {
    return await this.getDirectoryDescryptors(parentDirectoryDescryptorId).toPromise();
  }

  public saveDirectoryDescryptor(directoryDescryptor: IDirectoryDescryptor): Observable<IDirectoryDescryptor> {
    return this.httpClient.post<IDirectoryDescryptor>(this.routeDescryptor.getSaveRoute(), directoryDescryptor);
  }

  public async saveDirectoryDescryptorAsync(directoryDescryptor: IDirectoryDescryptor): Promise<IDirectoryDescryptor> {
    return await this.saveDirectoryDescryptor(directoryDescryptor).toPromise();
  }
}
