import PostAssignment from './PostAssignment';
import SearchForm from '../SearchForm/SerachForm';
import { Route, Routes} from 'react-router-dom';
import { useState, useEffect } from 'react';
import AssignmentHome from './AssignmentHome';
import { useCookies } from "react-cookie";
import { Grid } from '@mui/material';
import Nav from '../Nav/Nav';
import assignmentApi from '../../Api/assignment';
import AuthProvider from '../../Hooks/AuthProvider';


const Assignment = () => {

    const [assignment, setAssignment] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const auth = AuthProvider()
    
    useEffect(() => {     
        const fetchAssignment = async () => {
            try {
                const response = await assignmentApi.get("", { headers: auth}  )
                setAssignment(response.data);
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
        fetchAssignment();
    }, []);

    useEffect(() => {
        const filterResoult = assignment;

        setSearchResults(filterResoult.reverse());
    }, [assignment, search])



    return (

        <Grid className="Assignment">
            <Nav/>
            <SearchForm search={search} setSearch={setSearch} title="Assignments" addTarget='' addTargetName="Add ammo" />
            <Routes>
                <Route index element={<AssignmentHome
                    assignments={searchResults} />} />
                <Route path=":id" element={<PostAssignment
                    assignments={assignment}
                />} />
            </Routes>

        </Grid>
    );
}

export default Assignment;
