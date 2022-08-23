import { Paper, TextField, Typography, Grid, Button, Container } from "@mui/material";
import { useEffect, useState } from "react";
import useStyles from '../../styles';


const NewEmployee = ({
  employeeData, setEmployeeData, handleSubmit
}) => {

  const classes = useStyles();
  const [confimrPassword, setConfimrPassword] = useState([]);
  const [alert, setAlert] = useState([false]);
  useEffect(() => {
    if (confimrPassword == employeeData.password)
      setAlert(true)
    else
      setAlert(false)
  }, [confimrPassword, employeeData.password])


  return (
    <Container maxWidth="lg">
      <Typography variant="h5">Add Employee</Typography>
      <Paper className={classes.gridForm}>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Email"
            variant="filled"
            id="Email"
            type="email"
            required
            value={employeeData.email}
            onChange={(e) => setEmployeeData({ ...employeeData, email: e.target.value })}
          />
          <TextField
            label="First Name"
            variant="filled"
            id="firstName"
            type="text"
            required
            value={employeeData.firstName}
            onChange={(e) => setEmployeeData({ ...employeeData, firstName: e.target.value })}
          />
          <TextField
            label="Last Name"
            variant="filled"
            id="lastName"
            type="text"
            required
            value={employeeData.lastName}
            onChange={(e) => setEmployeeData({ ...employeeData, lastName: e.target.value })}
          />
          <TextField
            label="Password"
            variant="filled"
            id="password"
            type="password"
            required
            minLength="5"
            value={employeeData.password}
            onChange={(e) => setEmployeeData({ ...employeeData, password: e.target.value })}
          />
          <TextField
            label="Confirm Password"
            variant="filled"
            id="confirmpassword"
            type="password"
            required
            value={confimrPassword}
            onChange={(e) => setConfimrPassword(e.target.value)}
          />
          {!alert &&
            <>
              <Typography color="red">Passwords don't match</Typography>
              <Button className={classes.buttonSubmit} variant="contained" disabled size="large" style={{ backgroundColor: "#A4AC96" }} type="submit">Submit</Button>
            </>
          }
          {alert && 
              <Button className={classes.buttonSubmit} variant="contained"  size="large" style={{ backgroundColor: "#A4AC96" }} type="submit">Submit</Button>
          }

        </form>
      </Paper>
    </Container>
  );
}

export default NewEmployee;