import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-content-wrapper',
  templateUrl: './content-wrapper.component.html',
  styleUrls: ['./content-wrapper.component.scss']
})
export class ContentWrapperComponent implements OnInit {

  @Input() headerTitle: string;
  @Input() headerIcon: string;

  constructor() { }

  ngOnInit() {
  }

}
