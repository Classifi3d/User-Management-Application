import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pipeInitials'
})
export class PipeInitialsPipe implements PipeTransform {

  transform(value: string): string | null{
    const myRegex = /\b\w/g;
    const matches = value.match(myRegex);
    if(matches!=null){
      return matches.join('').toLocaleUpperCase();
    }else{
      return '';
    }
  }

}
