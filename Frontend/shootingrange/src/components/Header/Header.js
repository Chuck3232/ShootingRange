import { AppBar, Typography } from "@mui/material";
import useStyles from './../../styles';

const Header = ({title}) => {
  const classes = useStyles();
    return (
      <AppBar className={classes.appBarHeader} position="static"style={{backgroundColor: "#313628"}} >
        <Typography  variant="h3" align="left">{title}</Typography>
      </AppBar>
    );
  }
  
  export default Header;
  