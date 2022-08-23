import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button } from "@mui/material";
import { Link } from "react-router-dom";

const AmmoHome = ({ ammos }) => {
  

    return (
      <TableContainer component={Paper}>
        <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Caliber</TableCell>     
            <TableCell align="right">Type</TableCell>
            <TableCell align="right">Producer</TableCell>
            <TableCell align="right">Price</TableCell>
            <TableCell align="right">In Stock</TableCell>
            <TableCell align="center">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {ammos?.map(ammo => (
              <TableRow key={ammo.id}>
                <TableCell component="th" scope="row">{ammo.caliber}</TableCell>
                <TableCell align="right">{ammo.type}</TableCell>
                <TableCell align="right">{ammo.producer}</TableCell>
                <TableCell align="right">{ammo.price}</TableCell>
                <TableCell align="right">{ammo.quantityInStock}</TableCell>
                <TableCell align="center"><Button variant="contained"  size="small" style={{backgroundColor: "#A4AC96"}}><Link to={`/ammo/${ammo.id}`}>Details</Link></Button></TableCell>
              </TableRow>
          ))}                     
        </TableBody>
        </Table>
      </TableContainer>
    );
  }
  
  export default AmmoHome;
  