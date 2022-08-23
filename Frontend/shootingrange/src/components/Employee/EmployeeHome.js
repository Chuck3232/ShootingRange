import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button } from "@mui/material";
import { Link } from "react-router-dom";

const EmployeeHome
 = ({ employees }) => {
  return (


    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="left">Last Name</TableCell>
            <TableCell align="right">First Name</TableCell>
            <TableCell align="right">Email</TableCell>
            <TableCell align="right">Role</TableCell>
            <TableCell align="right">Status</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {employees?.map(employee => (
            <TableRow key={employee.id}>
              <TableCell component="th" scope="row">{employee.lastName}</TableCell>
              <TableCell align="right">{employee.firstName}</TableCell>
              <TableCell align="right">{employee.email}</TableCell>
              <TableCell align="right">{employee.role}</TableCell>
              <TableCell align="right">{employee.status}</TableCell>
              <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/employee/${employee.id}`}>Details</Link></Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default EmployeeHome;
