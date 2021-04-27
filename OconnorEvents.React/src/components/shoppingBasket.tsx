import { Link } from "react-router-dom";
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
  TextField,
  Typography as MuiTypography,
} from "@material-ui/core";
import { spacing } from "@material-ui/system";
import React from "react";
import { BasketLineView } from "../types/basketLineView";
import { BasketLineForUpdateDto } from "../types/basketLineForUpdateDto";
import axios from "axios";
import moment from "moment";

const Grid = styled(MuiGrid)(spacing);
const Typography = styled(MuiTypography)(spacing);

type BasketLineQuantity = {
  basketLineId: string;
  quantity: number;
};

type ShoppingBasketProps = {
  basketId: string;
};

export default function ShoppingBasket({ basketId }: ShoppingBasketProps) {
  const [basketLines, setBasketLines] = React.useState<BasketLineView[]>([]);
  const [basketLineQuantities, setBasketLineQuantities] = React.useState<
    BasketLineQuantity[]
  >([]);
  const [total, setTotal] = React.useState(0);

  const getBasketLines = async () => {
    try {
      const response = await axios.get(
        `https://localhost:5003/api/baskets/${basketId}/basketlines`
      );
      setBasketLines(response.data);
      setBasketLineQuantities(
        response.data.map((basketLine: BasketLineView) => {
          const basketLineQuantity: BasketLineQuantity = {
            basketLineId: basketLine.id,
            quantity: basketLine.quantity,
          };
          return basketLineQuantity;
        })
      );
    } catch (error) {
      console.log(error);
    }
  };

  const getTotal = async () => {
    try {
      const response = await axios.get(
        `https://localhost:5003/api/baskets/${basketId}/basketlines/total`
      );
      setTotal(response.data);
    } catch (error) {
      console.log(error);
    }
  };

  const updateBasketLine = async (basketLineId: string, quantity: number) => {
    const basketLine: BasketLineForUpdateDto = {
      basketLineId: basketLineId,
      quantity: quantity,
    };
    try {
      await axios.post(
        `https://localhost:5003/api/baskets/${basketId}/basketlines/updateBasketLineQuantity`,
        basketLine
      );
      getBasketLines();
      getTotal();
    } catch (error) {
      console.log(error);
    }
  };

  const handleChangeQuantity = (
    event: React.ChangeEvent<HTMLInputElement>,
    basketLineId: string
  ) => {
    setBasketLineQuantities((basketLineQuantities) => {
      return basketLineQuantities.map(
        (basketLineQuantity: BasketLineQuantity) => {
          if (basketLineQuantity.basketLineId === basketLineId) {
            basketLineQuantity!.quantity = parseInt(event.target.value, 10);
          }
          return basketLineQuantity;
        }
      );
    });
  };

  React.useEffect(() => {
    getBasketLines();
    getTotal();
  }, []);

  return (
    <Grid container justify="center" mt={5}>
      <Grid item xs={8}>
        <Typography variant="h4">Your shopping cart</Typography>
        <Typography variant="h5" py={2}>
          Here are the tickets for great events currently in your shopping cart
        </Typography>
        <TableContainer>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>EVENT</TableCell>
                <TableCell>DATE</TableCell>
                <TableCell>PRICE PER TICKET</TableCell>
                <TableCell>QUANTITY</TableCell>
                <TableCell>TOTAL</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {basketLines &&
                basketLines.map((basketLine: BasketLineView) => (
                  <TableRow key={1}>
                    <TableCell component="th" scope="row">
                      {basketLine.eventName}
                    </TableCell>
                    <TableCell>
                      {moment(basketLine.eventDate).format("DD/MM/YYYY")}
                    </TableCell>
                    <TableCell>${basketLine.pricePerTicket}</TableCell>
                    <TableCell>
                      <Grid container spacing={2}>
                        <Grid item xs={4}>
                          <TextField
                            id="standard-number"
                            type="number"
                            InputLabelProps={{
                              shrink: true,
                            }}
                            value={
                              basketLineQuantities.find(
                                (basketLineQuantity) =>
                                  basketLineQuantity.basketLineId ===
                                  basketLine.id
                              )?.quantity
                            }
                            onChange={(
                              event: React.ChangeEvent<HTMLInputElement>
                            ) => handleChangeQuantity(event, basketLine.id)}
                          />
                        </Grid>
                        <Grid item xs={8}>
                          <Button
                            variant="outlined"
                            color="primary"
                            onClick={() =>
                              updateBasketLine(
                                basketLine.id,
                                basketLineQuantities.find(
                                  (basketLineQuantity) =>
                                    basketLineQuantity.basketLineId ===
                                    basketLine.id
                                )!.quantity
                              )
                            }
                          >
                            Update
                          </Button>
                        </Grid>
                      </Grid>
                    </TableCell>
                    <TableCell>${basketLine.total}</TableCell>
                  </TableRow>
                ))}
              <TableRow>
                <TableCell />
                <TableCell />
                <TableCell />
                <TableCell>
                  <Typography variant="h5">Discount:</Typography>
                </TableCell>
                <TableCell>
                  <Typography variant="h5">$0</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell />
                <TableCell />
                <TableCell />
                <TableCell>
                  <Typography variant="h5">Total:</Typography>
                </TableCell>
                <TableCell>
                  <Typography variant="h5">${total}</Typography>
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid item xs={8} container justify="flex-end" pt={3}>
        <Button variant="contained" color="primary">
          Check out now!
        </Button>
      </Grid>
      <Grid item xs={8} container pt={3} direction="column">
        <Grid item>
          <Typography variant="h5">Enter your discount code here!</Typography>
        </Grid>
        <Grid item container spacing={2} alignItems="flex-end">
          <Grid item>
            <TextField id="standard-basic" label="Code" />
          </Grid>
          <Grid item>
            <Button variant="outlined" color="primary">
              Apply
            </Button>
          </Grid>
        </Grid>
        <Grid item pt={2}>
          <Link to="/EventCatalog">Back to event catalog</Link>
        </Grid>
      </Grid>
    </Grid>
  );
}
