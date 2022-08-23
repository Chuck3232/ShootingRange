import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography } from "@mui/material";
import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import useStyles from '../../styles';
import api from '../../Api/record';
  
const PostCustomer = (customers) => {

  const classes = useStyles();
  const navigate = useNavigate();
  const { id } = useParams();
  const customer =  customers.customers.find(customer => (customer.customerId).toString() === id);
  const [form, setForm] = useState(false)
  const [customerData, setCustomerData] = useState({
    FirstName: '',
    LastName:  '',
    Email: '',
    City :  '',
    Street:  '',
    buldingNumber:  '',
    firearmsLicense:  ''});
    useEffect(() => {
      if (customer) setCustomerData(customer);
    }, [customer]);

    function refreshPage() {
      window.location.reload(false);
    }
    const handleEdit = async(id) => {
      
       const editCustomer =  customerData
       try{
           await axios.put(`https://localhost:44312/Api/Customer/${id}`,editCustomer)
           setCustomerData({
            FirstName: '',
            LastName:  '',
            Email: '',
            City :  '',
            Street:  '',
            buldingNumber:  '',
            firearmsLicense:  ''});  
           navigate(`/customer/${id}`);
           refreshPage()
       } catch(err){
           console.log(`ERROR: ${err.message}`) 
       }       
  }
  const handleDelete = async(id) => {
    try{
        await axios.delete(`https://localhost:44312/Api/Customer/${id}`)  
        navigate(`/customer`);
        refreshPage()
    } catch(err){
        console.log(`ERROR: ${err.message}`) 
    }       
  }
  const handleAdd = async(id) => {
 
    try{
        await api.post(`${id}`)              
        navigate('/record');
        refreshPage()
    } catch(err){
        console.log(`ERROR: ${err.message}`) 
    }    
  }
     
    return (      
        <div className="Customer">
          {!form && customer &&
            <>
             <Typography align="center" variant="h5">Customer Details</Typography>  
              <TableContainer component={Paper}>
                <Table aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell align="left">Email</TableCell>
                    <TableCell align="right">First Name</TableCell>
                    <TableCell align="right">Last Name</TableCell>
                    <TableCell align="right">Addres</TableCell>
                    <TableCell align="right">Firearms License</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>       
                  <TableRow key={customer.customerId}>
                    <TableCell component="th" scope="row">{customer.email}</TableCell>
                    <TableCell align="right">{customer.firstName}</TableCell>
                    <TableCell align="right">{customer.lastName}</TableCell>               
                    <TableCell align="right">{customer.city} {customer.street} {customer.buldingNumber}</TableCell>
                    <TableCell align="right">{customer.firearmsLicense}</TableCell>
                  </TableRow>                
                </TableBody>
                </Table>
              </TableContainer>
                <ButtonGroup className={classes.buttonSubmit} variant="contained"  size="large" aria-label="outlined primary button group" style={{color: "#A4AC96"}}>
                  <Button color="primary"  onClick={() =>handleAdd(customer.customerId)}>Add Entry Record</Button>
                  <Button style={{backgroundColor: "#A4AC96"}} onClick={() =>setForm(true)}>Edit</Button>
                  <Button color="error"  onClick={() =>handleDelete(customer.customerId)}>Delete</Button>
                </ButtonGroup>               
            </>
          }
          {form &&
            <Container maxWidth="lg">
            <Typography variant="h5">Edit Ammunition</Typography>  
              <Paper className={classes.gridForm}>
              <form onSubmit={handleEdit}>           
              <TextField
                  label="First Name"
                  variant="filled" 
                  id="FirstName"
                  type="text"
                  required
                  value={customerData.firstName}
                  onChange={(e) => setCustomerData({ ...customerData, firstName: e.target.value })} 
                />      
                <TextField
                  label="Last Name"
                  variant="filled"
                  id="LastName"
                  type="text"
                  required
                  value={customerData.lastName}
                  onChange={(e) => setCustomerData({ ...customerData, lastName: e.target.value })} 
                />            
                <TextField
                  label="Email"
                  variant="filled"
                  id="Email"
                  type="text"
                  required
                  value={customerData.email}
                  onChange={(e) => setCustomerData({ ...customerData, email: e.target.value })} 
                />           
                <TextField
                  label="City"
                  variant="filled"
                  id="City"
                  type="text"
                  required
                  value={customerData.city}
                  onChange={(e) => setCustomerData({ ...customerData, city: e.target.value })} 
                />         
                <TextField
                  label="Street"
                  variant="filled"
                  id="Street"
                  type="text"
                  required
                  value={customerData.street}
                  onChange={(e) => setCustomerData({ ...customerData, street: e.target.value })} 
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
                  <Button className={classes.buttonSubmit} variant="contained"  size="large" style={{backgroundColor: "#A4AC96"}} type="submit" onClick={() =>handleEdit(customerData.customerId)}>Submit</Button>
                  <Button className={classes.buttonSubmit} variant="contained"  size="large" color="error" onClick={() =>setForm(false)}>Cancel</Button>         
              </form>         
          </Paper>
        </Container>
        }
        </div>
    );
  }
  
  export default PostCustomer;
  