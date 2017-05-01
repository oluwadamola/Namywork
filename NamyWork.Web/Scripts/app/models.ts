interface Operation<T> {
    Message: string;
    Succeeded: boolean;
    Result: T;
}

interface Token {
    access_token: string;
    token_type: string;
    expires_in: number;

    UserId: number;
    Email: string;
    FirstName: string;
    LastName: string;
    ImageUrl: string;
    Profile: string;

    ".issued": string;
    ".expires": string;
}

interface UserModel {

    UserId: number;
    Email: string;
    Password?: string;
    Title: string;

    FirstName: string;
    LastName: string;

    ImageUrl: string;
    FullName: string;

    Roles: RoleModel[]
}

interface RoleModel {
    RoleId: number;
    RoleName: string;
    Title: string;
    Url: string;
}

interface MonthModel {
    MonthId: number;
    MonthName: string;
}

interface YearModel {
    YearId: number;
}

interface CategoryModel {
    CategoryId: number;
    CategoryName: string;
}

interface CityModel {
    CityId: number;
    CityName: string;
}

interface ServiceModel {

    ServiceId: number;
    JobTitle: string;
    Description: string;
    Instruction: string;
    BudgetFrom: number;
    BudgetTo: number;
    StartDate: Date;
    EndDate: Date;
    ImageUrl: string;
    UserId: number;
    CategoryId: number;
    CityId: number;
    User: UserModel;                           
    Categories: CategoryModel;                                                         
    Cities: CityModel;

}
