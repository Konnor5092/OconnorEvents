import HomePage from "./components/homePage";
import { Redirect, Route, Switch } from "react-router-dom";

function App() {
  return (
    <Switch>
      <Route path="/">
        <HomePage />
      </Route>
    </Switch>
  );
}

export default App;
