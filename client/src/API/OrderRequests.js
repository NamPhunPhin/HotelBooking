import BaseUrl from "./BaseUrl";

export const AddOrder = (data) => {
    return BaseUrl.post("/api/Orders/AddOrder", data)
}

export const AddOrderDetails = (data) => {
    return BaseUrl.post("/api/OrderDetails/AddOrderDetails", data)
}

export const GetOrderByUserId = (id) => {
    return BaseUrl.get(`/api/Orders/GetOrderByUserId/${id}`);
}