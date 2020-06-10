import { Component, OnInit } from '@angular/core';
import { Item } from '../item.model';
import { ItemDialogComponent } from '../item-dialog/item-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.scss']
})
export class ItemPageComponent implements OnInit {

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  editItem(item: Item) {
    const dialogRef = this.dialog.open(ItemDialogComponent, {width: '90%', maxWidth: '600px', data: item});
    dialogRef.afterClosed().subscribe(updatedContent => {
      if (updatedContent) { // not cancelled
        // TODO: call an angular service that knows how to save an 'Item'
      }
    });
  }

}
