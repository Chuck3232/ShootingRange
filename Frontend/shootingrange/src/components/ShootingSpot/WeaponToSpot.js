import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Alert, Collapse, Box } from "@mui/material";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import api from "../../Api/weapon"
import assignment from "../../Api/assignment";
import SearchForm from "../SearchForm/SerachForm";
import { height } from "@mui/system";
const WeaponToSpot = ({customerId}) => {

  const [weapons, setWeapons] = useState([]);
  const [search, setSearch] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [openAlert, setOpenAlert] = useState(false);
  useEffect(() => {
    const fetchWeapons = async () => {
      try {
        const response = await api.get('/customer');
        setWeapons(response.data);
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

    fetchWeapons();
  }, [])

  const handleChoose = async (weaponId) => {
     try {
       const response = await assignment.post(`/weapon/${weaponId}/${customerId}`);
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
  


useEffect(() => {
  const filterResoult = weapons.filter(weapon =>
    ((weapon.name).toLowerCase()).includes(search.toLowerCase())
    || ((weapon.caliber).toLowerCase()).includes(search.toLowerCase())
    || ((weapon.type).toLowerCase()).includes(search.toLowerCase()));

  setSearchResults(filterResoult.reverse());
}, [weapons, search])

return (
  <>
    <SearchForm search={search} setSearch={setSearch} title="Weapons" addTarget='' addTargetName="Add weapon" />
    <Box sx={{ width: '100%', height: '50px'}}>
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
            <TableCell align="left">Name</TableCell>
            <TableCell align="right">Type</TableCell>
            <TableCell align="right">Caliber</TableCell>
            <TableCell align="right">Date of Production</TableCell>
            <TableCell align="right">Price</TableCell>
            <TableCell align="right">Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {searchResults?.map(weapon => (
            <TableRow key={weapon.id}>
              <TableCell component="th" scope="row">{weapon.name}</TableCell>
              <TableCell align="right">{weapon.type}</TableCell>
              <TableCell align="right">{weapon.caliber}</TableCell>
              <TableCell align="right">{weapon.dateOfProduction}</TableCell>
              <TableCell align="right">{weapon.price}</TableCell>
              <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }} onClick={() => {handleChoose(weapon.id);  setOpenAlert(true)}}>Choose</Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
}
  </>
);
}

export default WeaponToSpot;