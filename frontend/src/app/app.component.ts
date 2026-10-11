import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Order & Shipping Management Hub';
  status = 'Develop Core: Drone Delivery Pilot Active';
  orderCount = 9999;
}