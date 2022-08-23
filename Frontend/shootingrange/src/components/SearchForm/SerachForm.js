import { Box, Button, Typography, TextField, Grid, AppBar } from "@mui/material";
import { useEffect } from "react";
import { Link } from "react-router-dom";
import useStyles from './../../styles';

const SearchForm = ({ search, setSearch, title, addTarget, addTargetName } ) => {
    const classes = useStyles();
    return (
       
        <AppBar className={classes.appBarSearchForm} position="static" style={{backgroundColor: "#857F74"}}>
            
            <form onSubmit={(e)=> e.preventDefault()}>
                <Box sx={{ flexGrow: 1 }}>
                    <Grid container spacing={2}>
                        <Grid item xs={3}>
                            <Typography align='center' variant="h4">{title}</Typography>
                        </Grid>
                        <Grid item xs={2}>
                            <TextField className={classes.textFieldSearchForm} 
                            id="search"
                            label="Serach"
                            type="text"
                            variant="standard"
                            value={search}
                            onChange={(e) => setSearch(e.target.value)}               
                            />
                        </Grid>
                        <Grid item xs={2}>
                            {!addTarget==='' && 
                            <Link to={addTarget}><Button variant="contained"  size="large" style={{backgroundColor: "#A4AC96"}} >{addTargetName}</Button></Link>} 
                            {addTarget && 
                            <Link to={addTarget}><Button variant="contained"  size="large" style={{backgroundColor: "#A4AC96"}} >{addTargetName}</Button></Link>}
                        </Grid>                                              
                    </Grid>
                </Box>
                </form>
            </AppBar>
        
    );
  }
  
  export default SearchForm;
  