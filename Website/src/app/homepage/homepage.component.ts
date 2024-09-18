import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

 
  constructor(
    public NotificationService: NotificationService,) { 
  } 

  ngOnInit(): void {     
  }

}
