import { Box, Grid, Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import ShoppingBasketIcon from "@material-ui/icons/ShoppingBasket";
import React from "react";

const useStyles = makeStyles({
  header: {
    height: 200,
    backgroundColor: "black",
    color: "white",
  },
});

export default function Header() {
  const classes = useStyles();

  return (
    <Grid
      container
      className={classes.header}
      direction="column"
      alignItems="center"
      item
    >
      <Grid item xs={6} container justify="flex-end" alignItems="center">
        <Typography color="secondary">My Orders</Typography>
      </Grid>
      <Grid item xs={6} container>
        <Grid item xs={6} container justify="flex-start" alignItems="center">
          <Typography variant="h3">OconnorEvents</Typography>
        </Grid>
        <Grid item xs={6} container justify="flex-end">
          <Grid
            item
            container
            justify="flex-end"
            alignItems="center"
            spacing={2}
          >
            <Grid item>
              <ShoppingBasketIcon fontSize="large" />
            </Grid>
            <Grid item>
              <Typography variant="body1">0 tickets</Typography>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
