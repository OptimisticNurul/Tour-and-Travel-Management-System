// src/components/AdminEdit.js
import React, { useState, useEffect } from 'react';
import { getAdmin, updateAdmin } from '../services/api';
import { useNavigate, useParams } from 'react-router-dom';

const AdminEdit = () => {
    const [admin, setAdmin] = useState({ userName: '', password: '', role: '' });
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        fetchAdmin();
    }, []);

    const fetchAdmin = async () => {
        const response = await getAdmin(id);
        setAdmin(response.data);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setAdmin({ ...admin, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateAdmin(id, admin);
        navigate('/');
    };

    return (
        <div className="container mt-4">
            <h2>Edit Admin</h2>
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
                <button type="submit" className="btn btn-primary">Update Admin</button>
            </form>
        </div>
    );
};

export default AdminEdit;
