import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Customer Loyalty & VIP Rewards Portal';
  status = 'Develop: Customer Rewards Engine Active';
  vipMemberCount = 1250;
}