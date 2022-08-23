import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography, MenuItem } from "@mui/material";
import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from '../../styles';


const PostEmployee = (employees) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const employee = employees.employees.find(ammo => (ammo.id).toString() === id);
  const [form, setForm] = useState(false)
  const [employeeEditData, setEmployeeEditData] = useState({
    email: '',
    firstName: '',
    lastName: '',
    roleId: ''
  });
  useEffect(() => {
    if (employee) setEmployeeEditData(employee);

  }, [employee]);
  useEffect(() => {
    console.log(employeeEditData)
  }, [employeeEditData]);

  function refreshPage() {
    window.location.reload(false);
  }
  const handleEdit = async (id) => {

    const editEmployee = employeeEditData
    try {
      await axios.put(`https://localhost:44312/Api/User/${employee.id}`, editEmployee)
      setEmployeeEditData({
        email: '',
        firstName: '',
        lastName: '',
        roleId: ''
      });
      navigate(`/employee/${id}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }
  const handleDelete = async (id) => {
    try {
      await axios.delete(`https://localhost:44312/Api/User/${id}`)
      navigate(`/employee`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }
  

  return (
    <div className="Weapon">
      {!form && employee &&
        <>
          <Typography align="center" variant="h5">Employee Details</Typography>
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
                <TableRow key={employee.id}>
                  <TableCell component="th" scope="row">{employee.lastName}</TableCell>
                  <TableCell align="right">{employee.firstName}</TableCell>
                  <TableCell align="right">{employee.email}</TableCell>
                  <TableCell align="right">{employee.role}</TableCell>
                  <TableCell align="right">{employee.status}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            <Button style={{ backgroundColor: "#A4AC96" }} onClick={() => setForm(true)}>Edit</Button>
            <Button color="error" onClick={() => handleDelete(employee.id)}>Delete</Button>
          </ButtonGroup>
        </>
      }
      {form &&
        <Container maxWidth="lg">
          <Typography variant="h5">Edit Employee</Typography>
          <Paper className={classes.gridForm}>
            <form onSubmit={handleEdit}>
              <TextField
                label="Email"
                variant="filled"
                id="Email"
                type="email"
                required
                value={employeeEditData.email}
                onChange={(e) => setEmployeeEditData({ ...employeeEditData, email: e.target.value })}
              />
              <TextField
                label="First Name"
                variant="filled"
                id="firstName"
                type="text"
                required
                value={employeeEditData.firstName}
                onChange={(e) => setEmployeeEditData({ ...employeeEditData, firstName: e.target.value })}
              />
              <TextField
                label="Last Name"
                variant="filled"
                id="lastName"
                type="text"
                required
                value={employeeEditData.lastName}
                onChange={(e) => setEmployeeEditData({ ...employeeEditData, lastName: e.target.value })}
              />
              <TextField
                label="Role"
                variant="filled"
                id="roleId"
                select
                required
                helperText="Please select role"
                value={employeeEditData.roleId ? employeeEditData.roleId : " "}
                onChange={(e) => setEmployeeEditData({ ...employeeEditData, roleId: e.target.value })}
              >
                <MenuItem  value='1'>
                  Admin
                </MenuItem>
                <MenuItem  value='2'>
                  Instructor
                </MenuItem>
                <MenuItem  value='3'>
                  Overseer
                </MenuItem>
                <MenuItem  value='4'>
                  Armourer
                </MenuItem>
                <MenuItem  value='5'>
                  Receptionist
                </MenuItem>
              </TextField>
              <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit" onClick={() => handleEdit()}>Submit</Button>
              <Button className={classes.buttonSubmit} variant="contained" size="large" color="error" onClick={() => setForm(false)}>Cancel</Button>
            </form>
          </Paper>
        </Container>
      }
    </div>
  );
}

export default PostEmployee;
