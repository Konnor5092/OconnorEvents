import Catalog from "./catalog";
import Header from "./header";
import Details from "./details";
import ShoppingBasket from "./shoppingBasket";
import Checkout from "./checkout";
import { Grid } from "@material-ui/core";
import { Route, Switch, useHistory, useLocation } from "react-router-dom";
import React, { useState } from "react";
import { CheckBoxOutlineBlankOutlined, CheckBoxOutlineBlankSharp } from "@material-ui/icons";

export default function HomePage() {
  const location = useLocation();
  const history = useHistory();
  const [basketId, setBasketId] = useState('');
  const [userId, setUserId] = useState('');
  const [basketLines, addBasketLine] = useState(0);

  const updateBasketLines = () => addBasketLine(basketLines + 1);
  // const updateBasketId = (id: string) => setBasketId(id);

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
          <Details basketId={basketId} setUserId={setUserId} setBasketId={setBasketId} updateBasketLines={updateBasketLines}/>
        </Route>
        <Route exact path="/ShoppingBasket">
          <ShoppingBasket basketId={basketId}/>
        </Route>
        <Route exact path="/ShoppingBasket/Checkout">
          <Checkout basketId={basketId} userId={userId}/>
        </Route>
      </Switch>
    </Grid>
  );
}
