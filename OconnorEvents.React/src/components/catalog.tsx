import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import { EventList } from "../types/eventList";
import axios from "axios";
import { Button, Grid } from "@material-ui/core";
import moment from "moment";
import { Link, useRouteMatch } from "react-router-dom";

const useStyles = makeStyles({
  thumbnails: {
    width: 175,
    height: 100,
  },
});

export default function Catalog() {
  const classes = useStyles();
  const [eventList, setEventList] = React.useState<EventList[]>([]);
  let { path } = useRouteMatch();

  React.useEffect(() => {
    axios
      .get("https://localhost:5001/api/events", { responseType: "json" })
      .then((response) => {
        setEventList(response.data.items);
      })
      .catch((error) => console.log(error));
  }, []);

  return (
    <Grid container justify="center">
      <Grid item xs={8}>
        <TableContainer>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell></TableCell>
                <TableCell>Date</TableCell>
                <TableCell>Name</TableCell>
                <TableCell>Artist</TableCell>
                <TableCell>Price</TableCell>
                <TableCell></TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {eventList &&
                eventList.map((event: EventList) => (
                  <TableRow key={event.eventId}>
                    <TableCell component="th" scope="row">
                      <img
                        src={event.imageUrl}
                        className={classes.thumbnails}
                      />
                    </TableCell>
                    <TableCell>
                      {moment(event.date).format("DD/MM/YYYY")}
                    </TableCell>
                    <TableCell>{event.name}</TableCell>
                    <TableCell>{event.artist}</TableCell>
                    <TableCell>{event.price}</TableCell>
                    <TableCell>
                      <Button variant="contained" color="primary">
                        <Link to={`${path}/Detail?eventId=${event.eventId}`}>
                          Details
                        </Link>
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </Grid>
  );
}
