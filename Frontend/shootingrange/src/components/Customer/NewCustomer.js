import { Paper, TextField, Typography, Grid, Button, Container } from "@mui/material";
import { useParams, Link } from "react-router-dom";
import useStyles from '../../styles';

  
const NewCustomer = ({
   customerData,  setCustomerData, handleSubmit
}) => {
  const { } = useParams();
  const classes = useStyles();  

    return (
      <Container maxWidth="lg">
        <Typography variant="h5">Register Customer</Typography> 
        <Paper className={classes.gridForm}>
        <form onSubmit={handleSubmit}>           
                <TextField
                  label="First Name"
                  variant="filled" 
                  id="FirstName"
                  type="text"
                  required
                  value={customerData.FirstName}
                  onChange={(e) => setCustomerData({ ...customerData, FirstName: e.target.value })} 
                />      
                <TextField
                  label="Last Name"
                  variant="filled"
                  id="LastName"
                  type="text"
                  required
                  value={customerData.LastName}
                  onChange={(e) => setCustomerData({ ...customerData, LastName: e.target.value })} 
                />            
                <TextField
                  label="Email"
                  variant="filled"
                  id="Email"
                  type="text"
                  required
                  value={customerData.Email}
                  onChange={(e) => setCustomerData({ ...customerData, Email: e.target.value })} 
                />           
                <TextField
                  label="City"
                  variant="filled"
                  id="City"
                  type="text"
                  required
                  value={customerData.City}
                  onChange={(e) => setCustomerData({ ...customerData, City: e.target.value })} 
                />         
                <TextField
                  label="Street"
                  variant="filled"
                  id="Street"
                  type="text"
                  required
                  value={customerData.Street}
                  onChange={(e) => setCustomerData({ ...customerData, Street: e.target.value })} 
                /> 
                <TextField
                  label="Bulding Number"
                  variant="filled"
                  id="buldingNumber"
                  type="text"
                  required
                  value={customerData.buldingNumber}
                  onChange={(e) => setCustomerData({ ...customerData, buldingNumber: e.target.value })} 
                /> 
                <TextField
                  label="Firearms License"
                  variant="filled"
                  id="firearmsLicense"
                  type="text"
                  value={customerData.firearmsLicense}
                  onChange={(e) => setCustomerData({ ...customerData, firearmsLicense: e.target.value })} 
                />             
                              
                <Button className={classes.buttonSubmit} variant="contained"  size="large" style={{backgroundColor: "#A4AC96"}} type="submit">Submit</Button>           
            </form>         
        </Paper>
      </Container>
    );
  }
  
  export default NewCustomer;