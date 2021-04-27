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
import { FormEvent } from "react";
import { FormEventHandler } from "react";

const Grid = styled(MuiGrid)(spacing);
const Typography = styled(MuiTypography)(spacing);

type CheckoutProps = {
  basketId: string;
};

export default function Checkout({ basketId }: CheckoutProps) {
  const [lastName, setLastName] = React.useState('');
  const [firstName, setFirstName] = React.useState('');
  const [address, setAddress] = React.useState('');
  const [zipCode, setZipCode] = React.useState('');
  const [country, setCountry] = React.useState('');
  const [email, setEmail] = React.useState('');
  const [creditCardNumber, setCreditCardNumber] = React.useState(0);
  const [creditCardName, setCreditCardName] = React.useState('');
  const [expirationDate, setExpirationDate] = React.useState(new Date());
  const [cvvCode, setCvvCode] = React.useState(0);

  const placeOrder = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

  }

  return (
    <Grid container justify="center" mt={5}>
      <form noValidate autoComplete="off" onSubmit={(event) => placeOrder(event)}>
        <TextField label="Last name" />
        <TextField label="First name" />
        <TextField label="Address" />
        <TextField label="Zip code" />
        <TextField label="Country" />
        <TextField label="Email" />
        <TextField label="Credit card name" />
        <TextField label="Credit card number" />
        <TextField label="Expiration date" />
        <TextField label="CVV code" />
        <Button type="submit">Place order</Button>
      </form>
    </Grid>
  );
}
