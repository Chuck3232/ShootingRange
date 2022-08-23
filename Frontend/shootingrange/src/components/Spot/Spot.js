import NewSpot from './NewSpot';
import PostSpot from './PostSpot';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import SpotHome from './SpotHome';
import api from '../../Api/spot';
import axios from 'axios';
import { Grid } from '@mui/material';


const Spots = () => {
    const [spots, setspots] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [distance, setDistanceData] = useState('');
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

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newSpot = { distance }
        console.log(newSpot)
        try {
            await axios.post('https://localhost:44312/Api/ShootingSpot', newSpot)
            setDistanceData({
                distance: '',
            });
            navigate('/spot');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    }



    return (

        <Grid className="Spots">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Spots" addTarget="newSpot" addTargetName="Add spot" />
            <Routes>
                <Route index element={<SpotHome spots={searchResults} />} />
                <Route path="newSpot" element={<NewSpot
                    handleSubmit={handleSubmit}
                    spotData={distance}
                    setSpotData={setDistanceData}
                />} />
                <Route path=":id/*" element={<PostSpot
                    spots={spots}
                />} />
            </Routes>

        </Grid>
    );
}

export default Spots;
