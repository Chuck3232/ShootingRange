import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography } from "@mui/material";
import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from './../../styles';


const PostAmmo = (ammos) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const ammo = ammos.ammos.find(ammo => (ammo.id).toString() === id);
  const [form, setForm] = useState(false)
  const [ammoData, setAmmoData] = useState({
    caliber: '',
    type: '',
    producer: '',
    price: '',
    quantityInStock: ''
  });
  useEffect(() => {
    if (ammo) setAmmoData(ammo);
  }, [ammo]);
  function refreshPage() {
    window.location.reload(false);
  }
  const handleEdit = async (id) => {

    const editAmmo = ammoData
    try {
      await axios.put(`https://localhost:44312/Api/Ammo/${editAmmo.id}`, editAmmo)
      setAmmoData({
        caliber: '',
        type: '',
        producer: '',
        price: '',
        quantityInStock: ''
      });
      navigate(`/ammo/${id}`);
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
    }
  }

  return (
    <div className="Ammo">
      {!form && ammo &&
        <>
          <Typography align="center" variant="h5">Ammunition Details</Typography>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Caliber</TableCell>
                  <TableCell align="right">Type</TableCell>
                  <TableCell align="right">Producer</TableCell>
                  <TableCell align="right">Price</TableCell>
                  <TableCell align="right">In Stock</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow key={ammo.id}>
                  <TableCell component="th" scope="row">{ammo.caliber}</TableCell>
                  <TableCell align="right">{ammo.type}</TableCell>
                  <TableCell align="right">{ammo.producer}</TableCell>
                  <TableCell align="right">{ammo.price}</TableCell>
                  <TableCell align="right">{ammo.quantityInStock}</TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </TableContainer>
          <ButtonGroup className={classes.buttonSubmit} variant="contained" size="large" aria-label="outlined primary button group" style={{ color: "#A4AC96" }}>
            <Button style={{ backgroundColor: "#A4AC96" }} onClick={() => setForm(true)}>Edit</Button>
          </ButtonGroup>
        </>
      }
      {form &&
        <Container maxWidth="lg">
          <Typography variant="h5">Edit Ammunition</Typography>
          <Paper className={classes.gridForm}>
            <form onSubmit={handleEdit}>
              <TextField
                label="Caliber"
                variant="filled"
                id="Caliber"
                type="text"
                required
                value={ammoData.caliber}
                onChange={(e) => setAmmoData({ ...ammoData, caliber: e.target.value })}
              />
              <TextField
                label="Type"
                variant="filled"
                id="type"
                type="text"
                required
                value={ammoData.type}
                onChange={(e) => setAmmoData({ ...ammoData, type: e.target.value })}
              />
              <TextField
                label="Producer"
                variant="filled"
                id="producer"
                type="text"
                required
                value={ammoData.producer}
                onChange={(e) => setAmmoData({ ...ammoData, producer: e.target.value })}
              />
              <TextField
                label="Price"
                variant="filled"
                id="price"
                type="number"
                required
                value={ammoData.price}
                onChange={(e) => setAmmoData({ ...ammoData, price: e.target.value })}
              />
              <TextField
                label="Quantity"
                variant="filled"
                id="quantityInStock"
                type="number"
                required
                value={ammoData.quantityInStock}
                onChange={(e) => setAmmoData({ ...ammoData, quantityInStock: e.target.value })}
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

export default PostAmmo;
