import Catalog from "./catalog";
import Header from "./header";
import Details from "./details";
import ShoppingBasket from "./shoppingBasket";
import { Grid } from "@material-ui/core";
import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import React, { useState } from "react";

export default function HomePage() {
  const location = useLocation();
  const history = useHistory();
  const [basketId, setBasketId] = useState('');
  const [basketLines, addBasketLine] = useState(0);

  const updateBasketLines = () => addBasketLine(basketLines + 1);
  const updateBasketId = (id: string) => setBasketId(id);

  React.useEffect(() => {
    if (location.pathname === "/") {
        history.push("/EventCatalog");
    }
  }, []);

  return (
    <Grid container direction="column" spacing={2}>
      <Header tickets={basketLines} />
      <Switch>
        <Route exact path="/EventCatalog">
          <Catalog />
        </Route>
        <Route exact path="/EventCatalog/Detail">
          <Details basketId={basketId} updateBasketLines={updateBasketLines} updateBasketId={updateBasketId} />
        </Route>
        <Route exact path="/ShoppingBasket">
          <ShoppingBasket basketId={basketId}/>
        </Route>
      </Switch>
    </Grid>
  );
}
