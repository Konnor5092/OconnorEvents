import React from "react";
import logo from "./logo.svg";
import Catalog from "./components/catalog";
import Header from "./components/header";
import { Grid } from "@material-ui/core";

function App() {
  return (
    <>
      <Grid container direction="column" spacing={2}>
          <Header />
        <Grid item container justify="center">
          <Grid item>
            <Catalog />
          </Grid>
        </Grid>
      </Grid>
    </>
  );
}

export default App;
