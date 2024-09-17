// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import AdminList from './components/AdminList';
import AdminForm from './components/AdminForm';
import AdminEdit from './components/AdminEdit';
import Home from './components/Home';
import TourList from './components/TourList';
import TourForm from './components/TourForm';
import TourEdit from './components/TourEdit';

const App = () => {
    return (
        <Router>
            <div>
                <nav className="navbar navbar-expand-lg navbar-light bg-success">
                    <a className="navbar-brand" href="/">Tour and Travel</a>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <Link className="nav-link" to="/">Home</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/admins">Admins</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/tours">Tours</Link>
                            </li>
                        </ul>
                    </div>
                </nav>
                <div className="container mt-4">
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/admins" element={<AdminList />} />
                        <Route path="/add-admin" element={<AdminForm />} />
                        <Route path="/edit-admin/:id" element={<AdminEdit />} />
                        <Route path="/tours" element={<TourList />} />
                        <Route path="/add-tour" element={<TourForm />} />
                        <Route path="/edit-tour/:id" element={<TourEdit />} />
                    </Routes>
                </div>
            </div>
        </Router>
    );
};

export default App;
