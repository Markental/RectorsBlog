import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer-panel',
  templateUrl: './footer-panel.component.html',
  styleUrls: ['./footer-panel.component.css']
})
export class FooterPanelComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  scrollTop(){
    window.scroll(0,0);
  }

}
