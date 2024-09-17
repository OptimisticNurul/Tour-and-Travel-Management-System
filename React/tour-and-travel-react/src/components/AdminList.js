// src/components/AdminList.js
import React, { useEffect, useState } from 'react';
import { getAdmins, deleteAdmin } from '../services/api';
import { Link } from 'react-router-dom';

const AdminList = () => {
    const [admins, setAdmins] = useState([]);

    useEffect(() => {
        fetchAdmins();
    }, []);

    const fetchAdmins = async () => {
        const response = await getAdmins();
        setAdmins(response.data);
    };

    const handleDelete = async (id) => {
        await deleteAdmin(id);
        fetchAdmins();
    };

    return (
        <div className="container mt-4">
            <h2>Admin List</h2>
            <div className="d-flex justify-content-between mb-3">
                <Link to="/add-admin" className="btn btn-primary">Add New Admin</Link>
            </div>
            {admins.map(admin => (
                <div className="card mb-3" key={admin.adminId}>
                    <div className="card-body">
                        <div className="d-flex justify-content-between align-items-center">
                            <div>
                                <h5 className="card-title"><Link to={`/edit-admin/${admin.adminId}`}>{admin.userName}</Link></h5>
                                <p className="card-text">
                                    <strong>Role:</strong> {admin.role}
                                </p>
                            </div>
                            <div>
                                <Link to={`/edit-admin/${admin.adminId}`} className="btn btn-success mr-2">Edit</Link>
                                <button onClick={() => handleDelete(admin.adminId)} className="btn btn-danger">Delete</button>
                            </div>
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default AdminList;
