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

const Grid = styled(MuiGrid)(spacing);
const Typography = styled(MuiTypography)(spacing);

export default function ShoppingBasket() {
  return (
    <>
      <Grid container justify="center" mt={5}>
        <Grid item xs={8}>
          <Typography variant="h4">Your shopping cart</Typography>
          <Typography variant="h5" py={2}>
            Here are the tickets for great events currently in your shopping
            cart
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
                <TableRow key={1}>
                  <TableCell component="th" scope="row">
                    To the moon and back
                  </TableCell>
                  <TableCell>09/05/2021</TableCell>
                  <TableCell>$135</TableCell>
                  <TableCell>
                    <Grid container spacing={2}>
                      <Grid item xs={4}>
                        <TextField
                          id="standard-number"
                          type="number"
                          InputLabelProps={{
                            shrink: true,
                          }}
                        />
                      </Grid>
                      <Grid item xs={8}>
                        <Button variant="outlined" color="primary">
                          Update
                        </Button>
                      </Grid>
                    </Grid>
                  </TableCell>
                  <TableCell>$135</TableCell>
                </TableRow>
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
                    <Typography variant="h5">$135</Typography>
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
    </>
  );
}
