// src/components/AdminForm.js
import React, { useState } from 'react';
import { createAdmin } from '../services/api';
import { useNavigate } from 'react-router-dom';

const AdminForm = () => {
    const [admin, setAdmin] = useState({ userName: '', password: '', role: '' });
    const navigate = useNavigate();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setAdmin({ ...admin, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await createAdmin(admin);
        navigate('/');
    };

    return (
        <div className="container mt-4">
            <h2>Add New Admin</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>User Name</label>
                    <input
                        name="userName"
                        value={admin.userName}
                        onChange={handleChange}
                        className="form-control"
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input
                        name="password"
                        type="password"
                        value={admin.password}
                        onChange={handleChange}
                        className="form-control"
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Role</label>
                    <input
                        name="role"
                        value={admin.role}
                        onChange={handleChange}
                        className="form-control"
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Create Admin</button>
            </form>
        </div>
    );
};

export default AdminForm;
