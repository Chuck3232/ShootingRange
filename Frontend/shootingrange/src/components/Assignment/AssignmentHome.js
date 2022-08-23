import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const AssignmentHome = ({ assignments }) => {


  return (
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
            <TableCell align="center">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {assignments?.map(assignment => (
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
              <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/assignment/${assignment.id}`}>Details</Link></Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default AssignmentHome;
