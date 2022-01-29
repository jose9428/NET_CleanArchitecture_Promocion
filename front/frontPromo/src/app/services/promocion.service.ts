import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PromocionService {

  url = 'https://localhost:44329/api/Promocion/';

  constructor(private http: HttpClient) {

  }

  guardarGeneracionCodigo(data: any){
    const API_URL = `${this.url}create-promocion`;
    return  this.http.post(API_URL , data );
  }

  guardarCanjeCodigo(data: any){
    const API_URL = `${this.url}canje-promocion`;
    return this.http.post(API_URL , data);
  }

}
