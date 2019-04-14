export class Login {

    public mail: string;
    public password: string;



    
    constructor (name: string, mail: string, password: string ) 
       { 
        this.mail = mail;
        this.password = password;
       }
    } 
    // esta es mi estructura para llamar los datos del login y obtener el token