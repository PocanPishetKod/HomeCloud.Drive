import { Component } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "add-directory-modal",
  templateUrl: "./add-directory-modal.component.html"
})
export class AddDirectoryModalComponent {
  public name: string;

  constructor(private activeModal: NgbActiveModal) {
    this.name = "";
  }

  public close(): void {
    this.activeModal.dismiss();
  }

  public ok(): void {
    this.activeModal.close(this.name);
  }
}
