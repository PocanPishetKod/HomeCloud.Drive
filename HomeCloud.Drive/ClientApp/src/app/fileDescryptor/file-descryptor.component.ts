import { Component, Input } from "@angular/core";
import { IFileDescryptor } from "../models/fileDescryptor";
import { FileDescryptorRestService } from "../services/fileDescryptorRestService";

@Component({
  selector: "file-descryptor",
  templateUrl: "./file-descryptor.component.html"
})
export class FileDescryptorComponent {
  @Input() public fileDescryptor: IFileDescryptor;

  constructor(private fileDescryptorApi: FileDescryptorRestService) {

  }

  public async delete(): Promise<void> {
    await this.fileDescryptorApi
      .deleteFileDescryptorAsync(this.fileDescryptor.id);
  }

  public download(): void {
    this.fileDescryptorApi.downloadFile(this.fileDescryptor.id);
  }
}
