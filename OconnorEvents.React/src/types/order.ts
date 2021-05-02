export type Order = {
    id: string,
    userId: string,
    orderTotal: number,
    orderPlaced: Date,
    orderPaid: boolean
}