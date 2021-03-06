import { Routes } from '@angular/router';
import { CreateComponent } from './components/create/create.component';
import { ListComponent } from './components/list/list.component';
import { UpdateComponent } from './components/update/update.component';

export const appRoutes: Routes = [
  {
    path:'',
    redirectTo:'list',
    pathMatch:'full'
  },
  { path: 'create', 
    component: CreateComponent 
  },
  {
    path: 'list',
    component: ListComponent
  },
  { 
    path: 'update/:id/:titulo',
    component: UpdateComponent
  }
];