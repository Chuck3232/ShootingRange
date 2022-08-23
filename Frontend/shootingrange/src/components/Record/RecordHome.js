import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button } from "@mui/material";
import { Link } from "react-router-dom";

const RecordHome = ({ records, handleEnd }) => {
  return (

    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="left">Date Entry</TableCell>
            <TableCell align="right">Date Exit</TableCell>
            <TableCell align="right">First Name</TableCell>
            <TableCell align="right">Last Name</TableCell>
            <TableCell align="right">Adres</TableCell>
            <TableCell align="right">FireArmsLicense</TableCell>
            <TableCell align="center">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {records?.map(record => (
            <TableRow key={record.id}>
              <TableCell component="th" scope="row">{record.dateEntry}</TableCell>
              <TableCell align="right">{record.dateExit}</TableCell>
              <TableCell align="right">{record.firstName}</TableCell>
              <TableCell align="right">{record.lastName}</TableCell>
              <TableCell align="right">{record.adress}</TableCell>
              <TableCell align="right">{record.firearmsLicense}</TableCell>
              <TableCell align="center">
                <Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }}><Link to={`/customer/${record.customerId}`}>To Customer</Link></Button>
                {record.dateExit === '0001-01-01 00:00' &&
                  <Button variant="contained" size="small" color='error' onClick={() => handleEnd(record.id)}>End</Button>
                }
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default RecordHome;
