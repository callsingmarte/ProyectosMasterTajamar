import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, InjectionToken } from "@angular/core";
import { Product } from "./product.model";
import { Observable, catchError } from "rxjs";

export const REST_URL = new InjectionToken("rest_url");

@Injectable({
  providedIn: 'root'
})
export class RestDataSource {
  constructor(private http: HttpClient, @Inject(REST_URL) private url: string) { }

  getData(): Observable<Product[]> {
    //return this.http.get<Product[]>(this.url);
    return this.sendRequest<Product[]>("GET", this.url);
  }

  saveProduct(product: Product): Observable<Product> {
    //return this.http.post<Product>(this.url, product);
    return this.sendRequest<Product>("POST", this.url, product);
  }

  updateProduct(product: Product): Observable<Product> {
    //return this.http.put<Product>(`${this.url}/${product.id}`, product);
    return this.sendRequest<Product>("PUT",`${this.url}/${product.id}`, product);
  }

  deleteProduct(id: number): Observable<Product> {
    //return this.http.delete<Product>(`${this.url}/${id}`);
    return this.sendRequest<Product>("DELETE",`${this.url}/${id}`);
  }

  private sendRequest<T>(verb: string, url: string, body?: Product): Observable<T> {
    let myHeaders = new HttpHeaders();
    myHeaders = myHeaders.set("Access.key", "<secret>");
    myHeaders = myHeaders.set("Application-name", ["exampleApp", "proAngular"]);

    return this.http.request<T>(verb, url, {
      body: body,
      headers: myHeaders
    }).pipe(catchError((error: Response) => {
      throw (`Network Error: ${error.statusText} (${error.status})`)
    }));
    //Esta es otra forma de declararlo dentro de la clave headers
    //new HttpHeaders({
    //  "Access-Key": "<secret>",
    //  "Application-Name": "exampleApp"
    //})
  }

}
