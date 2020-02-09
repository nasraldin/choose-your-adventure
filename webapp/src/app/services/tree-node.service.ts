import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchModel } from '../models/search.model';
import { TreeNode } from '../models/tree-node.model';
import { environment } from './../../environments/environment';

@Injectable({ providedIn: 'root' })
export class TreeNodeService {
  private baseUrl = environment.endpoint.getByCategoryId;

  constructor(private http: HttpClient) {}

  getTreeNodes(query: SearchModel): Observable<TreeNode[]> {
    return this.http.post<TreeNode[]>(this.baseUrl, query);
  }
}
