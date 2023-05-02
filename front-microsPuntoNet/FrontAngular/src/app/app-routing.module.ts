import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { ProductComponent } from './product/product.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'products', component: ProductComponent },
  { path: 'users', component: UserComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }