import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button } from "@mui/material";
import api from "./../../Api/shootingSpot"
import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import SearchForm from "../SearchForm/SerachForm";


const CustomerSpot = ({ customers, setAssign, spotId }) => {
  const navigate = useNavigate();
  function refreshPage() {
    window.location.reload(false);
  }
  const handleAssign = async (customerId, spotId) => {
    try {
      await api.post(`${spotId}/customer/${customerId}`)
      navigate(`/spot/${spotId}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }


  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="left">Email</TableCell>
              <TableCell align="right">First Name</TableCell>
              <TableCell align="right">Last Name</TableCell>
              <TableCell align="right">Addres</TableCell>
              <TableCell align="right">Firearms License</TableCell>
              <TableCell align="right">Action</TableCell>
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
                <TableCell align="center"><Button variant="contained" size="small" onClick={() => handleAssign(customer.customerId, spotId)}>Assign</Button><Button variant="contained" size="small" color="error" onClick={() => setAssign(false)}>Cancel</Button></TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
}

export default CustomerSpot;
