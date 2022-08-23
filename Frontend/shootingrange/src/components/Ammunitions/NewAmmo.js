import { Paper, TextField, Typography, Grid, Button, Container } from "@mui/material";
import { useParams, Link } from "react-router-dom";
import useStyles from './../../styles';


const NewAmmo = ({
  ammoData, setAmmoData, handleSubmit
}) => {
  const { } = useParams();
  const classes = useStyles();

  return (
    <Container maxWidth="lg">
      <Typography variant="h5">Add Ammo</Typography>
      <Paper className={classes.gridForm}>
        <form onSubmit={handleSubmit}>
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
          <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit">Submit</Button>
        </form>
      </Paper>
    </Container>
  );
}

export default NewAmmo;