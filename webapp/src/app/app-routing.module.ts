import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { DecisionTreeComponent } from './components/decisionTree/index/index.component';
import { DecisionWizardComponent } from './components/decisionTree/decision-wizard/decision-wizard.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  { path: '', component: DecisionTreeComponent },
  { path: 'choose-adventure', component: DecisionWizardComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules,
      useHash: false
    })
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {}
