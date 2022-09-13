import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  title: string ="Ocelot Gateway Microservices Demo";

  constructor() { }

  ngOnInit(): void {
  }

}
