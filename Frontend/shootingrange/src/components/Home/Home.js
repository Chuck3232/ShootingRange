import { Button, TextField, Typography, Alert, Collapse, Box} from "@mui/material";
import { useState } from "react";
import axios from "axios";
import useStyles from '../../styles';
import { useCookies } from "react-cookie";
import Nav from "../Nav/Nav";
import Avatar from '@mui/material/Avatar';
import Container from '@mui/material/Container';


const Home = () => {

  const classes = useStyles();
  const [cookies, setCookie, removeCookie] = useCookies(['user'])
  const [openAlert, setOpenAlert] = useState(false);
  const [loginData, setLoginData] = useState({
    email: '',
    password: ''
  });
  function refreshPage() {
    window.location.reload(false);
  }
  const handleSubmit = async () => {
    try {
      
      const response = await axios.post('https://localhost:44312/Api/User/login', loginData)
      console.log(response)
      setCookie('jwt', response.data, { path: '/' });
      
      refreshPage()
    } catch (err) {
      console.log(`ERROR: ${err.message}`)
      setOpenAlert(true)
    }

  }
  const handleCookie = async () => {
    console.log(cookies.jwt)
  }
  const handleLogout = async () => {
    removeCookie("jwt")
    refreshPage()
  }
  return (
    <>
      {!cookies.jwt && <>
        <Container component="main" maxWidth="xs">
          <Box
            sx={{
              marginTop: 8,
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
            }}
          >
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            </Avatar>
            <Typography component="h1" variant="h5">
              Sign in
            </Typography>
            <Box onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
                autoFocus
                value={loginData.email}
                onChange={(e) => setLoginData({ ...loginData, email: e.target.value })}
              />
              <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                value={loginData.password}
                autoComplete="current-password"
                onChange={(e) => setLoginData({ ...loginData, password: e.target.value })}
              />
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                onClick={() => handleSubmit()}
              >
                Sign In
              </Button>
            </Box>
          </Box>
        </Container>
        <Box sx={{ width: '100%', height: '50px' }}>
          <Collapse in={openAlert}>
            <Alert severity="error"
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
              Wrong email or password
            </Alert>
          </Collapse>
        </Box>

        {/* <TextField
          label="Email"
          variant="filled"
          id="email"
          type="email"
          required
          value={loginData.email}
          onChange={(e) => setLoginData({ ...loginData, email: e.target.value })}
        />
        <TextField
          label="Hasło"
          variant="filled"
          id="password"
          type="password"
          required
          value={loginData.password}
          onChange={(e) => setLoginData({ ...loginData, password: e.target.value })}
        />
        <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit" onClick={() => handleSubmit()} >Submit</Button> */}

      </>}
      {cookies.jwt &&
        <>
          <Nav />
          <Typography variant="h3">Welcome in Shoting Range App!</Typography>
          <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit" onClick={() => handleCookie()} >cookie</Button>       
          <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit" onClick={() => handleLogout()} >logout</Button>
        </>
      }
    </>
  );
}

export default Home;
