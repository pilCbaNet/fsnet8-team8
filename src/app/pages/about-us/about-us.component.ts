// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-about-us',
//   templateUrl: './about-us.component.html',
//   styleUrls: ['./about-us.component.css']
// })
// export class AboutUsComponent implements OnInit {
//   team:any;
//   constructor() { }

//   ngOnInit(): void {

//   }

// }

import { Component, OnInit } from '@angular/core';
import { AboutUsService } from 'src/app/services/about-us.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {
  team:any;
  constructor(private miServicio: AboutUsService) { }

  ngOnInit(): void {
    this.miServicio.obtenerDatosAboutUs().subscribe(data => {
      console.log(data);
      this.team=data;
    })
  }

}

