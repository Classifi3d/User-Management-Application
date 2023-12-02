import { Component, Input } from '@angular/core';
import { User } from '../user.model';

@Component({
  selector: 'app-dropdown-user',
  templateUrl: './dropdown-user.component.html',
  styleUrls: ['./dropdown-user.component.scss']
})
export class DropdownUserComponent {
  @Input() user?: User;
}
