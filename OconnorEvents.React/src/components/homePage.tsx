import Catalog from "./catalog";
import Header from "./header";
import Details from "./details";
import ShoppingBasket from "./shoppingBasket";
import { Grid } from "@material-ui/core";
import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import React from "react";

export default function HomePage() {
  const location = useLocation();
  const history = useHistory();

  React.useEffect(() => {
    if (location.pathname === "/") {
        history.push("/EventCatalog");
    }
  }, []);

  return (
    <Grid container direction="column" spacing={2}>
      <Header />
      <Switch>
        <Route exact path="/EventCatalog">
          <Catalog />
        </Route>
        <Route exact path="/EventCatalog/Detail">
          <Details />
        </Route>
        <Route exact path="/ShoppingBasket">
          <ShoppingBasket />
        </Route>
      </Switch>
    </Grid>
  );
}
