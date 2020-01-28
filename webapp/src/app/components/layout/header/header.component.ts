import { Component, OnInit } from '@angular/core';

import { AppConfig } from 'src/app/models/app-config.model';
import { AppConfigService } from 'src/app/services/app-config.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  appConfig: AppConfig = new AppConfig();

  constructor() {}

  ngOnInit() {
    this.appConfig.appTitle = AppConfigService.settings.appTitle;
    this.appConfig.appLogo = AppConfigService.settings.appLogo;
  }
}
