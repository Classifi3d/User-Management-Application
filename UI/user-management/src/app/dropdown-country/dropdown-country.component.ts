import { Component, Input } from '@angular/core';
import { Country } from '../country.model';
@Component({
  selector: 'app-dropdown-country',
  templateUrl: './dropdown-country.component.html',
  styleUrls: ['./dropdown-country.component.scss']
})
export class DropdownCountryComponent {
  @Input() country?: Country;
}
