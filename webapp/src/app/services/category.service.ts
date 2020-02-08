import { Category } from './../models/category.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private baseUrl = environment.endpoint.category;

  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl);
  }
}
