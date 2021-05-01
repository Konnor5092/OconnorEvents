import {
  Button,
  Grid as MuiGrid,
  styled,
  TextField,
  Typography as MuiTypography,
} from "@material-ui/core";
import { spacing } from "@material-ui/system";
import React from "react";
import DateFnsUtils from "@date-io/date-fns";
import {
  KeyboardDatePicker,
  MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import { BasketCheckoutDto } from "../types/basketCheckoutDto";
import axios from "axios";

const Grid = styled(MuiGrid)(spacing);

type CheckoutProps = {
  basketId: string;
  userId: string;
};

export default function Checkout({ basketId, userId }: CheckoutProps) {
  const [lastName, setLastName] = React.useState("");
  const [firstName, setFirstName] = React.useState("");
  const [address, setAddress] = React.useState("");
  const [city, setCity] = React.useState("");
  const [zipCode, setZipCode] = React.useState("");
  const [country, setCountry] = React.useState("");
  const [email, setEmail] = React.useState("");
  const [creditCardNumber, setCreditCardNumber] = React.useState("");
  const [creditCardName, setCreditCardName] = React.useState("");
  const [expirationDate, setExpirationDate] = React.useState("");
  const [cvvCode, setCvvCode] = React.useState(0);

  const placeOrder = async () => {
    const basketCheckout: BasketCheckoutDto = {
      userId: userId,
      basketId: basketId,
      firstName: firstName,
      lastName: lastName,
      email: email,
      address: address,
      zipCode: zipCode,
      city: city,
      country: country,
      cardNumber: creditCardNumber,
      cardName: creditCardName,
      cardExpiration: expirationDate
    };
    try {
      await axios.post(
        `https://localhost:5003/api/baskets/checkout`,
        basketCheckout
      );
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Grid container alignItems="center" mt={5} direction="column">
      <Grid item xs={4} container direction="column" spacing={3}>
        <Grid item>
          <TextField
            label="Last name"
            value={lastName}
            onChange={(event) => setLastName(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="First name"
            value={firstName}
            onChange={(event) => setFirstName(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Address"
            value={address}
            onChange={(event) => setAddress(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="City"
            value={city}
            onChange={(event) => setCity(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Zip code"
            value={zipCode}
            onChange={(event) => setZipCode(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Country"
            value={country}
            onChange={(event) => setCountry(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Email"
            value={email}
            onChange={(event) => setEmail(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Credit card name"
            value={creditCardName}
            onChange={(event) => setCreditCardName(event.target.value)}
            fullWidth
          />
        </Grid>
        <Grid item>
          <TextField
            label="Credit card number"
            value={creditCardNumber}
            onChange={(event) =>
              setCreditCardNumber(event.target.value)
            }
            fullWidth
          />
        </Grid>
        <Grid item>
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <KeyboardDatePicker
              disableToolbar
              variant="inline"
              format="dd/MM/yyyy"
              label="Expiration date"
              value={expirationDate}
              fullWidth
              onChange={(date: Date | null) => setExpirationDate(date!.toDateString())}
              KeyboardButtonProps={{
                "aria-label": "change date",
              }}
            />
          </MuiPickersUtilsProvider>
        </Grid>
        <Grid item>
          <TextField
            label="CVV code"
            value={cvvCode}
            onChange={(event) => setCvvCode(parseInt(event.target.value, 10))}
            fullWidth
          />
        </Grid>
        <Grid item>
          <Button type="submit" variant="outlined" onClick={placeOrder}>
            Place order
          </Button>
        </Grid>
      </Grid>
    </Grid>
  );
}
