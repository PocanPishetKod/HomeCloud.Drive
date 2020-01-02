import { Component } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "upload-file",
  templateUrl: "./upload-file.component.html"
})
export class UploadFileComponent {
  public file: File;

  constructor(private activeModal: NgbActiveModal) {

  }

  public close(): void {
    this.activeModal.dismiss();
  }

  public ok(): void {
    this.activeModal.close(this.file);
  }

  public selectFile(event: Event) {
    this.file = (<HTMLInputElement>event.target).files[0];
  }
}
