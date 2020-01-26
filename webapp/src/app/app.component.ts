import { Component, OnInit } from '@angular/core';

import { AppConfig } from './models/app-config.model';
import { AppConfigService } from './services/app-config.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  appConfig: AppConfig = new AppConfig();

  ngOnInit() {
    this.appConfig.appTitle = AppConfigService.settings.appTitle;
    this.appConfig.appLogo = AppConfigService.settings.appLogo;
  }
}
