import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppConfigService } from './services/app-config.service';
import { AppErrorHandler } from './app-error.handler';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { DecisionTreeComponent } from './components/decisionTree/index/index.component';
import { DecisionWizardComponent } from './components/decisionTree/decision-wizard/decision-wizard.component';
import { FormWizardModule } from 'angular2-wizard';
import { HeaderComponent } from './components/layout/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';
import { TreeWizardComponent } from './components/decisionTree/decision-wizard/tree-wizard/tree-wizard.component';
import { ViewDecisionTreeComponent } from './components/decisionTree/view-decision-tree/view-decision-tree.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent,
    DecisionTreeComponent,
    ViewDecisionTreeComponent,
    DecisionWizardComponent,
    TreeWizardComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    FormWizardModule
  ],
  providers: [
    AppConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [AppConfigService],
      multi: true
    },
    { provide: ErrorHandler, useClass: AppErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

// The entry point of app initializations
export function initializeApp(appConfig: AppConfigService) {
  return () => appConfig.load();
}
