import { Role2 } from "./role";

export class User2 {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    role: Role2;
    token?: string;
}