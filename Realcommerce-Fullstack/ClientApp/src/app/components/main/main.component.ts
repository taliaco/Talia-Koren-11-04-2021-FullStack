import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MainService } from '../../services/main.service';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss']
})
/** main component*/
export class MainComponent implements OnInit{
  public citySearchForm: FormGroup;
  public citiesList: any;
  public selectedCity: any;
  public weather: any;
    /** main ctor */
  constructor(private formBuilder: FormBuilder, private mainService: MainService) {

  }
  ngOnInit() {
    this.citySearchForm = this.formBuilder.group({
      city: ['']
    });
  }
  searchCities(formValues) {
    this.mainService.searchCities(formValues.city).subscribe(data => {
      this.citiesList = data;
    });
  }
  getCurrentWeather(city) {
    this.selectedCity = city;
    this.weather = null;
    this.mainService.getCurrentWeather(city.Key).subscribe(data => {
      this.weather = data;
      console.log(this.weather);
    });
  }
  addToFavorites() {
    this.mainService.addToFavorites(this.selectedCity).subscribe(data => {
      alert(this.selectedCity.LocalizedName + " successfully added to favorites");
    });
  }
 
}
