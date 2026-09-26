import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Order & Shipping Management Hub';
  status = 'Feature 26092026: Order Module Active';
  orderCount = 112;
}