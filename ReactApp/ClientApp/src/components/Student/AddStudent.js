import React, { useState } from 'react';
import { Form, FormGroup, Label, Input, Alert } from 'reactstrap';

export function AddStudent() {
    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [AlbumNumber, setAlbumNumber] = useState("");
    const [message, setMessage] = useState("");

    const submit = async (event) => {
        event.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ FirstName: FirstName, LastName: LastName, AlbumNumber: AlbumNumber })
        };
        await fetch('student', requestOptions)
            .then(async response => {
                if (!response.ok) {
                    setMessage(
                        <Alert color="danger">
                            Something went wrong.
                </Alert>)
                }
                else {
                    setFirstName("");
                    setLastName("");
                    setAlbumNumber("");
                    setMessage(<Alert color="success">
                        Student Added succesfully.
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
                <div className="col-md-3">
                    <input className="btn btn-primary float-right" type="submit" value="Add student" />
                </div>
            </Form>
        </div>
    );
}