import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class MakeService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get("/api/makes", {responseType: 'json'})
      .pipe(
        tap( // Log the result or error
          data => console.log(data),
          error => console.log(error)
        )
      );

    // return this.http.jsonp("/api/makes", 'callback').pipe(
    //    // then handle the error
    //   );

    // return this.http.get("/api/makes")
    //   .pipe(map(res => res.jsonp()));
  }
}
