import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, Alert, Collapse, Box } from "@mui/material";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import api from "../../Api/employee"
import SearchForm from "../SearchForm/SerachForm";
import assignment from "../../Api/assignment";
const EmployeeHome = ({ customerId }) => {

    const [search, setSearch] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const [employees, setEmployees] = useState([]);
    const [openAlert, setOpenAlert] = useState(false);
    useEffect(() => {
        const fetchEmployees = async () => {
            try {
                const response = await api.get('/instructors');
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

    const handleChoose = async (employeeId) => {

        try {
            const response = await assignment.post(`/instructor/${employeeId}/${customerId}`);
        } catch (err) {
            if (err.response) {
                console.log(err.response.data.message);
                console.log(err.response.status)
            }
            else {
                console.log(`ERROR: ${err.message}`)
            }
        }
    };
    return (
        <>
            <SearchForm search={search} setSearch={setSearch} title="Employees" addTarget='' addTargetName="Register" />
            <Box sx={{ width: '100%', height: '50px' }}>
                <Collapse in={openAlert}>
                    <Alert severity="info"
                        action={
                            <Button
                                aria-label="close"
                                color="inherit"
                                size="small"
                                onClick={() => {
                                    setOpenAlert(false);
                                }}
                            >
                            </Button>
                        }
                        sx={{ mb: 2 }}
                    >
                        Assignment was send wait for response!
                    </Alert>
                </Collapse>
            </Box>
            {!openAlert &&
                <TableContainer component={Paper}>
                    <Table aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell align="left">Last Name</TableCell>
                                <TableCell align="right">First Name</TableCell>
                                <TableCell align="right">Email</TableCell>
                                <TableCell align="right">Role</TableCell>
                                <TableCell align="right">Status</TableCell>
                                <TableCell align="right">Action</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {searchResults?.map(employee => (
                                <TableRow key={employee.id}>
                                    <TableCell component="th" scope="row">{employee.lastName}</TableCell>
                                    <TableCell align="right">{employee.firstName}</TableCell>
                                    <TableCell align="right">{employee.email}</TableCell>
                                    <TableCell align="right">{employee.role}</TableCell>
                                    <TableCell align="right">{employee.status}</TableCell>
                                    <TableCell align="center"><Button variant="contained" size="small" style={{ backgroundColor: "#A4AC96" }} onClick={() => { handleChoose(employee.id); setOpenAlert(true) }}>Choose</Button></TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            }
        </>
    );
}

export default EmployeeHome;
