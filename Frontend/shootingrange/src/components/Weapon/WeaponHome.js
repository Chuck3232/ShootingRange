import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const WeaponHome = ({  weapons }) => {
    return (
     

      <TableContainer component={Paper}>
        <Table aria-label="simple table">
        <TableHead>
          <TableRow>     
            <TableCell align="left">Name</TableCell>
            <TableCell align="right">Type</TableCell>
            <TableCell align="right">Caliber</TableCell>
            <TableCell align="right">Number of use</TableCell>
            <TableCell align="right">Date of Production</TableCell>
            <TableCell align="right">Price</TableCell>
            <TableCell align="right">In Stock</TableCell>
            <TableCell align="center">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          { weapons?.map(weapon => (
              <TableRow key={weapon.id}>
                <TableCell component="th" scope="row">{weapon.name}</TableCell>
                <TableCell align="right">{weapon.type}</TableCell>
                <TableCell align="right">{weapon.caliber}</TableCell>
                <TableCell align="right">{weapon.numberOfUse}</TableCell>
                <TableCell align="right">{weapon.dateOfProduction}</TableCell>
                <TableCell align="right">{weapon.price}</TableCell>
                <TableCell align="right">{weapon.inStock===true &&  <Typography color="green">YES</Typography>}{weapon.inStock===false &&  <Typography color="red">NO</Typography>}</TableCell>
                <TableCell align="center"><Button variant="contained"  size="small" style={{backgroundColor: "#A4AC96"}}><Link to={`/weapon/${weapon.id}`}>Details</Link></Button></TableCell>
              </TableRow>
          ))}                     
        </TableBody>
        </Table>
      </TableContainer>
    );
  }
  
  export default WeaponHome;
  