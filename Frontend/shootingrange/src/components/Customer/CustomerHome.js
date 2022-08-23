import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button } from "@mui/material";
import { Link } from "react-router-dom";


const CustomerHome = ({ customers }) => {

  return (
    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="left">Email</TableCell>
            <TableCell align="right">First Name</TableCell>
            <TableCell align="right">Last Name</TableCell>
            <TableCell align="right">Addres</TableCell>
            <TableCell align="right">Firearms License</TableCell>
             <TableCell align="center">Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {customers?.map(customer => (
            <TableRow key={customer.customerId}>
              <TableCell component="th" scope="row">{customer.email}</TableCell>
              <TableCell align="right">{customer.firstName}</TableCell>
              <TableCell align="right">{customer.lastName}</TableCell>
              <TableCell align="right">{customer.city} {customer.street} {customer.buldingNumber}</TableCell>
              <TableCell align="right">{customer.firearmsLicense}</TableCell>
              <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/customer/${customer.customerId}`}>Details</Link></Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default CustomerHome;
