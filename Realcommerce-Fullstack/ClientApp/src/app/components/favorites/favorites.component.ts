import { Component, AfterViewInit } from '@angular/core';
import { MainService } from '../../services/main.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.scss']
})
/** favorites component*/
export class FavoritesComponent implements AfterViewInit {
  /** favorites ctor */
  public favoriteList: any;
  public weather: any;
  public selectedCity: any;
  constructor(private mainService: MainService) {

  }
  ngAfterViewInit() {
    this.mainService.getAllFavorites().subscribe(data => {
      this.favoriteList = data;
    });
  }
  getCurrentWeather(city) {
    this.selectedCity = city;
    this.weather = null;
    this.mainService.getCurrentWeather(city.key).subscribe(data => {
      this.weather = data;
      console.log(this.weather);
    });
  }
  deleteFavorite(city) {
    this.mainService.deleteFavorite(city).subscribe(res => {
      alert(city.localizedName + " successfully removed from favorites");
      this.weather = null;

      this.mainService.getAllFavorites().subscribe(data => {
        this.favoriteList = data;
      });
    });
  }
}
