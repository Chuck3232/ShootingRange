import { Button, Backdrop, Typography, Card, CardContent } from "@mui/material";
import { useParams, } from "react-router-dom";
import { useEffect, useState } from "react";
import Statute from "./Statute";
import WeaponToSpot from "./WeaponToSpot";
import AmmoToSpot from "./AmmoToSpot";
import InstrucotrToSpot from "./InstructorToSpot"
import WeaponInSpot from "./WeaponInSpot";
import AmmoInSpot from "./AmmoInSpot";
import InstructorInSpot from "./InstructorInSpot";
import { useCookies } from 'react-cookie';
import record from "../../Api/record";

const PostSpot = (spots) => {

  const { id } = useParams();
  const spot = spots.spots.find(spot => (spot.id).toString() === id);
  const [showWeapon, setShowWeapon] = useState(false)
  const [showAmmo, setShowAmmo] = useState(false)
  const [showInstructor, setShowInstructor] = useState(false)
  const [cookies, setCookie] = useCookies(['user'])
  function refreshPage() {
    window.location.reload(false);
  }
  useEffect(() => {
    if (cookies.AcceptedStatue == "Yes")
      setOpen(false)
  }, [])

  const [open, setOpen] = useState(true);
  const handleClose = async () => {
    setOpen(false);
    setCookie('AcceptedStatue', "Yes", { path: '/' });

    try {
      const response = await record.post(`${spot.customer.id}`);
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

  };

  const handleToggle = () => {
    setOpen(!open);
  };

  return (
    <div className="Orders">
      {spot && spot.customer &&
        <>
          <Typography align="center" variant="h2"> Your shooting spot is ready!</Typography>
          <Button variant="contained" onClick={handleToggle}>Show Statute</Button>
          <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
            open={open}
            onClick={handleClose}
          >
            <Statute></Statute>
          </Backdrop>
          <Card variant="outlined">
            <CardContent>
              <Typography> Distance: {spot.distance}</Typography>
              {spot.weapon &&
                <>
                  <WeaponInSpot weapon={spot.weapon} />
                  <Typography> Change weapon <Button size="Large" color="secondary" variant="contained" onClick={() => setShowWeapon(true)}>Change weapon</Button></Typography>
                </>}
              {!spot.weapon && <Typography> Order weapon <Button size="Large" color="secondary" variant="contained" onClick={() => setShowWeapon(true)}>Choose weapon</Button></Typography>}
              {spot.ammoOrder &&
                <>
                  <AmmoInSpot ammo={spot.ammoOrder} />
                  <Typography> Order ammunitions <Button size="Large" color="secondary" variant="contained" onClick={() => setShowAmmo(true)}>Choose Ammunitions</Button></Typography>
                </>
              }
              {!spot.ammoOrder && <Typography> Order ammunitions <Button size="Large" color="secondary" variant="contained" onClick={() => setShowAmmo(true)}>Choose Ammunitions</Button></Typography>}
              {spot.instructor &&
                <>
                  <InstructorInSpot instructor={spot.instructor} />
                </>
              }
              {!spot.instructor && <Typography> Order instructor <Button size="Large" color="secondary" variant="contained" onClick={() => setShowInstructor(true)}>Choose instructor</Button></Typography>}
            </CardContent>
          </Card>
          {showWeapon && <>
            <Button size="Large" color="error" variant="contained" onClick={() => setShowWeapon(false)}>Close</Button>
            <WeaponToSpot customerId={spot.customer.id} />
          </>}
          {showAmmo && <>
            <Button size="Large" color="error" variant="contained" onClick={() => setShowAmmo(false)}>Close</Button>
            {spot.weapon && <AmmoToSpot weaponCaliber={spot.weapon.caliber} customerId={spot.customer.id} />}
            {!spot.weapon && <AmmoToSpot weaponCaliber='' customerId={spot.customer.id} />}
          </>}
          {showInstructor && <>
            <Button size="Large" color="error" variant="contained" onClick={() => setShowInstructor(false)}>Close</Button>
            <InstrucotrToSpot customerId={spot.customer.id} />
          </>}
        </>
      }
      {spot && !spot.customer &&
        <Typography variant="h2"> Waiting for customer....</Typography>
      }
    </div>

  );
}

export default PostSpot;
