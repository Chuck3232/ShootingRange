import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const OrderHome = ({  orders }) => {
    return (
     

      <TableContainer component={Paper}>
        <Table aria-label="simple table">
        <TableHead>
          <TableRow>     
            <TableCell align="left">Spot</TableCell>
            <TableCell align="right">Customer</TableCell>
            <TableCell align="right">Weapons</TableCell>
            <TableCell align="right">Types of ammunitions</TableCell>
            <TableCell align="right">Instructor</TableCell>
            <TableCell align="right">Hours</TableCell>
            <TableCell align="right">Price</TableCell>
            <TableCell align="right">Status</TableCell>
            <TableCell align="center">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          { orders?.map(order => (
              <TableRow key={order.orderId}>
                <TableCell component="th" scope="row">{order.spotDistance}</TableCell>
                <TableCell align="right">{order.lastName}</TableCell>
                <TableCell align="right">{order.weapons.length}</TableCell>
                <TableCell align="right">{order.ammoOrders.length}</TableCell>
                <TableCell align="right">{order.isInstructor && <Typography color="green">Yes</Typography>}{!order.isInstructor && <Typography color="red">No</Typography>}</TableCell>
                <TableCell align="right">{order.trainigHours}</TableCell>
                <TableCell align="right">{order.price.toFixed(2)} zł</TableCell>
                <TableCell align="right">{order.status}</TableCell>
                <TableCell align="center"><Button variant="contained"  size="small" style={{backgroundColor: "#A4AC96"}}><Link to={`/order/${order.orderId}`}>Details</Link></Button></TableCell>
              </TableRow>
          ))}                     
        </TableBody>
        </Table>
      </TableContainer>
    );
  }
  
  export default OrderHome;
  