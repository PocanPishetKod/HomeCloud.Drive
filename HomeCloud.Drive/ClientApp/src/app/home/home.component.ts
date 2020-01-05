import { Component } from '@angular/core';
import { DirectoryDescryptorRestService } from '../services/directoryDescryptorRestService';
import { FileDescryptorRestService } from '../services/fileDescryptorRestService';
import { IFileDescryptor } from '../models/fileDescryptor';
import { IDirectoryDescryptor } from '../models/directoryDescryptor';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddDirectoryModalComponent } from '../modals/add-directory-modal.component';
import { UploadFileComponent } from '../modals/upload-file.component';
import { IUploadFile } from '../models/uploadFile';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ["../css/filesTable.css"]
})
export class HomeComponent {
  public fileDescryptors: Array<IFileDescryptor>;
  public directoryDescryptors: Array<IDirectoryDescryptor>;
  public currentDirectoryDescryptor: IDirectoryDescryptor;
  private previousDirectoryDescryptors: Array<IDirectoryDescryptor>;

  constructor(private directoryDescryptorApi: DirectoryDescryptorRestService,
    private fileDescryptorApi: FileDescryptorRestService, private modalService: NgbModal) {
    this.fileDescryptors = [];
    this.directoryDescryptors = [];
    this.currentDirectoryDescryptor = null;
    this.previousDirectoryDescryptors = [];
  }

  private getNewDirectoryDescryptor(name: string): IDirectoryDescryptor {
    let parentId: number = this.currentDirectoryDescryptor ? this.currentDirectoryDescryptor.id : null;
    return <IDirectoryDescryptor>{ id: 0, name: name, parentDirectoryDescryptorId: parentId };
  }

  private getNewUploadFile(file: File): IUploadFile {
    let parentId: number = this.currentDirectoryDescryptor ? this.currentDirectoryDescryptor.id : null;
    return <IUploadFile>{ file: file, directoryDescryptorId: parentId };
  }

  private async updateDescryptors(directoryDescryptor?: IDirectoryDescryptor): Promise<void> {
    let parentId: number = directoryDescryptor ? directoryDescryptor.id : null;
    this.currentDirectoryDescryptor = directoryDescryptor;

    let fdResult = await this.fileDescryptorApi.getFileDescryptorsAsync(parentId);
    let ddResult = await this.directoryDescryptorApi.getDirectoryDescryptorsAsync(parentId);

    this.fileDescryptors = fdResult.map(x => <IFileDescryptor>{ id: x.id, name: x.name, directoryDescryptorId: x.directoryDescryptorId });
    this.directoryDescryptors = ddResult.map(x => <IDirectoryDescryptor>{ id: x.id, name: x.name, parentDirectoryDescryptorId: x.parentDirectoryDescryptorId });
  }

  public async ngOnInit(): Promise<void> {
    await this.updateDescryptors();
  }

  public async goToDirectory(directoryDescryptor: IDirectoryDescryptor): Promise<void> {
    this.previousDirectoryDescryptors.push(this.currentDirectoryDescryptor);
    await this.updateDescryptors(directoryDescryptor);
  }

  public async goToPreviousDirectory(): Promise<void> {
    if (this.previousDirectoryDescryptors.length > 0) {
      this.updateDescryptors(this.previousDirectoryDescryptors.pop());
    }
  }

  public async createDirectory(): Promise<void> {
    let openedModal = this.modalService.open(AddDirectoryModalComponent);
    let name: string = await openedModal.result;
    if (name) {
      let createdDirectoryDescryptor = await this.directoryDescryptorApi
        .saveDirectoryDescryptorAsync(this.getNewDirectoryDescryptor(name));
      this.directoryDescryptors.push(createdDirectoryDescryptor);
    }
  }

  public async uploadFile(): Promise<void> {
    let openedModal = this.modalService.open(UploadFileComponent);
    let file: File = await openedModal.result;
    if (file) {
      let createdFileDescryptor = await this.fileDescryptorApi.uploadFileAsync(this.getNewUploadFile(file));
      this.fileDescryptors.push(createdFileDescryptor);
    }
  }
}
