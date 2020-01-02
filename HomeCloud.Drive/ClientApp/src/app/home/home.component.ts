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
})
export class HomeComponent {
  public fileDescryptors: IFileDescryptor[];
  public directoryDescryptors: IDirectoryDescryptor[];
  public currentDirectoryDescryptor: IDirectoryDescryptor;

  constructor(private directoryDescryptorApi: DirectoryDescryptorRestService,
    private fileDescryptorApi: FileDescryptorRestService, private modalService: NgbModal) {
    this.currentDirectoryDescryptor = null;
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
    let parentId: number = directoryDescryptor ? directoryDescryptor.parentDirectoryDescryptorId : null;
    this.currentDirectoryDescryptor = directoryDescryptor;
    this.fileDescryptors = await this.fileDescryptorApi.getFileDescryptorsAsync(parentId);
    this.directoryDescryptors = await this.directoryDescryptorApi.getDirectoryDescryptorsAsync(parentId);
  }

  public async ngOnInit(): Promise<void> {
    await this.updateDescryptors();
  }

  public async goToDirectory(directoryDescryptor: IDirectoryDescryptor): Promise<void> {
    await this.updateDescryptors(directoryDescryptor);
  }

  public async createDirectory(): Promise<void> {
    let openedModal = this.modalService.open(AddDirectoryModalComponent);
    let name: string = await openedModal.result;
    let createdDirectoryDescryptor = await this.directoryDescryptorApi
      .saveDirectoryDescryptorAsync(this.getNewDirectoryDescryptor(name));
    this.directoryDescryptors.push(createdDirectoryDescryptor);
  }

  public async uploadFile(): Promise<void> {
    let openedModal = this.modalService.open(UploadFileComponent);
    let file: File = await openedModal.result;
    let createdFileDescryptor = await this.fileDescryptorApi.uploadFileAsync(this.getNewUploadFile(file));
    this.fileDescryptors.push(createdFileDescryptor);
  }
}
