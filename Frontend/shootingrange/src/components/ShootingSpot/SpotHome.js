import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import Nav from "../Nav/Nav";
import axios from "axios";
import api from '../../Api/shootingSpot'
import { useCookies } from 'react-cookie';
const ShootingSpotHome = ({ spots }) => {

  const [cookies, setCookie] = useCookies(['user'])
  function refreshPage() {
    window.location.reload(false);
  }

  const handleEnd = async (id) => {
    try {
      await api.put(`${id}`)

    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
    refreshPage()
    setCookie('AcceptedStatue', "No", { path: '/' });
    
  }

  return (
    <>
      <Nav />
      <TableContainer component={Paper}>
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="left">Distance</TableCell>
              <TableCell align="right">Customer</TableCell>
              <TableCell align="right">Ammunition</TableCell>
              <TableCell align="right">Instructor</TableCell>
              <TableCell align="right">Weapon</TableCell>
              <TableCell align="center">Action</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {spots?.map(spot => (
              <TableRow key={spot.id}>
                <TableCell component="th" scope="row">{spot.distance}</TableCell>
                <TableCell align="right">{!spot.customer && <Typography color="red">Empty</Typography>}{spot.customer && spot.customer.lastName}</TableCell>
                <TableCell align="right">{spot.ammoOrder && "yes"}{!spot.ammoOrder && <Typography color="red">No</Typography>}</TableCell>
                <TableCell align="right">{!spot.instructor && <Typography color="red">No</Typography>}{spot.instructor && spot.instructor.lastName}</TableCell>
                <TableCell align="right">{!spot.weapon && <Typography color="red">No or own</Typography>}{spot.weapon && spot.weapon.name}</TableCell>
                <TableCell align="center">
                  <Button variant="contained" size="small" ><Link to={`/shootingSpot/${spot.id}`}>OPEN FOR CUSTOMER</Link></Button>
                  {spot.customer && <Button variant="contained" size="small" onClick={() => handleEnd(spot.id)}>END Shooting</Button>}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
}

export default ShootingSpotHome;
