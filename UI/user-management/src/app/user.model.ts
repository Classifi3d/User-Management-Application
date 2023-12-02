import { Country } from "./country.model";

export class User{
    public id: string;
    public email: string;
    public password: string;
    public first_Name: string;
    public last_Name: string;
    public type_id: number;
    public countries: Country[];

    constructor(){
        this.id = "";
        this.email = "";
        this.password = "";
        this.first_Name = "";
        this.last_Name = "";
        this.type_id = 0;
        this.countries = [];
    }
}