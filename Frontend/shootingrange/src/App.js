import Header from './components/Header/Header';
import ShootingSpot from './components/ShootingSpot/ShootingSpot'
import Home from './components/Home/Home';
import Ammunitions from './components/Ammunitions/Ammunitons';
import Missing from './components/Missing/Missing';
import Footer from './components/Footer/Footer';
import { Route, Routes } from 'react-router-dom';
import { Container, Paper } from '@mui/material';
import Weapons from './components/Weapon/Weapons';
import Customer from './components/Customer/Customer';
import Record from './components/Record/Record';
import Employee from './components/Employee/Employee';
import Spot from './components/Spot/Spot';
import Order from './components/Order/Order';
import Assignment from './components/Assignment/Assignemnt';

function App() {

  return (
    <Container maxWidth="lg" style={{ height: '100vw' }}  >
      <Paper elevation={3}>
        <Header title="Shooting Range App" />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route forceRefresh={true} path="/ammo/*" element={<Ammunitions />} />
          <Route forceRefresh={true} path="/weapon/*" element={<Weapons />} />
          <Route forceRefresh={true} path="/customer/*" element={<Customer />} />
          <Route forceRefresh={true} path="/record/*" element={<Record />} />
          <Route forceRefresh={true} path="/employee/*" element={<Employee />} />
          <Route forceRefresh={true} path="/spot/*" element={<Spot />} />
          <Route forceRefresh={true} path="/shootingSpot/*" element={<ShootingSpot />} />
          <Route forceRefresh={true} path="/order/*" element={<Order />} />
          <Route forceRefresh={true} path="/assignment/*" element={<Assignment />} />
          <Route path="*" element={<Missing />} />
        </Routes>
        <Footer />
      </Paper>
    </Container>
  );
}

export default App;
