export interface Item {
  // some item your app edits and needs to associate files to.
  itemId: string; // a GUID
  name: string;
  fileId: string; // a GUID
}
