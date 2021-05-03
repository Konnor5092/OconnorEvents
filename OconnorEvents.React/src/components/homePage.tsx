import Catalog from "./catalog";
import Header from "./header";
import Details from "./details";
import ShoppingBasket from "./shoppingBasket";
import Checkout from "./checkout";
import { Grid } from "@material-ui/core";
import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import React, { useState } from "react";
import { CheckBoxOutlineBlankOutlined, CheckBoxOutlineBlankSharp } from "@material-ui/icons";
import Orders from "./orders";
import OrderDetails from "./orderDetails";

export default function HomePage() {
  const location = useLocation();
  const history = useHistory();
  const [basketId, setBasketId] = useState('');
  const [userId, setUserId] = useState('');
  const [basketLinesCount, setBasketLinesCount] = useState(0);

  const updateBasketLines = () => setBasketLinesCount(basketLinesCount + 1);

  React.useEffect(() => {
    if (location.pathname === "/") {
        history.push("/EventCatalog");
    }
  }, []);

  return (
    <Grid container direction="column" spacing={2}>
      <Header tickets={basketLinesCount} />
      <Switch>
        <Route exact path="/EventCatalog">
          <Catalog />
        </Route>
        <Route exact path="/EventCatalog/Detail">
          <Details basketId={basketId} setUserId={setUserId} setBasketId={setBasketId} updateBasketLines={updateBasketLines}/>
        </Route>
        <Route exact path="/ShoppingBasket">
          <ShoppingBasket basketId={basketId}/>
        </Route>
        <Route exact path="/ShoppingBasket/Checkout">
          <Checkout basketId={basketId} userId={userId} setBasketLinesCount={setBasketLinesCount}/>
        </Route>
        <Route exact path="/Order">
          <Orders userId={userId}/>
        </Route>
        <Route exact path="/Order/Detail">
          <OrderDetails />
        </Route>
      </Switch>
    </Grid>
  );
}
