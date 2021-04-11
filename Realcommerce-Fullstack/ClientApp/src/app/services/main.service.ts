import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class MainService {
   
  constructor(private http: HttpClient) {

  }

  searchCities(queryParams) {
    return this.http.get('api/CityWeather/Search?query=' + queryParams);
  }
  getCurrentWeather(queryParams) {
    return this.http.get('api/CityWeather/GetCurrentWeather?query=' + queryParams);
  }
  getAllFavorites() {
    return this.http.get('api/Favorite/GetFavoriteItems');

  }
  addToFavorites(queryParams) {
    return this.http.post('api/Favorite/AddToFavorites' , queryParams);
  }
  deleteFavorite(queryParams) {
    return this.http.post('api/Favorite/DeleteFavorite' , queryParams);
  }
}
