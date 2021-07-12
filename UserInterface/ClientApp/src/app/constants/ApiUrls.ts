class Account {
    public static login = "api/account/Login";
    public static register = "api/account/Register";
}

class Product {
    public static add = "api/product/Add";
    public static delete = "api/product/Delete";
    public static getAll = "api/product/GetAll";
    public static update = "api/product/Update";

    public static addStock = "api/product/AddStock";
    public static deleteStock = "api/product/DeleteStock";
    public static getStock = "api/product/GetProductStock";
    public static updateStock = "api/product/UpdateStock";

    public static getReport = "api/product/GetReport";
}

export class ApiURL {
    public static Account = Account;
    public static Product = Product;
}