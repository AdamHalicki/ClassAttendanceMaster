import React, { useState, useEffect} from 'react';
import { Form, FormGroup, Label, Input, Alert } from 'reactstrap';
import { useParams } from "react-router-dom";

export function EditStudent() {
    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [AlbumNumber, setAlbumNumber] = useState("");
    const [message, setMessage] = useState("");
    const { studentId } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(`student/${studentId}`);
                const data = await response.json();
                setFirstName(data.firstName);
                setLastName(data.lastName);
                setAlbumNumber(data.albumNumber);
            } catch (error) {
                console.log("error", error);
            }
        };

        fetchData();
    }, []);

    const submit = async (event) => {
        event.preventDefault();
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ FirstName: FirstName, LastName: LastName, AlbumNumber: AlbumNumber })
        };
        await fetch(`student/${studentId}`, requestOptions)
            .then(async response => {
                if (!response.ok) {
                    setMessage(
                        <Alert color="danger">
                            Something went wrong.
                </Alert>)
                }
                else {
                    setMessage(<Alert color="success">
                        Student edited succesfully.
                    </Alert>)
                }
            })
            .catch(error => {
                setMessage(
                    <Alert color="danger">
                        Something went wrong.
                </Alert>)
            });
    }

    return (
        <div>
            {message}
            <Form onSubmit={submit}>
                <FormGroup className="col-md-3">
                    <Label for="Firstname">Firstname</Label>
                    <Input type="text" name="FirstName" id="Firstname" value={FirstName}
                        onChange={e => setFirstName(e.target.value)} />
                </FormGroup>
                <FormGroup className="col-md-3">
                    <Label for="Lastname">Lastname</Label>
                    <Input type="text" name="LastName" id="Lastname" value={LastName}
                        onChange={e => setLastName(e.target.value)} />
                </FormGroup>
                <FormGroup className="col-md-3">
                    <Label for="AlbumNumber">Album number</Label>
                    <Input type="number" name="AlbumNumber" id="AlbumNumber" value={AlbumNumber}
                        onChange={e => setAlbumNumber(e.target.value)} />
                </FormGroup>
                <div className="col-md-2">
                    <input className="btn btn-primary float-right" type="submit" value="Edit student" />
                </div>
            </Form>
        </div>
    );
}