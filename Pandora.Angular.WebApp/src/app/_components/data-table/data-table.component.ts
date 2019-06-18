import { AfterViewInit, Component, Input } from '@angular/core';
import { DataTableDataSource } from './data-table-datasource';

@Component({
  selector: 'app-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent implements AfterViewInit {
  @Input() sourceList: any[];
  @Input() displayedColumns: string[];

  columnsToDisplay: string[];
  dataSource: any[];
  
  ngAfterViewInit() {
    this.columnsToDisplay = this.displayedColumns.slice();
    this.dataSource = this.sourceList;
  }
}
