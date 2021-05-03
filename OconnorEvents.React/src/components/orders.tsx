import {
  Button,
  Grid as MuiGrid,
  styled,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@material-ui/core";
import { spacing } from "@material-ui/system";
import { Order } from "../types/order";
import moment from "moment";
import axios from "axios";
import React from "react";
import { Link, useRouteMatch } from "react-router-dom";

const Grid = styled(MuiGrid)(spacing);

type OrderProps = {
  userId: string;
};

export default function Orders({ userId }: OrderProps) {
  const [orders, setOrders] = React.useState<Order[]>([]);
  const { path } = useRouteMatch();

  React.useEffect(() => {
    axios
      .get(`https://localhost:5005/api/order/user/${userId}`, {
        responseType: "json",
      })
      .then((response) => {
        setOrders(response.data.items);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <Grid container alignItems="center" mt={5} direction="column">
      <Grid item xs={6} container direction="column" spacing={3}>
        <TableContainer>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>ID</TableCell>
                <TableCell>DATE</TableCell>
                <TableCell>TOTAL</TableCell>
                <TableCell>PAID</TableCell>
                <TableCell></TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {orders &&
                orders.map((order: Order) => (
                  <TableRow key={order.id}>
                    <TableCell component="th" scope="row">
                      {order.id}
                    </TableCell>
                    <TableCell>
                      {moment(order.orderPlaced).format("DD/MM/YYYY")}
                    </TableCell>
                    <TableCell>{order.orderTotal}</TableCell>
                    <TableCell>{order.orderPaid.toString()}</TableCell>
                    <TableCell>
                      <Button variant="outlined" color="primary">
                      <Link to={`${path}/Detail?orderId=${order.id}`} style={{ textDecoration: 'none' }}>
                          Details
                        </Link>
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </Grid>
  );
}
