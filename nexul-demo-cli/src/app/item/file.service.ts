import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { memorize } from 'src/shared/utility/observable-utils';
import { FileMetadata } from './file.model';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { clientGuidPrefix } from 'src/shared/utility/type-utils';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.server + environment.apiUrl + 'file';
  }

  public getFileMetadata(fileId: string): Observable<FileMetadata> {
    if (fileId.startsWith(clientGuidPrefix)) {
      return of({fileId, size: 0, extension: '', contentType: ''});
    }
    return this.http
      .get<FileMetadata>(this.baseUrl + '/' + fileId + '/metadata')
      .pipe(memorize());
  }

  public thumbnailUrl(fileId: string, fileUse: string): string {
    if (!fileId || fileId.startsWith(clientGuidPrefix)) {
      return '/assets/placeholder-' + fileUse + '.jpg';
    }
    return '/api/file/' + fileId + '/thumbnail';
  }

  public mediumUrl(fileId: string, fileUse: string): string {
    if (!fileId || fileId.startsWith(clientGuidPrefix)) {
      return '/assets/placeholder-' + fileUse + '.jpg';
    }
    return '/api/file/' + fileId + '/medium';
  }

  public largeUrl(fileId: string, fileUse: string): string {
    if (!fileId || fileId.startsWith(clientGuidPrefix)) {
      return '/assets/placeholder-' + fileUse + '.jpg';
    }
    return '/api/file/' + fileId + '/large';
  }

  upload(file: FormData): Observable<FileMetadata> {
    return this.http.post<FileMetadata[]>(this.baseUrl + '/upload', file)
      .pipe(
        map(list => list[0]),
        memorize()
      );
  }
}
