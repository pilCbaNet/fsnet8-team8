export class User{

    private idUsuario?: number;
    private nombreUsu: string;
    private apellidoUsu: string;
    private Dni: number;
    private FechaNacUsu: Date;
    private EmailUsu: string;
    private Contraseña: string;
    private FechaAltaUsu?: Date;
    private FechaBajaUsu?: Date;
    private IdLocalidad?: number;

    constructor(
        nombreUsu:string,
        apellidoUsu:string,
        Dni:number,
        FechaNacUsu:Date,
        EmailUsu: string,
        Contraseña: string,
        Telefono?: string,
        FechaAltaUsu?: Date,
        FechaBajaUsu?: Date,
        IdLocalidad?: number
        ){

        this.nombreUsu=nombreUsu;
        this.apellidoUsu=apellidoUsu;
        this.Dni=Dni;
        this.FechaNacUsu=FechaNacUsu;
        this.EmailUsu=EmailUsu;
        this.Contraseña=Contraseña;
        this.FechaAltaUsu=FechaAltaUsu;
        this.FechaBajaUsu=FechaBajaUsu;
        this.IdLocalidad=IdLocalidad;
    }
}