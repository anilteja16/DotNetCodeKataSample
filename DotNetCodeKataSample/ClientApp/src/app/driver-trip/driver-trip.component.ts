import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-driver-trip',
  templateUrl: './driver-trip.component.html'
})
export class DriverTripComponent {
  fileContent: string = '';

  public onChange(fileList: FileList): void {
    let file = fileList[0];
    let fileReader: FileReader = new FileReader();
    let self = this;
    fileReader.onloadend = function (x) {
      self.fileContent = fileReader.result as string;
    }
    fileReader.readAsText(file);
  }

  public drivers: Driver[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  public onProcessClick() {
    const body = { inputStreamData: this.fileContent };
    this.http.post<Driver[]>(this.baseUrl + 'drivertrip', body).subscribe(result => {
      this.drivers = result;
    }, error => console.error(error));
  }
}

interface Driver {
  name: string;
  miles: number;
  avgSpeed: number;
}
