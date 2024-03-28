import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { useEffect } from 'react';
import axios from "axios";
import { useState } from 'react';
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import ModeEditIcon from '@mui/icons-material/ModeEdit';
import { useNavigate } from "react-router-dom";
import ListAltIcon from '@mui/icons-material/ListAlt';
import Dialog from '@mui/material/Dialog';
import CloseIcon from '@mui/icons-material/Close';
import Slide from '@mui/material/Slide';
import AddIcon from '@mui/icons-material/Add';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';

const Patients = () => {
  let x
  const [y, sety] = useState([])
  let nav = useNavigate()
  const [open, setOpen] = useState(false)
  const [d, setD] = useState(null)


  useEffect(() => { goToServer() }, [])
  const goToServer = async () => {
    x = await axios.get("https://localhost:7156/api/Patients")
    sety(x.data)
  };

  const del = async (details) => {
    await axios.delete("https://localhost:7156/api/Patients/" + details.id)
    await axios.delete("https://localhost:7156/api/CoronaDetails/" + details.coronaDetailsId)
    x = await axios.get("https://localhost:7156/api/Patients")
    sety(x.data)
  }

  const edit = (details) => {
    nav('/Details', { state: { details } })
  }

  const add = () => {
    nav('/Details', { state: null })
  }

  const Transition = React.forwardRef(function Transition(props, ref) {
    return <Slide direction="up" ref={ref} {...props} />
  })

  const handleClickOpen = (row) => {
    setOpen(true)
    setD(row)
  }

  const handleClose = () => {
    setOpen(false);
  }

  const corona = (details) => {
    nav('/Corona', { state: { details } })
  }
  return (<>
    <h1>CORONA MANAGEMENT SYSTEM FOR HMO</h1>
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="left">profile</TableCell>
            <TableCell align="center">id</TableCell>
            <TableCell align="center">first name</TableCell>
            <TableCell align="center">last name</TableCell>
            <TableCell align="center">date birth</TableCell>
            <TableCell align="center">city</TableCell>
            <TableCell align="center">address</TableCell>
            <TableCell align="center">phone</TableCell>
            <TableCell align="center">pelephone</TableCell>            
          </TableRow>
        </TableHead>
        <TableBody>
          {y.map((row) => (
            <TableRow
              key={row.firstName}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
              <TableCell ><Avatar src={row.fileUrl} /></TableCell>
              <TableCell align="center">{row.tz}</TableCell>
              <TableCell align="center">{row.firstName}</TableCell>
              <TableCell align="center">{row.lastName}</TableCell>
              <TableCell align="center">{row.dateBirth}</TableCell>
              <TableCell align="center">{row.city}</TableCell>
              <TableCell align="center">{row.address}</TableCell>
              <TableCell align="center">{row.phone}</TableCell>
              <TableCell align="center">{row.pelephon}</TableCell>            
              <IconButton aria-label="delete" onClick={() => { del(row) }}><DeleteIcon /></IconButton>
              <IconButton onClick={() => { edit(row) }}><ModeEditIcon /></IconButton>
              <IconButton onClick={() => { handleClickOpen(row) }}><ListAltIcon /></IconButton>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    <React.Fragment>

      <Dialog className='dialog' fullScreen open={open} onClose={handleClose}>
        <IconButton color="black" onClick={handleClose} ><CloseIcon /></IconButton>
        <TableContainer component={Paper}>
          <h1>CORONA DETAILS</h1>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell align="center">vaccination number</TableCell>
                <TableCell align="center">vaccination date</TableCell>
                <TableCell align="center">vaccination producer</TableCell>
              </TableRow>
            </TableHead>

            <TableBody>

              <TableRow

                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell align="center">1</TableCell>
                <TableCell align="center">{d && d.coronaDetails.firstVaccination.slice(0,10)}</TableCell>
                <TableCell align="center">{d && d.coronaDetails.producerFirst}</TableCell>
              </TableRow>
              <TableRow

                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell align="center">2</TableCell>
                <TableCell align="center">{d && d.coronaDetails.secondVaccination.slice(0,10)}</TableCell>
                <TableCell align="center">{d && d.coronaDetails.producerSecond}</TableCell>
              </TableRow>
              <TableRow

                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell align="center">3</TableCell>
                <TableCell align="center">{d && d.coronaDetails.thirdVaccination.slice(0,10)}</TableCell>
                <TableCell align="center">{d && d.coronaDetails.producerThird}</TableCell>
              </TableRow>
              <TableRow
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell align="center">4</TableCell>
                <TableCell align="center">{d && d.coronaDetails.fourhVaccination.slice(0,10)}</TableCell>
                <TableCell align="center">{d && d.coronaDetails.producerFourth}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>

        <div className='cdetails'>
          <label>date sick</label>
          <label>{d && d.coronaDetails.dataSick.slice(0,10)}</label>
          <label>date recover</label>
          <label>{d && d.coronaDetails.dataRecover.slice(0,10)}</label>
        </div>
      </Dialog>
    </React.Fragment>

    <IconButton onClick={add}><AddIcon /></IconButton>
    <br></br>
    <Button variant="outlined" onClick={() => { corona(y) }}>vaccination data</Button>
  </>);
}

export default Patients;
