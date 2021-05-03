import { OrderLineDetailsDto } from "./orderLineDetailsDto";

export type OrderDetailsDto = {
  orderId: string;
  orderTotal: number;
  orderPlaced: Date;
  orderPaid: boolean;
  orderLines: OrderLineDetailsDto[];
};
