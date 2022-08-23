import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, Typography, } from "@mui/material";
import { useParams, useNavigate, Link } from "react-router-dom";
import { useEffect, useState } from "react";
import useStyles from '../../styles';
import order from "../../Api/order";

const PostOrder = (orders) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const order = orders.orders.find(order => (order.orderId).toString() === id);
  const [showWeapon, setShowWeapon] = useState(false)
  const [showAmmo, setShowAmmo] = useState(false)
  const handleNavigation = (target) => {
    navigate(target)
  }
  useEffect(() => {
    console.log(order)
  }, [])

  return (
    <div className="Orders">
      {order &&
        <>
          <Typography align="center" variant="h5">Order Details</Typography>
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
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={order.orderId}>
                  <TableCell component="th" scope="row">{order.spotDistance}</TableCell>
                  <TableCell align="right">{order.lastName}</TableCell>
                  <TableCell align="right">{order.weapons.length}</TableCell>
                  <TableCell align="right">{order.ammoOrders.length}</TableCell>
                  <TableCell align="right">{order.isInstructor && <Typography color="green">Yes</Typography>}{!order.isInstructor && <Typography color="red">No</Typography>}</TableCell>
                  <TableCell align="right">{order.trainigHours}</TableCell>
                  <TableCell align="right">{order.price.toFixed(2)} zł</TableCell>
                  <TableCell align="right">{order.status}</TableCell>
                  </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            <Button onClick={() => handleNavigation(`/customer/${order.customer.id}`)}>To customer</Button>
            <Button onClick={() => setShowWeapon(true)}>Show weapon</Button>
            <Button onClick={() => setShowAmmo(true)}>Show ammunitions</Button>
          </ButtonGroup>
          {showWeapon &&
            <>
            <Typography align="center" variant="h5">Weapons Details</Typography>
              <TableContainer component={Paper}>
                <Table aria-label="simple table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="left">Name</TableCell>
                      <TableCell align="right">Type</TableCell>
                      <TableCell align="right">Caliber</TableCell>
                      <TableCell align="right">Date of Production</TableCell>
                      <TableCell align="right">Price</TableCell>
                      <TableCell align="center">Action</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {order.weapons?.map(weapon => (
                      <TableRow key={weapon.weaponId}>
                        <TableCell component="th" scope="row">{weapon.name}</TableCell>
                        <TableCell align="right">{weapon.type}</TableCell>
                        <TableCell align="right">{weapon.caliber}</TableCell>
                        <TableCell align="right">{weapon.dateOfProduction}</TableCell>
                        <TableCell align="right">{weapon.price.toFixed(2)}zł</TableCell>
                        <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/weapon/${weapon.weaponId}`}>Details</Link></Button></TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </>
          }
          {showAmmo &&
            <>
            <Typography align="center" variant="h5">Ammunitions Details</Typography>
              <TableContainer component={Paper}>
                <Table aria-label="simple table">
                  <TableHead>
                    <TableRow>
                      <TableCell>Caliber</TableCell>
                      <TableCell align="right">Type</TableCell>
                      <TableCell align="right">Producer</TableCell>
                      <TableCell align="right">Price</TableCell>
                      <TableCell align="right">Quantity</TableCell>
                      <TableCell align="right">Sum</TableCell>
                      <TableCell align="center">Action</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {order.ammoOrders?.map(ammo => (
                      <TableRow key={ammo.ammunitionId}>
                        <TableCell component="th" scope="row">{ammo.caliber}</TableCell>
                        <TableCell align="right">{ammo.type}</TableCell>
                        <TableCell align="right">{ammo.producer}</TableCell>
                        <TableCell align="right">{ammo.price}</TableCell>
                        <TableCell align="right">{ammo.quantity}</TableCell>
                        <TableCell align="right">{ammo.sum.toFixed(2)}zł</TableCell>
                        <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/ammo/${ammo.ammunitionId}`}>Details</Link></Button></TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </>
          }
        </>
      }
    </div>

  );
}

export default PostOrder;
