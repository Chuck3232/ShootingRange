import NewCustomer from './NewCustomer';
import PostCustomer from './PostCustomer.js';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import CustomerHome from './CustomerHome';
import api from '../../Api/customer';
import axios from 'axios';
import { Grid } from '@mui/material';
import useStyles from '../../styles';

const Customer = () => {
    const classes = useStyles();
    const [customers, setCustomers] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [customerData, setCustomerData] = useState({
        FirstName: '',
        LastName: '',
        Email: '',
        City: '',
        Street: '',
        buldingNumber: '',
        firearmsLicense: ''
    });
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchCustomers = async () => {
            try {
                const response = await api.get();
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

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newCustomer = { customerData: customerData }
        try {
            await axios.post('https://localhost:44312/Api/Customer', newCustomer.customerData,)
            setCustomerData({
                FirstName: '',
                LastName: '',
                Email: '',
                City: '',
                Street: '',
                buldingNumber: '',
                firearmsLicense: ''
            });
            navigate('/customer');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    }



    return (

        <Grid className="Customers">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Customers" addTarget="NewCustomer" addTargetName="Register" />
            <Routes>
                <Route index element={<CustomerHome customers={searchResults} />} />
                <Route path="newCustomer" element={<NewCustomer
                    handleSubmit={handleSubmit}
                    customerData={customerData}
                    setCustomerData={setCustomerData}
                />} />
                <Route path=":id" element={<PostCustomer
                    customers={customers}
                />} />
            </Routes>

        </Grid>
    );
}

export default Customer;
