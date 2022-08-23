import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography } from "@mui/material";
import { useEffect } from "react";

const AmmoInSpot = (ammo) => {

    useEffect(() => {
      console.log(ammo)
    }, [])
    

  return (
    <div className="Ammo">
      { ammo &&
        <>
          <Typography align="center" variant="h5">Ammunition Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Caliber</TableCell>
                  <TableCell align="right">Type</TableCell>
                  <TableCell align="right">Producer</TableCell>
                  <TableCell align="right">Quantity</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={ammo.id}>
                  <TableCell component="th" scope="row">{ammo.ammo.ammunition.caliber}</TableCell>
                  <TableCell align="right">{ammo.ammo.ammunition.type}</TableCell>
                  <TableCell align="right">{ammo.ammo.ammunition.producer}</TableCell>
                  <TableCell align="right">{ammo.ammo.quantity}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
        </>
      }
    </div>
  );
}

export default AmmoInSpot;
