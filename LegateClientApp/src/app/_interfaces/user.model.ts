export interface User{
    
    id: number;
    name: string;
    joiningDate:Date;
    address: string;
}
export interface Users{
    users: User[];
}