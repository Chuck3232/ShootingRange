import NewWeapon from './NewWeapon';
import PostWeapon from './PostWeapon';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import WeaponHome from './WeaponHome';
import api from '../../Api/weapon';
import axios from 'axios';
import { Grid } from '@mui/material';


const Weapons = () => {
    const [weapons, setWeapons] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [weaponData, setWeaponData] = useState({
        name: '',
        caliber: '',
        type: '',
        dateOfProduction: '',
        price: ''
    });
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchWeapons = async () => {
            try {
                const response = await api.get();
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

    useEffect(() => {
        const filterResoult = weapons.filter(weapon =>
            ((weapon.name).toLowerCase()).includes(search.toLowerCase())
            || ((weapon.caliber).toLowerCase()).includes(search.toLowerCase())
            || ((weapon.type).toLowerCase()).includes(search.toLowerCase()));

        setSearchResults(filterResoult.reverse());
    }, [weapons, search])

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newWeapon = { weaponData: weaponData }
        try {
            await axios.post('https://localhost:44312/Api/Weapon', newWeapon.weaponData,)
            setWeaponData({
                name: '',
                caliber: '',
                type: '',
                dateOfProduction: '',
                price: ''
            });
            navigate('/weapon');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    }



    return (

        <Grid className="Weapons">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Weapons" addTarget="newWeapon" addTargetName="Add weapon" />
            <Routes>
                <Route index element={<WeaponHome weapons={searchResults} />} />
                <Route path="newWeapon" element={<NewWeapon
                    handleSubmit={handleSubmit}
                    weaponData={weaponData}
                    setWeaponData={setWeaponData}
                />} />
                <Route path=":id" element={<PostWeapon
                    weapons={weapons}
                />} />
            </Routes>

        </Grid>
    );
}

export default Weapons;
