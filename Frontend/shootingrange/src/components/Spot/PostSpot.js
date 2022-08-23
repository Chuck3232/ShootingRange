import {
  Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography
} from "@mui/material";
import { useParams, useNavigate, Routes, Route } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from '../../styles';
import CustomerSpot from "./CustomerSpot";
import SearchForm from "../SearchForm/SerachForm";


const PostSpot = (spots) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const spot = spots.spots.find(spot => (spot.id).toString() === id);
  const [form, setForm] = useState(false)
  const [assign, setAssign] = useState(false)
  const [search, setSearch] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [spotData, setSpotData] = useState({
    distance: '',
  });
  const [customers, setCustomers] = useState([]);
  useEffect(() => {
    if (spot) setSpotData(spot);
  }, [spot]);

  function refreshPage() {
    window.location.reload(false);
  }

  const handleEdit = async (id) => {

    const editSpot = spotData
    try {
      await axios.put(`https://localhost:44312/Api/Spot/${editSpot.id}`, editSpot)
      setSpotData({
        name: '',
        caliber: '',
        type: '',
        dateOfProduction: '',
        price: '',
      });
      navigate(`/spot/${id}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }
  useEffect(() => {
    const fetchCustomers = async () => {
      try {
        const response = await axios.get('https://localhost:44312/Api/Customer');
        setCustomers(response.data);
      } catch (err) {
        if (err.response) {
          console.log(err.response.data.message);
          console.log(err.response.status)
        }
        else {
          console.log(`ERROR: ${err.message}`)
        }
      }
    }

    fetchCustomers();
  }, [])

  useEffect(() => {
    const filterResoult = customers.filter(customer =>
      ((customer.firstName).toLowerCase()).includes(search.toLowerCase())
    );

    setSearchResults(filterResoult.reverse());
  }, [customers, search])

  const handleDelete = async (id) => {
    try {
      await axios.delete(`https://localhost:44312/Api/Spot/${id}`)
      navigate(`/spot`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }
  const handleNavigation = (target) => {
    navigate(target)
  }
  

  return (
    <div className="Spots">
      {!form && spot &&
        <>
          <Typography align="center" variant="h5">Spot Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell align="left">Distance</TableCell>
                  <TableCell align="right">Customer</TableCell>
                  <TableCell align="right">Ammunition</TableCell>
                  <TableCell align="right">Instructor</TableCell>
                  <TableCell align="right">Weapon</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={spot.id}>
                  <TableCell component="th" scope="row">{spot.distance}</TableCell>
                  <TableCell align="right">{!spot.customer && <Typography color="red">Empty</Typography>}{spot.customer && spot.customer.lastName}</TableCell>
                  <TableCell align="right">{spot.ammoOrder && "yes"}{!spot.ammoOrder && <Typography color="red">No</Typography>}</TableCell>
                  <TableCell align="right">{!spot.instructor && <Typography color="red">No</Typography>}{spot.instructor && spot.instructor.lastName}</TableCell>
                  <TableCell align="right">{!spot.weapon && <Typography color="red">No or own</Typography>}{spot.weapon && spot.weapon.name}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            <Button style={{ backgroundColor: "#A4AC96" }} onClick={() => setForm(true)}>Edit</Button>
            <Button color="error" onClick={() => handleDelete(spots.id)}>Delete</Button>
            {!spot.customer && <Button onClick={() => setAssign(true)}>Assign Customer</Button>}
            {spot.customer && <Button onClick={() => handleNavigation(`/customer/${spot.customer.id}`)}>To customer</Button>}
            {!spot.instructor && <Button disabled>Instructor</Button>}
            {spot.instructor && <Button onClick={() => handleNavigation(`/employee/${spot.instructor.id}`)}>to instructor</Button>}
            {!spot.weapon && <Button disabled>Weapon</Button>}
            {spot.weapon && <Button onClick={() => handleNavigation(`/weapon/${spot.weapon.id}`)}>to weapon</Button>}
          </ButtonGroup>
          {assign &&
            <>
              <SearchForm search={search} setSearch={setSearch} title="Customers" addTarget='' addTargetName='' />
              <CustomerSpot customers={searchResults} assign={assign} setAssign={setAssign} spotId={spot.id} />
            </>
          }
        </>
      }
      {form &&
        <Container maxWidth="lg">
          <Typography variant="h5">Edit spot</Typography>
          <Paper className={classes.gridForm}>
            <form onSubmit={handleEdit}>
              <TextField
                label="Distance"
                variant="filled"
                id="distance"
                type="text"
                required
                value={spotData.distance}
                onChange={(e) => setSpotData({ ...spotData, distance: e.target.value })}
              />
              <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit" onClick={() => handleEdit()}>Submit</Button>
              <Button className={classes.buttonSubmit} variant="contained" size="large" color="error" onClick={() => setForm(false)}>Cancel</Button>
            </form>
          </Paper>
        </Container>
      }
    </div>
  );
}

export default PostSpot;
