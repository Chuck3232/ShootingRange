import NewEmployee from './NewEmployee';
import PostEmployee from './PostEmployee';
import SearchForm from '../SearchForm/SerachForm';
import Nav from '../Nav/Nav';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import EmployeeHome from './EmployeeHome';
import api from './../../Api/employee';
import { Grid } from '@mui/material';


const Employees = () => {

    const [employees, setEmployees] = useState([]);
    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [employeeData, setEmployeeData] = useState({
        email: '',
        password: '',
        firstName: '',
        lastName: '',
    });
    const navigate = useNavigate();
    function refreshPage() {
        window.location.reload(false);
    }

    useEffect(() => {
        const fetchEmployees = async () => {
            try {
                const response = await api.get();
                setEmployees(response.data);
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

        fetchEmployees();
    }, [])

    useEffect(() => {
        const filterResoult = employees.filter(employee =>
            ((employee.firstName).toLowerCase()).includes(search.toLowerCase())
            || ((employee.lastName).toLowerCase()).includes(search.toLowerCase())
            || ((employee.email).toLowerCase()).includes(search.toLowerCase())
            || ((employee.status).toLowerCase()).includes(search.toLowerCase()));

        setSearchResults(filterResoult.reverse());
    }, [employees, search])

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newEmployee = { employeeData: employeeData }
        try {
            await api.post('/register', newEmployee.employeeData,)
            setEmployeeData({
                email: '',
                password: '',
                firstName: '',
                lastName: '',
            });
            navigate('/employee');
            refreshPage()
        } catch (err) {
            console.log(`ERROR: ${err.message}`)
        }
    }



    return (

        <Grid className="Employees">
            <Nav />
            <SearchForm search={search} setSearch={setSearch} title="Employees" addTarget="newEmployee" addTargetName="Register" />
            <Routes>
                <Route index element={<EmployeeHome employees={searchResults} />} />
                <Route path="newEmployee" element={<NewEmployee
                    handleSubmit={handleSubmit}
                    employeeData={employeeData}
                    setEmployeeData={setEmployeeData}
                />} />
                <Route path=":id" element={<PostEmployee
                    employees={employees}
                />} />
            </Routes>

        </Grid>
    );
}

export default Employees;
