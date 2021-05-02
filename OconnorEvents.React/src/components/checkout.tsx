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
import { Alert } from "@material-ui/lab";

const Grid = styled(MuiGrid)(spacing);

type CheckoutProps = {
  basketId: string;
  userId: string;
  setBasketLinesCount: React.Dispatch<React.SetStateAction<number>>;
};

export default function Checkout({ basketId, userId, setBasketLinesCount }: CheckoutProps) {
  const [lastName, setLastName] = React.useState("OConnor");
  const [firstName, setFirstName] = React.useState("Matt");
  const [address, setAddress] = React.useState("99 Hellesdon Road");
  const [city, setCity] = React.useState("Norwich");
  const [zipCode, setZipCode] = React.useState("NR6 5EG");
  const [country, setCountry] = React.useState("England");
  const [email, setEmail] = React.useState("matty@gmail.com");
  const [creditCardNumber, setCreditCardNumber] = React.useState("ABC123");
  const [creditCardName, setCreditCardName] = React.useState("Visa");
  const [expirationDate, setExpirationDate] = React.useState("0522");
  const [cvvCode, setCvvCode] = React.useState(971);
  const [displayAlert, setDisplayAlert] = React.useState(false);

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
      setDisplayAlert(true);
      setBasketLinesCount(0);
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
        {displayAlert && (
          <Grid item> 
          <Alert
              onClose={() => {
                setDisplayAlert(false);
              }}
            >
              Order submitted!
            </Alert>
          </Grid>
          )}
      </Grid>
    </Grid>
  );
}
