import { Paper, TextField, Typography,  Button, Container } from "@mui/material";

import useStyles from '../../styles';

  
const NewWeapon = ({
  weaponData, setWeaponData, handleSubmit
}) => {
  
  const classes = useStyles();  

    return (
      <Container maxWidth="lg">
        <Typography variant="h5">Add Weapon</Typography> 
        <Paper className={classes.gridForm}>
        <form onSubmit={handleSubmit}>           
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
                              
                <Button className={classes.buttonSubmit} variant="contained"  size="large" style={{backgroundColor: "#A4AC96"}} type="submit">Submit</Button>           
            </form>         
        </Paper>
      </Container>
    );
  }
  
  export default NewWeapon;