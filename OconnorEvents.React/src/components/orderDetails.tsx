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
  Typography as MuiTypography,
} from "@material-ui/core";
import { spacing } from "@material-ui/system";
import moment from "moment";
import axios from "axios";
import { OrderDetailsDto } from "../types/orderDetailsDto";
import React from "react";
import { OrderLineDetailsDto } from "../types/orderLineDetailsDto";
import { useLocation } from "react-router";

const Grid = styled(MuiGrid)(spacing);
const Typography = styled(MuiTypography)(spacing);

function useQuery() {
  return new URLSearchParams(useLocation().search);
}

export default function OrderDetails() {
  const query = useQuery();
  const [orderDetails, setOrderDetails] = React.useState<
    OrderDetailsDto | undefined
  >(undefined);

  React.useEffect(() => {
    axios
      .get(`https://localhost:5005/api/order/detail/${query.get("orderId")}`, {
        responseType: "json",
      })
      .then((response) => {
        setOrderDetails(response.data);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <Grid container justify="center" mt={5}>
      <Grid item xs={8}>
        <Typography variant="h4">Your order</Typography>
        <Typography variant="h5" py={2}>
          Here are the events for your order
        </Typography>
        {orderDetails && (
          <Grid container py={2}>
            <Grid item xs={4}>
              Order Date:{" "}
              <b>{moment(orderDetails.orderPlaced).format("DD/MM/YYYY")}</b>
            </Grid>
            <Grid item xs={4}>
              Order Total: <b>${orderDetails.orderTotal}</b>
            </Grid>
            <Grid item xs={4}>
              Order Paid: <b>{orderDetails.orderPaid.toString()}</b>
            </Grid>
          </Grid>
        )}
        <TableContainer>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>EVENT NAME</TableCell>
                <TableCell>DATE</TableCell>
                <TableCell>QUANTITY</TableCell>
                <TableCell>VENUE</TableCell>
                <TableCell>CITY</TableCell>
                <TableCell>COUNTRY</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {orderDetails &&
                orderDetails.orderLines.map(
                  (orderLine: OrderLineDetailsDto) => (
                    <TableRow key={orderLine.orderLineId}>
                      <TableCell component="th" scope="row">
                        {orderLine.eventName}
                      </TableCell>
                      <TableCell>
                        {moment(orderLine.eventDate).format("DD/MM/YYYY")}
                      </TableCell>
                      <TableCell>{orderLine.ticketAmount}</TableCell>
                      <TableCell>{orderLine.venueName}</TableCell>
                      <TableCell>{orderLine.venueCity}</TableCell>
                      <TableCell>{orderLine.venueCountry}</TableCell>
                    </TableRow>
                  )
                )}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </Grid>
  );
}
