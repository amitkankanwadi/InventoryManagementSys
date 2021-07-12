import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  domain: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  httpGet<T>(method: string, data: any, autoLoader: boolean = true): Observable<Object> {
    var headers = new HttpHeaders().set('Content-Type', 'application/json');
    headers = headers.set('Loader', autoLoader.toString());
    return this.http.get<T>(this.domain + method, { headers: headers, params: data });
  }

  httpPost<T>(method: string, data: any, autoLoader: boolean = true): Observable<T[]> {
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json').set('Loader', autoLoader.toString()) };
    return this.http.post<T[]>(this.domain + method, data, config);
  }
}
