import HomePage from "./components/homePage";
import { Redirect, Route, Switch } from "react-router-dom";

function App() {
  return (
    <Switch>
      <Route exact path="/">
        <Redirect to="/EventCatalog" />
      </Route>
      <Route path="/EventCatalog">
        <HomePage />
      </Route>
    </Switch>
  );
}

export default App;
