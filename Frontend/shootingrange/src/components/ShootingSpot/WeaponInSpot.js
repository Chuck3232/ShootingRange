import { Table, TableContainer, TableHead, TableRow, TableCell, Paper, TableBody, Button, ButtonGroup, TextField, Container, Typography, MenuItem } from "@mui/material";
import { useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import useStyles from '../../styles';


const WeaponInSpot = (weapon) => {

    useEffect(() => {
      console.log(weapon)
      console.log(weapon.weapon.name)         
    }, [])
    
    return (
        <div className="Weapon">
            {weapon &&
                <>
                    <TableContainer component={Paper}>
                        <Table aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell align="left">Name</TableCell>
                                    <TableCell align="right">Type</TableCell>
                                    <TableCell align="right">Caliber</TableCell>                                   
                                    <TableCell align="right">Date of Production</TableCell>
                                    <TableCell align="right">Price</TableCell>

                                </TableRow>
                            </TableHead>
                            <TableBody>
                                <TableRow key={weapon.weapon.id}>
                                    <TableCell component="th" scope="row">{weapon.weapon.name}</TableCell>
                                    <TableCell align="right">{weapon.weapon.type}</TableCell>
                                    <TableCell align="right">{weapon.weapon.caliber}</TableCell>
                                    <TableCell align="right">{weapon.weapon.dateOfProduction}</TableCell>
                                    <TableCell align="right">{weapon.weapon.price}</TableCell>
                                    </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
                </>
            }
        </div>
    );
}

export default WeaponInSpot;
