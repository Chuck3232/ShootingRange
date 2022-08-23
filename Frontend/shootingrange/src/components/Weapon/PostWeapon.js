import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography, MenuItem } from "@mui/material";
import { useParams, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from '../../styles';


const PostWeapon = (weapons) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const weapon = weapons.weapons.find(ammo => (ammo.id).toString() === id);
  const [form, setForm] = useState(false)
  const [weaponData, setWeaponData] = useState({
    name: '',
    caliber: '',
    type: '',
    dateOfProduction: '',
    price: '',
    inStock: ''
  });
  useEffect(() => {
    if (weapon) setWeaponData(weapon);
  }, [weapon]);

  function refreshPage() {
    window.location.reload(false);
  }
  const handleEdit = async (id) => {

    const editWeapon = weaponData
    try {
      const response = await axios.put(`https://localhost:44312/Api/Weapon/${editWeapon.id}`, editWeapon)
      setWeaponData({
        name: '',
        caliber: '',
        type: '',
        dateOfProduction: '',
        price: '',
        inStock: ''
      });
      navigate(`/weapon/${id}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }

  const handleResetNumberOfUse = async (id) => {
    try {
      const response = await axios.put(`https://localhost:44312/Api/Weapon/reset/${id}`)
      navigate(`/weapon/${id}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err}`)
    }
  }

  return (
    <div className="Weapon">
      {!form && weapon &&
        <>
          <Typography align="center" variant="h5">weapon Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell align="left">Name</TableCell>
                  <TableCell align="right">Type</TableCell>
                  <TableCell align="right">Caliber</TableCell>
                  <TableCell align="right">Number of use</TableCell>
                  <TableCell align="right">Date of Production</TableCell>
                  <TableCell align="right">Price</TableCell>
                  <TableCell align="right">In Stock</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={weapon.id}>
                  <TableCell component="th" scope="row">{weapon.name}</TableCell>
                  <TableCell align="right">{weapon.type}</TableCell>
                  <TableCell align="right">{weapon.caliber}</TableCell>
                  <TableCell align="right">{weapon.numberOfUse}</TableCell>
                  <TableCell align="right">{weapon.dateOfProduction}</TableCell>
                  <TableCell align="right">{weapon.price}</TableCell>
                  <TableCell align="right">{weapon.inStock===true &&  <Typography color="green">YES</Typography>}{weapon.inStock===false &&  <Typography color="red">NO</Typography>}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            <Button style={{ backgroundColor: "#A4AC96" }} onClick={() => setForm(true)}>Edit</Button>
            <Button onClick={() => handleResetNumberOfUse(weapon.id)}>Reset number of use</Button>
          </ButtonGroup>
        </>
      }
      {form &&
        <Container maxWidth="lg">
          <Typography variant="h5">Edit Ammunition</Typography>
          <Paper className={classes.gridForm}>
            <form onSubmit={handleEdit}>
              <TextField
                label="Name"
                variant="filled"
                id="name"
                type="text"
                required
                value={weaponData.name}
                onChange={(e) => setWeaponData({ ...weaponData, name: e.target.value })}
              />
              <TextField
                label="Type"
                variant="filled"
                id="type"
                type="text"
                required
                value={weaponData.type}
                onChange={(e) => setWeaponData({ ...weaponData, type: e.target.value })}
              />
              <TextField
                label="Caliber"
                variant="filled"
                id="caliber"
                type="text"
                required
                value={weaponData.caliber}
                onChange={(e) => setWeaponData({ ...weaponData, caliber: e.target.value })}
              />
              <TextField
                label="Date of Production"
                variant="filled"
                id="dateOfProduction"
                type="number"
                required
                value={weaponData.dateOfProduction}
                onChange={(e) => setWeaponData({ ...weaponData, dateOfProduction: e.target.value })}
              />
              <TextField
                label="Price"
                variant="filled"
                id="price"
                type="number"
                required
                value={weaponData.price}
                onChange={(e) => setWeaponData({ ...weaponData, price: e.target.value })}
              />
              <TextField
                label="In stock"
                variant="filled"
                id="inStock"
                select
                required
                helperText="Please select"
                value={weaponData.inStock ? weaponData.inStock : " "}
                onChange={(e) => setWeaponData({ ...weaponData, inStock: e.target.value })}
              >
                <MenuItem value='true'>
                  YES
                </MenuItem>
                <MenuItem value='false'>
                  NO
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

export default PostWeapon;
