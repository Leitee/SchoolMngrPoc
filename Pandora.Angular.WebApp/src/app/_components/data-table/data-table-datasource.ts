import { DataSource } from '@angular/cdk/collections';
import { Observable, of as observableOf } from 'rxjs';

/**
 * Data source for the DataTable view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class DataTableDataSource<TDataTableItem> extends DataSource<TDataTableItem> {

  constructor(private dataSource: TDataTableItem[]) {
    super();
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<TDataTableItem[]> {
    // Combine everything that affects the rendered data into one update
    // stream for the data-table to consume.
    return observableOf(this.dataSource);
    //return merge(...dataMutations).pipe(map(() => { return [...this.data] }));
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() { }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
