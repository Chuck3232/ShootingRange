import { Paper, TextField, Typography, Button, Container } from "@mui/material";

import useStyles from '../../styles';


const NewSpot = ({
  spotData, setSpotData, handleSubmit
}) => {
  const classes = useStyles();

  return (
    <Container maxWidth="lg">
      <Typography variant="h5">Add Spot</Typography>
      <Paper className={classes.gridForm}>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Distance"
            variant="filled"
            id="distance"
            type="number"
            required
            value={spotData}
            onChange={(e) => setSpotData(e.target.value)}
          />
          <Button className={classes.buttonSubmit} variant="contained" size="large" style={{ backgroundColor: "#A4AC96" }} type="submit">Submit</Button>
        </form>
      </Paper>
    </Container>
  );
}

export default NewSpot;