import { Link } from "react-router-dom";
import { AppBar, Button, Toolbar, ButtonGroup } from "@mui/material";
import useStyles from './../../styles';
const Nav = () => {
  const classes = useStyles();
  return (
    <AppBar position="static" color="primary" style={{ backgroundColor: "#595358" }}>
      <Toolbar>
        <ButtonGroup className={classes.ButtonGroup} variant="text" aria-label="text button group" size="large" color="warning">
          <Button><Link to="/">Home</Link></Button>
          <Button><Link to="/ammo">Ammunitions</Link></Button>
          <Button><Link to="/weapon">Weapons</Link></Button>
          <Button><Link to="/customer">Customers</Link></Button>
          <Button><Link to="/record">Records</Link></Button>
          <Button><Link to="/employee">Employees</Link></Button>
          <Button><Link to="/spot">Spots</Link></Button>
          <Button><Link to="/order">Orders</Link></Button>
          <Button><Link to="/assignment">Assignemnt</Link></Button>
          <Button><Link to="/shootingSpot">Spots Display</Link></Button>
        </ButtonGroup>
      </Toolbar>
    </AppBar>
  )
}

export default Nav;
