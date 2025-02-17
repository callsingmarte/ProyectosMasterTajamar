import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Customer {
  id: number;
  name: string;
  email: string;
  phone: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
//  public forecasts: WeatherForecast[] = [];
  public customers: Customer[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getForecasts();
    this.getCustomers();
  }

  getCustomers() {
    this.http.get<Customer[]>('/api/Customers').subscribe(
      (result) => {
        console.log(result);
        this.customers = result;
      },
      (error) => {
        console.log("hola hay un error")
        console.error(error);
      }
    )
  }

  //getForecasts() {
  //  this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
  //    (result) => {
  //      this.forecasts = result;
  //    },
  //    (error) => {
  //      console.error(error);
  //    }
  //  );
  //}

  title = 'angularapp1.client';
}
