import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";

type CalculatorProps = {
  left: number;
  operator: string;
  right: number;
};

//export default function Catalog({ left, operator, right }: CalculatorProps) {
export default function Catalog() {
  return (
    <TableContainer component={Paper}>
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
          <TableRow>
            <TableCell component="th" scope="row">IMG</TableCell>
            <TableCell>09/05/2021</TableCell>
            <TableCell>To the moon and back</TableCell>
            <TableCell>Nick Sailor</TableCell>
            <TableCell>$135</TableCell>
            <TableCell>Details</TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
  );
}
