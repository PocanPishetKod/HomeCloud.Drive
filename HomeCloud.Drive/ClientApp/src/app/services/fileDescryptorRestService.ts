import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { IFileDescryptor } from "../models/fileDescryptor";
import { FileDescryptorRouteDescryptor } from "./routerDescryptors";
import { IUploadFile } from "../models/uploadFile";

@Injectable({
  providedIn: "root"
})
export class FileDescryptorRestService {
  private routeDescryptor: FileDescryptorRouteDescryptor;

  constructor(private httpClient: HttpClient) {
    this.routeDescryptor = new FileDescryptorRouteDescryptor();
  }

  public getFileDescryptors(directoryDescryptorId?: number): Observable<IFileDescryptor[]> {
    return this.httpClient
      .get<IFileDescryptor[]>(this.routeDescryptor.getManyRoute(directoryDescryptorId));
  }

  public async getFileDescryptorsAsync(directoryDescryptorId?: number): Promise<IFileDescryptor[]> {
    let result = await this
      .getFileDescryptors(directoryDescryptorId).toPromise();
    if (!result || result.length == 0) {
      return [];
    }

    return result;
  }

  public deleteFileDescryptor(fileDescryptorId: number): Observable<void> {
    return this
      .httpClient.delete<void>(this.routeDescryptor.getDeleteRoute(fileDescryptorId));
  }

  public async deleteFileDescryptorAsync(fileDescryptorId: number): Promise<void> {
    return await this
      .deleteFileDescryptor(fileDescryptorId).toPromise();
  }

  public uploadFile(uploadFile: IUploadFile): Observable<IFileDescryptor> {
    let formData = new FormData();
    formData.append("file", uploadFile.file, uploadFile.file.name);

    if (uploadFile.directoryDescryptorId && uploadFile.directoryDescryptorId > 0) {
      formData.append("directoryDescryptorId", uploadFile.directoryDescryptorId.toString());
    }

    return this.httpClient
      .post<IFileDescryptor>(this.routeDescryptor.getUploadRoute(), formData);
  }

  public async uploadFileAsync(uploadFile: IUploadFile): Promise<IFileDescryptor> {
    return await this
      .uploadFile(uploadFile).toPromise();
  }

  public downloadFile(fileDescryptorId: number): void {
    this.httpClient.get(this.routeDescryptor.getDownloadRoute(fileDescryptorId), { responseType: "blob" }).subscribe(res => {
      let downloadUrl = window.URL.createObjectURL(res);
      window.open(downloadUrl);
    });
  }
}
