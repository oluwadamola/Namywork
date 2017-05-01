module Stev.Services.Domain {

    export class User {
        private http: HttpService;      // Custom HTTP Service that understands Operation
        private Q: angular.IQService;
        private $http: angular.IHttpService; // Angular's HTTP Service
        private file: FileService;
        private storage: StorageService;

        constructor($q, $http, _http, _file, _storage) {
            this.http = _http;
            this.$http = $http;
            this.Q = $q;
            this.file = _file;
            this.storage = _storage;
        }


        createUser(model: UserModel) {
            return this.http.post<UserModel>('/api/users', model);
        }

        updateUser(model: UserModel) {
            return this.http.put<UserModel>('/api/users/' + model.UserId, model);
        }

        signIn(email: string, password: string) {
            var deferred = this.Q.defer<UserModel>();

            var data = "grant_type=password&username=" + email + "&password=" + password;
            var postCredentials = this.$http.post<Token>('/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });

            var signIn = postCredentials
                .then(response => {
                    var token = response.data;
                    this.storage.Token = token;
                    return token
                })
                .then(t => {
                    return this.http.get<UserModel>(`/api/users/${t.UserId}`);
                }) //Also Fetch User Information
                .then(u => {
                    this.storage.User = u;
                    deferred.resolve(u);
                });

            signIn.catch(err => deferred.reject(err.data.error_description));

            return deferred.promise;
        }

        getUser(userId: number) {
            return this.http.get<UserModel>('/api/users/' + userId);
        }

        getUsers() {
            return this.http.get<UserModel[]>("/api/users/GetUsers");
        }

        addUser(user: UserModel) {
            return this.http.post<number>("/api/users/user", user);
        }

        getRole(role: string): RoleModel {
            switch (role) {
                case Constants.Roles.SystemAdministrator:
                    return { RoleId: 1, RoleName: Constants.Roles.SystemAdministrator, Title: "System Administrator", Url: "/systemadmin" };
                case Constants.Roles.User:
                    return { RoleId: 2, RoleName: Constants.Roles.User, Title: "User", Url: "/user" };
            }
        }

        isInRole(role: string) {
            var roles = this.storage.User.Roles.map(r => r.RoleName.toLowerCase());
            var isInRole = roles.indexOf(role.toLowerCase()) >= 0;
            return isInRole;
        }

        recover(email: string) {
            return this.http.put<void>(`/api/users/recover/?email=${email}`);
        }

        changePassword(userID: number, password: string, newPassword: string) {
            return this.http.put<void>(`/api/users/${userID}/password`, {
                Password: password,
                NewPassword: newPassword
            });
        }

        /* getRoles(userID: number) {
             return this.http.get<RoleModel[]>(`/api/users/${userID}/roles`);
         }*/

        getUserRoles(userId: number) {
            return this.http.get<RoleModel[]>(`/api/users/${userId}/roles`);
        }

        getAllRoles() {
            return Object.keys(Constants.Roles).map(k => this.getRole(Constants.Roles[k]));
        }

        assignRole(userID: number, role: string) {
            return this.http.put<UserModel>(`/api/users/${userID}/roles`, {
                Role: role
            });
        }

        removeRole(user: UserModel, role: RoleModel) {
            return this.http.delete(`/api/users/${user.UserId}/roles?role=${role.RoleName}`);
        }

        uploadImage(file: File) {

            var defer = this.Q.defer<string>();

            var userId = this.storage.User.UserId;
            var uploadFile = this.file.post<Operation<string>>(`/api/users/${userId}/image`, file);

            uploadFile.then(r => defer.resolve(r.Result));
            uploadFile.catch(r => defer.reject(r));

            return defer.promise;
        }

        getUsersInGroup(groupId: number) {
            return this.http.get<UserModel[]>(`/api/groups/${groupId}/users`);
        }

        getUsersInGroup1(groupId: number) {
            debugger;
            var list: IList<UserModel> = {
                Count: () => this.http.get<number>(`/api/groups/${groupId}/users/count`),
                Slice: (offset, limit) => this.http.get<UserModel[]>(`/api/groups/${groupId}/users?offset=` + offset + "&limit=" + limit)
            }
            return list;
        }

        assignUserToGroup(groupId: number, User: UserModel) {

            return this.http.post<UserModel[]>(`/api/groups/${groupId}/users/${User.UserId}`);
        }

        getUserInGroup(groupId: number, userId: number) {
            return this.http.get<UserModel>(`/api/groups/${groupId}/users/${userId}`);
        }
    }
    export class Service {
        private http: HttpService;      // Custom HTTP Service that understands Operation
        private Q: angular.IQService;
        private $http: angular.IHttpService; // Angular's HTTP Service
        private file: FileService;
        private storage: StorageService;

        constructor($q, $http, _http, _file, _storage) {
            this.http = _http;
            this.$http = $http;
            this.Q = $q;
            this.file = _file;
            this.storage = _storage;
        }

        CreateService(model: ServiceModel) {
            return this.http.post<ServiceModel>('api/services', model);
        }

        GetServices() {
            return this.http.get<ServiceModel[]>('api/services');
        }

        getCategories() {
            return this.http.get<CategoryModel[]>('api/services/categories');
        }
        getCities() {
            return this.http.get<CityModel[]>('api/services/cities');
        }
        getServiceByCity(cityId: number) {
            return this.http.get<ServiceModel[]>(`api/services/cities/${cityId}`, cityId);
        }
        getServiceByCat(categoryId: number) {
            return this.http.get <ServiceModel[]>(`api/services/category/${categoryId}`, categoryId);
        }
        getService(serviceId: number) {
            return this.http.get<ServiceModel>(`api/services/${serviceId}`);
        }
        addService(model: ServiceModel) {
            return this.http.post<UserModel>('/api/services', model);
        }
    }
    module.service("_user", User);
    module.service("_service", Service);
  
}