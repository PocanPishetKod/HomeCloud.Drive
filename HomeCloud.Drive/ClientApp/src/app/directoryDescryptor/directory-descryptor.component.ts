import { Component, Input } from "@angular/core";
import { IDirectoryDescryptor } from "../models/directoryDescryptor";
import { DirectoryDescryptorRestService } from "../services/directoryDescryptorRestService";

@Component({
  selector: "directory-descryptor",
  templateUrl: "./directory-descryptor.component.html",
  styleUrls: ["../css/fileItem.css"]
})
export class DirectoryDescryptorComponent {
  @Input() public directoryDescryptor: IDirectoryDescryptor;

  constructor(private directoryDescryptorApi: DirectoryDescryptorRestService) {

  }

  public async delete(): Promise<void> {
    await this.directoryDescryptorApi
      .deleteDirectoryDescryptorAsync(this.directoryDescryptor.id);
  }
}
