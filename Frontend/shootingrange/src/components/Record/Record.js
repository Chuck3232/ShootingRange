import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import RecordHome from './RecordHome';
import api from '../../Api/record';
import { Grid } from '@mui/material';

const Records = () => {

    const [records, setRecords] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchRecords = async () => {
            try {
                const response = await api.get();
                setRecords(response.data);

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

        fetchRecords();
    }, [])

    useEffect(() => {
        const filterResoult = records.filter(record =>
            ((record.firstName).toLowerCase()).includes(search.toLowerCase())
            || ((record.dateEntry).toLowerCase()).includes(search.toLowerCase())
            || ((record.lastName).toLowerCase()).includes(search.toLowerCase()));

        setSearchResults(filterResoult.reverse());
    }, [records, search])


    const handleEnd = async (id) => {
        try {
            await api.patch(`/${id}`);
            navigate('/record');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    };


    return (

        <Grid className="Records">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Records" addTarget="/customer" addTargetName="Add record" />
            <Routes>
                <Route index element={<RecordHome records={searchResults} handleEnd={handleEnd} />} />
            </Routes>

        </Grid>
    );
}

export default Records;
