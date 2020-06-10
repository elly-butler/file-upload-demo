import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ItemPageComponent } from './item-page/item-page.component';

const routes: Routes = [
  { path: '', component: ItemPageComponent }
  // no route needed for the item dialog.
  // TODO: other routes for a detail page, possibly?
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemRoutingModule { }
