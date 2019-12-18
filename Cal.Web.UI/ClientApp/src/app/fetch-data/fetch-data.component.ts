import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Subscription, interval, Observable } from 'rxjs';
import { iStatusState } from './interface/iStatusState';
import { DataService } from './service/fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit, OnDestroy {


  public items: iStatusState[];
  public cardHolders: Array<iStatusState> = [];
  public cal4U: Array<iStatusState> = [];
  candeactivate: boolean;

  private getSubscription: Subscription = new Subscription();
  private updateSubscription: Subscription = new Subscription();

  constructor(private dataService: DataService) { }


  ngOnInit(): void {

    this.getSubscription = interval(500).subscribe((Thread) => {

      this.dataService.getStatus().subscribe(result => {

        this.items = result.filter((test, index, array) =>
          index === array.findIndex(((findTest: { id: string; }) => {
            return findTest.id === test.id;
          }) as any
          ));

        this.cardHolders = this.items
          .filter(status => 
            status.state.systemCode === 1);
        this.cal4U = this.items
          .filter(status => 
            status.state.systemCode === 2);
      }, error => console.error(error));
    });
  }


  setState(item: iStatusState): void {
    item.state.isSorryOn = !item.state.isSorryOn;
    this.updateSubscription = this.dataService.setState(item).subscribe();
  }


  ngOnDestroy(): void {
    this.getSubscription.unsubscribe();
    this.updateSubscription.unsubscribe();
  }
}
