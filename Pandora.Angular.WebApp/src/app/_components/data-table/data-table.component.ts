import { Component, Input, AfterContentInit, OnInit } from '@angular/core';
import { DataTableDataSource } from './data-table-datasource';

@Component({
  selector: 'app-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent implements OnInit, AfterContentInit {
  //@Input() sourceList: any;
  //@Input() 
  displayedColumns: string[]= ['Materia', 'Primero', 'Segundo', 'Tercero', 'Recuperatorio', 'Final'];
  
  dataSource: any;
  columnsToDisplay: string[];
  
  ngOnInit(): void {
    // this.dataSource = this.sourceList;
    // console.log('init',this.sourceList)
  }
  ngAfterContentInit() {
    // this.dataSource = this.sourceList;
    // console.log('after',this.sourceList)
  }
  
  public loadTable(data: any) {
    this.dataSource = data;
    // this.dataSource = new DataTableDataSource<any>(data);
    // this.dataSource.connect().subscribe(resul => {
    //   console.log('load', resul)      
    //   this.dataSource = resul;
    // })
  }
}
