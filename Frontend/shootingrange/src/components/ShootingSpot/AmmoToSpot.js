import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, SimpleDialog, DialogTitle, DialogActions, DialogContent, TextField, DialogContentText, Dialog, Alert, Collapse, Box } from "@mui/material";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import api from "../../Api/ammo"
import SearchForm from "../SearchForm/SerachForm";
import assignment from "../../Api/assignment";
const AmmoToSpot = ({ weaponCaliber, customerId }) => {

  const [ammos, setAmmos] = useState([]);
  const [search, setSearch] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [open, setOpen] = useState(false);
  const [openAlert, setOpenAlert] = useState(false);
  const [ammoData, setAmmoData] = useState({
    ammoQuant: '',
  });
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  useEffect(() => {
    console.log(weaponCaliber)
    if (weaponCaliber)
      setSearch(weaponCaliber.toString())
    const fetchAmmo = async () => {
      try {
        const response = await api.get('/customer');
        setAmmos(response.data);
        console.log(response.data);
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
    fetchAmmo();
  }, [])

  useEffect(() => {
    const filterResoult = ammos.filter(ammo =>
      ((ammo.caliber).toLowerCase()).includes(search.toLowerCase())
      || ((ammo.type).toLowerCase()).includes(search.toLowerCase()));

    setSearchResults(filterResoult.reverse());
  }, [ammos, search])

  const handleChoose = async (ammoId) => {
    console.log(ammoData)
    try {
      const response = await assignment.post(`/ammo/${ammoId}/${customerId}`, ammoData);
      console.log(response);
    } catch (err) {
      if (err.response) {
        console.log(err.response.data.message);
        console.log(err.response.status)
      }
      else {
        console.log(`ERROR: ${err.message}`)
      }
    }
  };

  return (
    <>
      <SearchForm search={search} setSearch={setSearch} title="Ammunitions" addTarget='' addTargetName="Add ammo" />
      <Box sx={{ width: '100%', height: '50px' }}>
        <Collapse in={openAlert}>
          <Alert severity="info"
            action={
              <Button
                aria-label="close"
                color="inherit"
                size="small"
                onClick={() => {
                  setOpenAlert(false);
                }}
              >
              </Button>
            }
            sx={{ mb: 2 }}
          >
            Assignment was send wait for response!
          </Alert>
        </Collapse>
      </Box>
      {!openAlert &&
        <TableContainer component={Paper}>
          <Table aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Caliber</TableCell>
                <TableCell align="right">Type</TableCell>
                <TableCell align="right">Producer</TableCell>
                <TableCell align="right">Price</TableCell>
                <TableCell align="right">In Stock</TableCell>
                <TableCell align="center">Action</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {searchResults?.map(ammo => (
                <TableRow key={ammo.id}>
                  <TableCell component="th" scope="row">{ammo.caliber}</TableCell>
                  <TableCell align="right">{ammo.type}</TableCell>
                  <TableCell align="right">{ammo.producer}</TableCell>
                  <TableCell align="right">{ammo.price}</TableCell>
                  <TableCell align="right">{ammo.quantityInStock}</TableCell>
                  <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }} onClick={handleClickOpen} >Choose</Button>
                    <Dialog open={open} onClose={() => setOpen(false)}>
                      <DialogTitle>Ammunition Choose</DialogTitle>
                      <DialogContent>
                        <DialogContentText>
                          Choose quantity of selected ammunitions
                        </DialogContentText>
                        <TextField
                          autoFocus
                          margin="dense"
                          id="ammoQuant"
                          label="Quantity"
                          type="number"
                          fullWidth
                          variant="standard"
                          required
                          value={ammoData.ammoQuant}
                          onChange={(e) => setAmmoData({ ...ammoData, ammoQuant: e.target.value })}
                        />
                      </DialogContent>
                      <DialogActions>
                        <Button onClick={() => setOpen(false)}>Cancel</Button>
                        <Button onClick={() => { handleChoose(ammo.id); setOpenAlert(true); setOpen(false) }}>Accept</Button>
                      </DialogActions>
                    </Dialog>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      }
    </>
  );
}

export default AmmoToSpot;
