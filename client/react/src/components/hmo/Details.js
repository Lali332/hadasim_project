import TextField from '@mui/material/TextField'
import './css.css'
import { useLocation } from 'react-router-dom'
import Button from '@mui/material/Button'
import axios from "axios"
import { useForm } from 'react-hook-form'
import { useState } from 'react'
import { Avatar } from '@mui/material'

const Details = () => {
    const { register, handleSubmit, formState: { errors, dirtyFields, isValid, isDirty, isSubmitted }, } = useForm({ mode: "onBlur" })
    const { state } = useLocation()
    let d = {
        id: 0,
        firstName: state != null ? state.details.firstName : null,
        lastName: state != null ? state.details.lastName : null,
        tz: state != null ? state.details.tz : null,
        city: state != null ? state.details.city : null,
        address: state != null ? state.details.address : null,
        phone: state != null ? state.details.phone : null,
        pelephon: state != null ? state.details.pelephon : null,
        dateBirth: state != null ? state.details.dateBirth : null,
        coronaDetails: null,
        coronaDetailsId: 0,
        coronaDetails: {
            firstVaccination: state != null ? state.details.coronaDetails.firstVaccination : null,
            secondVaccination: state != null ? state.details.coronaDetails.secondVaccination : null,
            thirdVaccination: state != null ? state.details.coronaDetails.thirdVaccination : null,
            fourhVaccination: state != null ? state.details.coronaDetails.fourhVaccination : null,
            producerFirst: state != null ? state.details.coronaDetails.producerFirst : null,
            producerSecond: state != null ? state.details.coronaDetails.producerSecond : null,
            producerThird: state != null ? state.details.coronaDetails.producerThird : null,
            producerFourth: state != null ? state.details.coronaDetails.producerFourth : null,
            dataSick: state != null ? state.details.coronaDetails.dataSick : null,
            dataRecover: state != null ? state.details.coronaDetails.dataRecover : null,
        }
    }
    let res = null
    const [selectedFile, setSelectedFile] = useState(null);
    const [mes, setMes] = useState(null);
    const [img, setImg] = useState(state != null ? state.details.fileUrl : null);



    const picture = (e) => {
        setSelectedFile(e.target.files[0])
        if (e.target.files[0]) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setImg(reader.result);
            };
        }
    }

    const save = async () => {
        const formData = new FormData();
        formData.append("firstName", d.firstName);
        formData.append("lastName", d.lastName)
        formData.append("tz", d.tz)
        formData.append("city", d.city)
        formData.append("address", d.address)
        formData.append("phone", d.phone)
        formData.append("pelephon", d.pelephon)
        formData.append("dateBirth", d.dateBirth)
        formData.append("imageFile", selectedFile)
        if (state != null) {
            formData.append("coronaDetailsId", state.details.coronaDetailsId)
            await axios.put("https://localhost:7156/api/Patients/" + state.details.id, formData, {
                headers: {
                    "Content-Type": "multipart/form-data",
                },
            }).then(setMes(null)).catch((error) => { if (error.response) setMes(error.response.data) })

            res = await axios.put("https://localhost:7156/api/CoronaDetails/" + state.details.coronaDetailsId, {
                "firstVaccination": d.coronaDetails.firstVaccination,
                "secondVaccination": d.coronaDetails.secondVaccination,
                "thirdVaccination": d.coronaDetails.thirdVaccination,
                "fourhVaccination": d.coronaDetails.fourhVaccination,
                "producerFirst": d.coronaDetails.producerFirst,
                "producerSecond": d.coronaDetails.producerSecond,
                "producerThird": d.coronaDetails.producerThird,
                "producerFourth": d.coronaDetails.producerFourth,
                "dataSick": d.coronaDetails.dataSick,
                "dataRecover": d.coronaDetails.dataRecover
            }).then(setMes(null)).catch((error) => { if (error.response) setMes(error.response.data) })

        }
        else {
            res = await axios.post("https://localhost:7156/api/CoronaDetails",
                {
                    "firstVaccination": d.coronaDetails.firstVaccination,
                    "secondVaccination": d.coronaDetails.secondVaccination,
                    "thirdVaccination": d.coronaDetails.thirdVaccination,
                    "fourhVaccination": d.coronaDetails.fourhVaccination,
                    "producerFirst": d.coronaDetails.producerFirst,
                    "producerSecond": d.coronaDetails.producerSecond,
                    "producerThird": d.coronaDetails.producerThird,
                    "producerFourth": d.coronaDetails.producerFourth,
                    "dataSick": d.coronaDetails.dataSick,
                    "dataRecover": d.coronaDetails.dataRecover
                })
            formData.append("coronaDetailsId", res.data.id)

            await axios.post('https://localhost:7156/api/Patients', formData,
                {
                    headers: {
                        "Content-Type": "multipart/form-data",
                    },
                })


        }
    }

    return (<>
        <h1>{state != null ? 'Update patient' : 'Add new patient'}</h1>
        <p align="center"> <Avatar src={img}></Avatar></p>
        {state == null && <TextField type="file" {...register("file", { required: "field is required" })} onChange={picture} />}

        <form onSubmit={handleSubmit(save)}>
            <div className='details'>
                <TextField id="filled-basic" label="first name" variant="outlined" defaultValue={state != null ? state.details.firstName : ""} onChange={(e) => { d.firstName = e.target.value }}/>

                <TextField id="filled-basic" label="last name" variant="outlined" defaultValue={state != null ? state.details.lastName : ""} onChange={(e) => { d.lastName = e.target.value }}/>

                <TextField id="filled-basic" label="id" variant="outlined" defaultValue={state != null ? state.details.tz : ""} onChange={(e) => { d.tz = e.target.value }} />

                <TextField id="filled-basic" label="city" variant="outlined" defaultValue={state != null ? state.details.city : ""} onChange={(e) => { d.city = e.target.value }}/>

                <TextField id="filled-basic" label="address" variant="outlined" defaultValue={state != null ? state.details.address : ""} onChange={(e) => { d.address = e.target.value }} />

                <TextField id="filled-basic" label="phone" variant="outlined" defaultValue={state != null ? state.details.phone : ""} onChange={(e) => { d.phone = e.target.value }}/>

                <TextField id="filled-basic" label="pelephone" variant="outlined" defaultValue={state != null ? state.details.pelephon : ""} onChange={(e) => { d.pelephon = e.target.value }}/>

                <TextField type='date' id="input-with-icon-textfield" label="date birth" variant="outlined" defaultValue={state != null ? (state.details.dateBirth).slice(0, 10) : ""} onChange={(e) => { d.dateBirth = e.target.value }}/>
            </div>
            <h3>corona details</h3>
            <div className='details'>
                <TextField type='date' id="filled-basic" label="first vaccination" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.firstVaccination).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.firstVaccination = e.target.value }} />

                <TextField id="filled-basic" label="producer" variant="outlined" defaultValue={state != null ? state.details.coronaDetails.producerFirst : ""} onChange={(e) => { d.coronaDetails.producerFirst = e.target.value }} />

                <TextField type='date' id="filled-basic" label="second vaccination" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.secondVaccination).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.secondVaccination = e.target.value }} />

                <TextField id="filled-basic" label="producer" variant="outlined" defaultValue={state != null ? state.details.coronaDetails.producerSecond : ""} onChange={(e) => { d.coronaDetails.producerSecond = e.target.value }} />

                <TextField type='date' id="filled-basic" label="third vaccination" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.thirdVaccination).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.thirdVaccination = e.target.value }} />

                <TextField id="filled-basic" label="producer" variant="outlined" defaultValue={state != null ? state.details.coronaDetails.producerThird : ""} onChange={(e) => { d.coronaDetails.producerThird = e.target.value }} />

                <TextField type='date' id="filled-basic" label="fourth vaccination" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.fourhVaccination).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.fourhVaccination = e.target.value }} />

                <TextField id="filled-basic" label="producer" variant="outlined" defaultValue={state != null ? state.details.coronaDetails.producerFourth : ""} onChange={(e) => { d.coronaDetails.producerFourth = e.target.value }} />

                <TextField type='date' id="filled-basic" label="date sick" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.dataSick).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.dataSick = e.target.value }} />

                <TextField type='date' id="filled-basic" label="date recover" variant="outlined" defaultValue={state != null ? (state.details.coronaDetails.dataRecover).slice(0, 10) : ""} onChange={(e) => { d.coronaDetails.dataRecover = e.target.value }} />
            </div>
            <Button type="submit" disabled={!isValid} variant="outlined"  >{state != null ? 'update' : 'add'}</Button>
            {mes != null && <p>{mes}</p>}
        </form>

    </>);
}

export default Details;