import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CreateMatchComponent } from './match-folder/create-match/create-match.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatchCardComponent } from './match-folder/match-card/match-card.component';
import { MatchesComponent } from './match-folder/matches/matches.component';
import { CreatePlayerComponent } from './player-folder/create-player/create-player.component';
import { MatchDetailsComponent } from './match-folder/match-details/match-details.component';
import { MatchEventCardComponent } from './match-folder/match-event-card/match-event-card.component';
import { MatchEventsComponent } from './match-folder/match-events/match-events.component';
import { MatchSquadsComponent } from './match-folder/match-squads/match-squads.component';
import { MatchStatisticsEditComponent } from './match-folder/match-statistics-edit/match-statistics-edit.component';
import { LoginComponent } from './user-folder/login/login.component';
import { RegisterComponent } from './user-folder/register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatchPlayerStatisticsEditComponent } from './match-folder/match-player-statistics-edit/match-player-statistics-edit.component';
import { MatchStatisticsComponent } from './match-folder/match-statistics/match-statistics.component';
import { MatchPlayerStatisticsComponent } from './match-folder/match-player-statistics/match-player-statistics.component';
import { AllPlayersComponent } from './player-folder/all-players/all-players.component';
import { PlayerComponent } from './player-folder/player/player.component';
import { FormsModule } from '@angular/forms';
import { TablesComponent } from './table-folder/tables/tables.component';
import { TablesEditComponent } from './table-folder/tables-edit/tables-edit.component';
import { TableRowEditComponent } from './table-folder/table-row-edit/table-row-edit.component';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { ArticleComponent } from './article-folder/article/article.component';
import { CreateArticleComponent } from './article-folder/create-article/create-article.component';
import { ArticleCardComponent } from './article-folder/article-card/article-card.component';
import { HomeComponent } from './home/home.component';
import { JwtModule } from '@auth0/angular-jwt';
import { ArticlesComponent } from './article-folder/articles/articles.component';
import { ArticleCardVerticalComponent } from './article-folder/article-card-vertical/article-card-vertical.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateMatchComponent,
    MatchCardComponent,
    MatchesComponent,
    CreatePlayerComponent,
    MatchDetailsComponent,
    MatchEventCardComponent,
    MatchEventsComponent,
    MatchSquadsComponent,
    MatchStatisticsEditComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    MatchPlayerStatisticsEditComponent,
    MatchStatisticsComponent,
    MatchPlayerStatisticsComponent,
    AllPlayersComponent,
    PlayerComponent,
    CreateArticleComponent,
    TablesComponent,
    TablesEditComponent,
    TableRowEditComponent,
    ArticleComponent,
    ArticleCardComponent,
    HomeComponent,
    ArticlesComponent,
    ArticleCardVerticalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    DragDropModule,
    FormsModule,    
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('jwt'),
        // other configuration options if needed
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
    // Other providers...
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
