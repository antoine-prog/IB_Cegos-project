export class Resultat{

    private _resultat : number;
    private _total : number;
  
    constructor(total : number, resultat  : number){
      this._resultat  = resultat ;
      this._total = total;
    }

    set resultat(resultat :number){
      this._resultat=resultat;
    }

    get resultat () : number {
      return this._resultat ;
    }
  
    get total() : number {
      return this._total;
    }
  
    set total(total : number){
      this._total = total;
    }
  }