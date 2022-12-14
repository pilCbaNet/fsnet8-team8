export class User{

    // public int IdUsuario { get; set; }
    // public string? NombreUsu { get; set; }
    // public string? ApellidoUsu { get; set; }
    // public long Dni { get; set; }
    // public DateTime? FechaNacUsu { get; set; }
    // public string EmailUsu { get; set; } = null!;
    // public string Usuario { get; set; } = null!;
    // public string Contraseña { get; set; } = null!;
    // public string? Telefono { get; set; }
    // public DateTime? FechaAltaUsu { get; set; }
    // public DateTime? FechaBajaUsu { get; set; }
    // public int? IdLocalidad { get; set; }

    private nombreUsu: string;
    private apellidoUsu: string;
    private Dni: number;
    private FechaNacUsu: Date;
    private EmailUsu: string;
    private Contraseña: string;
    private Telefono?: string;
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
        this.Telefono=Telefono;
        this.FechaAltaUsu=FechaAltaUsu;
        this.FechaBajaUsu=FechaBajaUsu;
        this.IdLocalidad=IdLocalidad;
    }
}