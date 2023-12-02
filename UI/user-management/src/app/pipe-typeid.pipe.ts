import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pipeTypeid'
})
export class PipeTypeidPipe implements PipeTransform {

  transform(value: number): string {
    if(value == 0){
      return "Single Country User";
    }else if(value == 1){
      return "Multiple Countries User";
    }else if(value == 2){
      return "Admin";
    }
    return "";
  }

}
