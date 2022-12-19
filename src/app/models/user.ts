export class User{

    private idUsuario?: number;
    private NombreUsu: string;
    private ApellidoUsu: string;
    private DniUsu: number;
    private FechaNacUsu: Date;
    private EmailUsu: string;
    private PasswordUsu: string;
    private FechaAltaUsu?: Date;
    private FechaBajaUsu?: Date;


    constructor(
        nombreUsu:string,
        apellidoUsu:string,
        Dni:number,
        FechaNacUsu:Date,
        EmailUsu: string,
        Contraseña: string,
        FechaAltaUsu?: Date,
        FechaBajaUsu?: Date,

        ){

        this.NombreUsu=nombreUsu;
        this.ApellidoUsu=apellidoUsu;
        this.DniUsu=Dni;
        this.FechaNacUsu=FechaNacUsu;
        this.EmailUsu=EmailUsu;
        this.PasswordUsu=Contraseña;
        this.FechaAltaUsu=FechaAltaUsu;
        this.FechaBajaUsu=FechaBajaUsu;

    }
}