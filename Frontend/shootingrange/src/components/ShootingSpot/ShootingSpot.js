import PostSpot from '../ShootingSpot/PostSpot';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import api from '../../Api/spot';
import axios from 'axios';
import { Grid } from '@mui/material';
import ShootingSpotHome from './SpotHome';


const ShootingSpot = ( customerId) => {
    const [spots, setspots] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchSpots = async () => {
            try {
                const response = await api.get();
                setspots(response.data);
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

        fetchSpots();
    }, [])

    useEffect(() => {
        const filterResoult = spots;

        setSearchResults(filterResoult.reverse());
    }, [spots, search])


    return (

        <Grid className="Shooting Spot">
            <Routes>
                <Route index element={<ShootingSpotHome spots={searchResults} customerId={customerId}/>} />
                <Route path=":id/*" element={<PostSpot
                    spots={spots}
                />} />
            </Routes>

        </Grid>
    );
}

export default ShootingSpot;
