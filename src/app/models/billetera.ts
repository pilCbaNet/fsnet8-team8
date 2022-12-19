export class Billetera {
    //     "idBilletera": 0,
    //   "cvuBille": 0,
    //   "saldoArsBille": 0,
    //   "saldoBtcBille": 0,
    //   "estadoBille": true,
    //   "idUsuario": 0,

    private idBilletera?: number;
    private cvuBilletera?: number;
    private saldoArsBille?: number;
    private saldoBtcBille?: number;
    private estadoBille: boolean = true;
    private idUsuario?: number;


    constructor(
        cvuBilletera: number,
        saldoArsBille: number,
        saldoBtcBille?: number,
        estadoBille: boolean = true,
        idUsuario?: number
    ) {
        this.cvuBilletera=cvuBilletera,
        this.saldoArsBille=saldoArsBille,
        this.saldoBtcBille=saldoBtcBille,
        this.estadoBille=estadoBille,
        this.idUsuario=idUsuario
    }
}