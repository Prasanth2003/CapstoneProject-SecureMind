import { Component } from '@angular/core';
import { catchError, map, of, switchMap } from 'rxjs';
import { HospitalService } from '../../services/hospital.service';

@Component({
  selector: 'app-hospitals-near-me',
  templateUrl: './hospitals-near-me.component.html',
  styleUrls: ['./hospitals-near-me.component.css']
})
export class HospitalsNearMeComponent {
  address: string = '';
  hospitals: any[] = [];
  errorMessage: string = '';
  isLoading: boolean = false; 

  constructor(private hospitalService: HospitalService) {}

  searchLocation() {
    this.errorMessage = '';
    this.hospitals = [];
    if (!this.address.trim()) return;

    this.isLoading = true; 
    this.hospitalService.getCoordinates(this.address)
      .pipe(
        map(response => {
          if (response.length > 0) {
            const { lat, lon } = response[0];
            return this.hospitalService.getHospitals(lat, lon);
          } else {
            throw new Error('No coordinates found.');
          }
        }),
        switchMap(hospitals => hospitals),
        catchError(error => {
          this.errorMessage = 'Error fetching hospitals.';
          this.isLoading = false; // Stop loading on error
          return of([]);
        })
      )
      .subscribe(
        (hospitals: any[]) => {
          this.hospitals = hospitals;
          this.isLoading = false; // Stop loading after receiving data
          if (this.hospitals.length === 0) {
            this.errorMessage = 'No hospitals found.';
          }
        },
        () => {
          this.errorMessage = 'Error occurred.';
          this.isLoading = false; // Stop loading on error
        }
      );
  }
}
