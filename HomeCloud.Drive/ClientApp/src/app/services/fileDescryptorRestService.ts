import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IFileDescryptor } from "../models/fileDescryptor";
import { FileDescryptorRouteDescryptor } from "./routerDescryptors";

@Injectable({
  providedIn: "root"
})
export class FileDescryptorRestService {
  constructor(private httpClient: HttpClient) {

  }

  public getFileDescryptors(directoryDescryptorId?: number): Observable<IFileDescryptor[]> {
    let routeDescryptor = new FileDescryptorRouteDescryptor();
    return this.httpClient.get<IFileDescryptor[]>(routeDescryptor.getManyRoute(directoryDescryptorId));
  }

  public async getFileDescryptorsAsync(directoryDescryptorId?: number): Promise<IFileDescryptor[]> {
    return await this.getFileDescryptors(directoryDescryptorId).toPromise();
  }
}
