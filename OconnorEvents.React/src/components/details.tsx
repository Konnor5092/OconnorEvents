import React from "react";
import axios from "axios";
import { useLocation } from "react-router-dom";
import { EventDetails } from "../types/eventDetails";
import {
  Button,
  Divider,
  Grid as MuiGrid,
  makeStyles,
  styled,
  TextField,
  Typography as MuiTypography,
} from "@material-ui/core";
import moment from "moment";
import { spacing } from "@material-ui/system";

const Grid = styled(MuiGrid)(spacing);
const Typography = styled(MuiTypography)(spacing);

const useStyles = makeStyles({
  image: {
    width: 350,
    height: 200,
  },
});

function useQuery() {
  return new URLSearchParams(useLocation().search);
}

export default function Details() {
  const classes = useStyles();
  let query = useQuery();
  const [eventDetails, setEventDetails] = React.useState<EventDetails>(Object);

  React.useEffect(() => {
    axios
      .get(`https://localhost:5001/api/events/${query.get("eventId")}`, {
        responseType: "json",
      })
      .then((response) => {
        setEventDetails(response.data);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <>
      <Grid container justify="center" mt={5}>
        <Grid item xs={3}>
          <img src={eventDetails.imageUrl} className={classes.image} />
        </Grid>
        <Grid item xs={3}>
          <Typography variant="overline">
            {eventDetails.categoryName?.toUpperCase()}
          </Typography>
          <Typography variant="h3">{eventDetails.name}</Typography>
          <Typography variant="h5" pt={1}>
            {eventDetails.artist}
          </Typography>
          <Typography variant="h6" py={3}>
            {moment(eventDetails.date).format("DD/MM/YYYY")}
          </Typography>
          <Typography variant="body1">{eventDetails.description}</Typography>
          <Typography variant="h5" pt={3}>
            &#36;{eventDetails.price}
          </Typography>
        </Grid>
      </Grid>
      <Grid container justify="center" my={5}>
        <Grid item xs={6}>
          <Divider />
        </Grid>
      </Grid>
      <Grid container justify="center">
        <Grid item xs={3} />
        <Grid item xs={3}>
          <Grid container alignItems="center" spacing={3}>
            <Grid item xs={3}>
              QUANTITY:
            </Grid>
            <Grid item xs={4}>
              <TextField
                id="standard-number"
                type="number"
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>
            <Grid item xs={5}>
              <Button variant="outlined" color="primary">
                ADD TO BASKET
              </Button>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </>
  );
}
