import PostOrder from './PostOrder';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import OrderHome from './OrderHome';
import api from '../../Api/order';
import { Grid } from '@mui/material';


const Order = () => {
    const [orders, setOrders] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const response = await api.get();
                setOrders(response.data);
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

        fetchOrders();
    }, [])

    useEffect(() => {
        const filterResoult = orders.filter(order =>
            ((order.status).toLowerCase()).includes(search.toLowerCase())
            ||((order.lastName).toLowerCase()).includes(search.toLowerCase()));

        setSearchResults(filterResoult.reverse());
    }, [orders, search])

    return (

        <Grid>
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Orders" addTarget='' addTargetName=" " />
            <Routes>
                <Route index element={<OrderHome  orders={searchResults} />} />
                <Route path=":id" element={<PostOrder
                    orders={orders}
                />} />
            </Routes>

        </Grid>
    );
}

export default Order;
