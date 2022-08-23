import { makeStyles } from '@mui/styles';


export default makeStyles(() => ({
  appBarHeader: {
    paddingLeft: '6px',
    height: '60px'
  },

  appBarSearchForm: {
    padding: '10px',
    height: '60px'
  },

  textFieldSearchForm: {
    color: 'white',
    borderColor: 'red'
  },

  gridForm: {
    paddingTop: '10px',
    paddingBottom: '10px',
    paddingInline: '4px',
    display: 'flex',
    direction: 'row',
  },
  buttonSubmit: {
    padding: '10px',
  },
  card: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'space-between',
    height: '100%',
    position: 'relative',
    border: 'groove',
    borderWidth: '4px',
    borderColor: 'red',
    boxShadow: '0 0 10px #b30000',
  },
}));