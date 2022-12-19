export class Billetera {

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