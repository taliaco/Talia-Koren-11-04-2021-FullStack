import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MainComponent } from './components/main/main.component';
import { FavoritesComponent } from './components/favorites/favorites.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MainService } from './services/main.service';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    FavoritesComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'app' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' },
      { path: 'main', component: MainComponent },
      { path: 'favorites', component: FavoritesComponent },
    ])
  ],
  providers: [MainService],
  bootstrap: [AppComponent]
})
export class AppModule { }
