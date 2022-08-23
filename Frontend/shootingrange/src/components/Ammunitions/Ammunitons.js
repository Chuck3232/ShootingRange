import NewAmmo from './NewAmmo';
import PostAmmo from './PostAmmo';
import SearchForm from '../SearchForm/SerachForm';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import AmmoHome from './AmmoHome';
import api from '../../Api/ammo';
import axios from 'axios';
import { Grid } from '@mui/material';
import useStyles from './../../styles';
import Nav from '../Nav/Nav';

const Ammunitions = () => {
    const classes = useStyles();
    const [ammos, setAmmos] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [ammoData, setAmmoData] = useState({
        caliber: '',
        type: '',
        producer: '',
        price: '',
        quantityInStock: ''
    });

    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchAmmo = async () => {
            try {
                const response = await api.get();
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

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newAmmo = { ammoData }
        try {
            await axios.post('https://localhost:44312/Api/Ammo', newAmmo.ammoData,)
            setAmmoData({
                caliber: '',
                type: '',
                producer: '',
                price: '',
                quantityInStock: ''
            });
            navigate('/ammo');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    }



    return (

        <Grid className="Ammunitions">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Ammunitions" addTarget="newammo" addTargetName="Add ammo" />
            <Routes>
                <Route index element={<AmmoHome
                    ammos={searchResults} />} />
                <Route path="new" element={<NewAmmo
                    handleSubmit={handleSubmit}
                    ammoData={ammoData}
                    setAmmoData={setAmmoData}
                />} />
                <Route path=":id" element={<PostAmmo
                    ammos={ammos}
                />} />
            </Routes>

        </Grid>
    );
}

export default Ammunitions;
