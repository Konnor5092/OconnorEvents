import Catalog from "./catalog";
import Header from "./header";
import Details from "./details";
import { Grid } from "@material-ui/core";
import { Route, Switch, useLocation } from "react-router-dom";

export default function HomePage() {
  const location = useLocation();

  return (
    <Grid container direction="column" spacing={2}>
      <Header />
      <Grid item container justify="center">
        <Grid item>{location.pathname === "/EventCatalog" && <Catalog />}</Grid>
      </Grid>
      <Switch>
        <Route path="/EventCatalog/Detail">
          <Details />
        </Route>
      </Switch>
    </Grid>
  );
}
