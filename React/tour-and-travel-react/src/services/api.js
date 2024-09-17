// src/services/api.js
import axios from 'axios';

const API_URL = 'http://localhost:5000/api'; // Ensure this matches your API's URL

export const getAdmins = () => axios.get(`${API_URL}/admins`);

export const getAdmin = (id) => axios.get(`${API_URL}/admins/${id}`);

export const createAdmin = (admin) => axios.post(`${API_URL}/admins`, admin);

export const updateAdmin = (id, admin) => axios.put(`${API_URL}/admins/${id}`, admin);

export const deleteAdmin = (id) => axios.delete(`${API_URL}/admins/${id}`);
