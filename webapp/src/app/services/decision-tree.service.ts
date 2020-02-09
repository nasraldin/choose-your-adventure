import { DecisionTree } from '../models/decision-tree.model';
import { DecisionTreeFormSubmission } from './../models/decision-tree.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchModel } from '../models/search.model';
import { environment } from './../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DecisionTreeService {
  private baseUrl = environment.endpoint.decisionTree;
  private detailsUrl = environment.endpoint.decisionTreeDetails;

  constructor(private http: HttpClient) {}

  getDecisionTree(): Observable<DecisionTree[]> {
    return this.http.get<DecisionTree[]>(this.baseUrl);
  }

  getDetails(query: SearchModel): Observable<DecisionTree> {
    return this.http.post<DecisionTree>(this.detailsUrl, query);
  }

  save(submisssion: DecisionTreeFormSubmission): Observable<DecisionTreeFormSubmission> {
    return this.http.post<DecisionTreeFormSubmission>(this.baseUrl, submisssion);
  }
}
