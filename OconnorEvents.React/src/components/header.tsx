import { Grid, Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import ShoppingBasketIcon from "@material-ui/icons/ShoppingBasket";
import React from "react";
import { Link } from "react-router-dom";

const useStyles = makeStyles({
  header: {
    height: 200,
    backgroundColor: "black",
    color: "white",
  },
});

type HeaderProps = {
  tickets: number;
};

export default function Header({ tickets }: HeaderProps) {
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
        <Typography color="secondary">
          <Link to={`/Order`}>My Orders</Link>
        </Typography>
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
              <Link to={`/ShoppingBasket`}>
                <ShoppingBasketIcon fontSize="large" />
              </Link>
            </Grid>
            <Grid item>
              <Typography variant="body1">{tickets} tickets</Typography>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
