import React, { useState, useEffect } from 'react';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';

export function AllStudents() {
    const [students, setStudents] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('student');
                const data = await response.json();
                setStudents(data);
                setLoading(false);
            } catch (error) {
                console.log("error", error);
            }
        };

        fetchData();
    }, []);

    function renderStudentsTable(students) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Album number</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {students.map(student =>
                        <tr key={student.id}>
                            <td>{student.firstName}</td>
                            <td>{student.lastName}</td>
                            <td>{student.albumNumber}</td>
                            <td> <Link to={{ pathname: `/edit-student/${student.id}`}}>
                                <Button className="btn btn-primary">
                                    Edit
                                </Button>
                            </Link></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderStudentsTable(students);

    return (
        <div>
            <h1 id="tabelLabel" >All Students List</h1>
            {contents}
        </div>
    );
}
