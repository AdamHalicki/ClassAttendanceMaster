import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';

import './custom.css'
import { AllStudents } from './components/Student/AllStudents';
import { AddStudent } from './components/Student/AddStudent';
import { EditStudent } from './components/Student/EditStudent';

function App() {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/all-students' component={AllStudents} />
            <Route path='/add-student' component={AddStudent} />
            <Route path='/edit-student/:studentId' component={EditStudent} />
        </Layout>
    );
}

export default App;
