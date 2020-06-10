import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FileService } from './file.service';
import { FileMetadata } from './file.model';
import { clientGuidPrefix } from 'src/shared/utility/type-utils';
import { Item } from './item.model';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  editForm: FormGroup;
  uploadForm: FormGroup;
  imgUrl = '/assets/placeholder-screenshot.jpg';
  fileId = '';
  fileData!: FileMetadata;
  isUploading = false;
  acceptedFileTypes = [
    'image/jpeg',
    'image/jpg',
    'image/bmp',
    'image/png'
  ];

  constructor(
    public dialogRef: MatDialogRef<ItemComponent>,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: Item,
    private fileService: FileService
  ) {
    this.editForm = this.fb.group({
      name: [''],
      fileId: [''],
      // TODO: other inputs for the item the file will be associated to.
    });
    if (data) {
      this.editForm.patchValue({...data});
      this.fileId = data.fileId;
      if (data.fileId) {
        this.imgUrl = this.fileService.thumbnailUrl(data.fileId, 'screenshot');
      }
    }
    this.uploadForm = this.fb.group({
      fileInput: [],
    });
  }

  ngOnInit(): void {
  }

  cancel() {
    this.dialogRef.close();
  }

  isNew() {
    return !this.data
      || (this.data.itemId.startsWith(clientGuidPrefix));
  }

  save() {
    if (!this.editForm.valid) {
      return;
    }
    const updated = {...this.data, ...this.editForm.value, fileId: this.fileId};
    this.dialogRef.close(updated);
  }

  /**
   * This function handles the upload process and stores the resulting fileId to save with the item.
   */
  fileChosen(event: any) {
    if (event.target.files && event.target.files[0]) {
      this.isUploading = true;
      const file = event.target.files[0];

      if (!this.acceptedFileTypes.includes(file.type)) {
        this.snackBar.open('Invalid file type chosen', '', { duration: 3000 });
        return;
      }

      const formData = new FormData();
      formData.append('model', file); // don't rename 'model', it must match server side route parameter
      this.fileService.upload(formData).subscribe(x => {
        this.fileId = x.fileId;
        this.imgUrl = this.fileService.thumbnailUrl(this.fileId, 'screenshot');
        this.isUploading = false;
      }, (error) => {
        console.error('Failed to upload image', error);
        this.snackBar.open('Failed to upload image', '', { duration: 3000 });
        this.isUploading = false;
      });
    }
  }

}
