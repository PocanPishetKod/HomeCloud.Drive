import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
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
    return this.httpClient
      .get<IDirectoryDescryptor[]>(this.routeDescryptor.getManyRoute(parentDirectoryDescryptorId));
  }

  public async getDirectoryDescryptorsAsync(parentDirectoryDescryptorId?: number): Promise<IDirectoryDescryptor[]> {
    let result = await this
      .getDirectoryDescryptors(parentDirectoryDescryptorId).toPromise().then<IDirectoryDescryptor[], HttpErrorResponse>((data) => {
        return data;
      }, (error: HttpErrorResponse) => {
          return error;
      });

    return <IDirectoryDescryptor[]>result;
  }

  public saveDirectoryDescryptor(directoryDescryptor: IDirectoryDescryptor): Observable<IDirectoryDescryptor> {
    return this
      .httpClient.post<IDirectoryDescryptor>(this.routeDescryptor.getSaveRoute(), directoryDescryptor);
  }

  public async saveDirectoryDescryptorAsync(directoryDescryptor: IDirectoryDescryptor): Promise<IDirectoryDescryptor> {
    return await this
      .saveDirectoryDescryptor(directoryDescryptor).toPromise();
  }

  public deleteDirectoryDescryptor(directoryDescryptorId: number): Observable<void> {
    return this
      .httpClient.delete<void>(this.routeDescryptor.getDeleteRoute(directoryDescryptorId));
  }

  public async deleteDirectoryDescryptorAsync(directoryDescryptorId: number): Promise<void> {
    return await this
      .deleteDirectoryDescryptor(directoryDescryptorId).toPromise();
  }
}
