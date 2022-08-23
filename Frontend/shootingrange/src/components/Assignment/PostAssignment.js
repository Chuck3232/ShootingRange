import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, Typography } from "@mui/material";
import { useParams, useNavigate } from "react-router-dom";
import useStyles from '../../styles';
import api from "../../Api/assignment";

const PostAssignment = (assignments) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const assignment = assignments.assignments.find(ammo => (ammo.id).toString() === id);
  const handleNavigation = (target) => {
    navigate(target)
  }
  function refreshPage() {
    window.location.reload(false);
  }
  const handleAccept = async (id) => {

    try {
      await api.put(`accept/${id}`)
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
    refreshPage()
  }
  const handleReject = async (id) => {

    try {
      await api.put(`reject/${id}`)
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
    refreshPage()
  }


  return (
    <div className="Assignment">
      {assignment &&
        <>
          <Typography align="center" variant="h5">Ammunition Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Customer</TableCell>
                  <TableCell align="right">Customer License</TableCell>
                  <TableCell align="right">Weapon</TableCell>
                  <TableCell align="right">Ammunition</TableCell>
                  <TableCell align="right">Assistance</TableCell>
                  <TableCell align="right">Status</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={assignment.id}>
                  {assignment.type.toString() === "ammo" &&
                    <>
                      <TableCell>{assignment.customerName}</TableCell>
                      <TableCell align="right">
                        {!assignment.customerLicense && <Typography color="red">No </Typography>}
                        {assignment.customerLicense && assignment.customerLicense}
                      </TableCell>
                      <TableCell align="right">
                        {!assignment.weaponInSpot && <Typography color="red">No or own</Typography>}
                        {assignment.weaponInSpot && assignment.weaponInSpot}
                      </TableCell>
                      <TableCell align="right"><Typography color="blue">{assignment.ammoInSpot}</Typography></TableCell>
                      <TableCell align="right">
                        {!assignment.instuctorInSpot && <Typography color="red">NO</Typography>}
                        {assignment.instuctorInSpot && <Typography color="green">YES</Typography>}
                      </TableCell>
                      <TableCell align="right">{assignment.status}</TableCell>
                    </>}
                  {assignment.type.toString() === "weapon" &&
                    <>
                      <TableCell>{assignment.customerName}</TableCell>
                      <TableCell align="right">
                        {!assignment.customerLicense && <Typography color="red">No </Typography>}
                        {assignment.customerLicense && assignment.customerLicense}
                      </TableCell>
                      <TableCell align="right"><Typography color="blue">{assignment.weaponInSpot}</Typography></TableCell>
                      <TableCell align="right">
                        {!assignment.ammoInSpot && <Typography color="red">NO</Typography>}
                        {assignment.ammoInSpot && assignment.ammoInSpot}
                      </TableCell>
                      <TableCell align="right">
                        {!assignment.instuctorInSpot && <Typography color="red">NO</Typography>}
                        {assignment.instuctorInSpot && <Typography color="green">YES</Typography>}
                      </TableCell>
                      <TableCell align="right">{assignment.status}</TableCell>
                    </>}
                  {assignment.type.toString() === "instructor" &&
                    <>
                      <TableCell>{assignment.customerName}</TableCell>
                      <TableCell align="right">
                        {!assignment.customerLicense && <Typography color="red">No </Typography>}
                        {assignment.customerLicense && assignment.customerLicense}
                      </TableCell>
                      <TableCell align="right">
                        {!assignment.weaponInSpot && <Typography color="red">No or own</Typography>}
                        {assignment.weaponInSpot && assignment.weaponInSpot}
                      </TableCell>
                      <TableCell align="right">
                        {!assignment.ammoInSpot && <Typography color="red">NO</Typography>}
                        {assignment.ammoInSpot && assignment.ammoInSpot}
                      </TableCell>
                      <TableCell align="right"><Typography color="blue">Requested</Typography></TableCell>
                      <TableCell align="right">{assignment.status}</TableCell>
                    </>}
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            {assignment.customerId && <Button style={{backgroundColor: "#A4AC96"}} onClick={() => handleNavigation(`/customer/${assignment.customerId}`)}>To customer</Button>}
            {!assignment.weaponInSpotId && <Button disabled>Weapon</Button>}
            {assignment.weaponInSpotId && <Button  style={{backgroundColor: "#A4AC96"}} onClick={() => handleNavigation(`/weapon/${assignment.weaponInSpotId}`)}>to weapon</Button>}
            {!assignment.ammoInSpotId && <Button disabled>Ammunition</Button>}
            {assignment.ammoInSpotId && <Button  style={{backgroundColor: "#A4AC96"}} onClick={() => handleNavigation(`/ammo/${assignment.ammoInSpotId}`)}>to ammo</Button>}
            {!assignment.orderId && <Button disabled>Order</Button>}
            {assignment.orderId && <Button  style={{backgroundColor: "#A4AC96"}} onClick={() => handleNavigation(`/order/${assignment.orderId}`)}>to order</Button>}
            {assignment.status !== "open" && <Button disabled>{assignment.status}</Button>}
            {assignment.status === "open" && <Button onClick={() => handleAccept(assignment.id)}>accept</Button>}
            {assignment.status === "open"  && <Button color="error" onClick={() => handleReject(assignment.id)}>Reject</Button>}
          </ButtonGroup>
        </>
      }
    </div>
  );
}

export default PostAssignment;
