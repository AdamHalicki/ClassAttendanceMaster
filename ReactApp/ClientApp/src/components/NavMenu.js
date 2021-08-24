import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, DropdownItem, DropdownToggle, DropdownMenu, UncontrolledDropdown } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.toggleDropDown = this.toggleDropDown.bind(this);
        this.state = {
            collapsedNavBar: true,
            collapsedDropDown: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsedNavBar: !this.state.collapsedNavBar
        });
    }

    toggleDropDown() {
        this.setState({
            collapsedDropDown: !this.state.collapsedDropDown
        });
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">Class Attendance Master</NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsedNavBar} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                                </NavItem>
                                <UncontrolledDropdown nav onClick={this.toggleDropDown} isOpen={!this.state.collapsedDropDown}>
                                    <DropdownToggle nav caret className="text-dark">
                                        Students
                                    </DropdownToggle>
                                    <DropdownMenu>
                                        <DropdownItem>
                                            <NavItem>
                                                <NavLink tag={Link} className="text-dark" to="/all-students">All Students</NavLink>
                                            </NavItem>
                                        </DropdownItem>
                                        <DropdownItem><NavLink tag={Link} className="text-dark" to="/add-student">Add Student</NavLink></DropdownItem>
                                    </DropdownMenu>
                                </UncontrolledDropdown>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}
