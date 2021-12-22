import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  year = new Date();

  fecha = this.year.getFullYear();

  autor: any = 'Andres Grijalva';

  constructor() { }

  ngOnInit(): void {
  }

}
