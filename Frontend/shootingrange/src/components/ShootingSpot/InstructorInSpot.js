import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography, MenuItem } from "@mui/material";
import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from '../../styles';


const InstructorInSpot = (instructor) => {

  return (
    <div className="Weapon">
      { instructor &&
        <>
          <Typography align="center" variant="h5">Instructor Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell align="left">Last Name</TableCell>
                  <TableCell align="right">First Name</TableCell>
                  <TableCell align="right">Role</TableCell>
                  <TableCell align="right">Status</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={instructor.id}>
                  <TableCell component="th" scope="row">{instructor.instructor.lastName}</TableCell>
                  <TableCell align="right">{instructor.instructor.firstName}</TableCell>
                  <TableCell align="right">Instructor</TableCell>
                  <TableCell align="right">{instructor.instructor.status}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
        </>
      }

    </div>
  );
}

export default InstructorInSpot;
