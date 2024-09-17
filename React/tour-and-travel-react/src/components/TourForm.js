// src/components/TourForm.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const TourForm = () => {
    const [tour, setTour] = useState({
        tourName: '',
        destination: '',
        duration: 0,
        departureTime: '',
        arrivalTime: '',
        description: '',
        tourPackageId: 0,
        date: '',
        availableSlots: 0,
        imageFile: []
    });
    const navigate = useNavigate();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setTour({ ...tour, [name]: value });
    };

    const handleImageChange = (e) => {
        setTour({ ...tour, imageFile: e.target.files });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        Object.keys(tour).forEach(key => {
            if (key === 'imageFile') {
                for (let i = 0; i < tour.imageFile.length; i++) {
                    formData.append('imageFile', tour.imageFile[i]);
                }
            } else {
                formData.append(key, tour[key]);
            }
        });
        await axios.post('http://localhost:5000/api/Tours', formData);
        navigate('/tours');
    };

    return (
        <div>
            <h2>Add New Tour</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Tour Name</label>
                    <input type="text" className="form-control" name="tourName" value={tour.tourName} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Destination</label>
                    <input type="text" className="form-control" name="destination" value={tour.destination} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Duration (days)</label>
                    <input type="number" className="form-control" name="duration" value={tour.duration} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Departure Time</label>
                    <input type="date" className="form-control" name="departureTime" value={tour.departureTime} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Arrival Time</label>
                    <input type="date" className="form-control" name="arrivalTime" value={tour.arrivalTime} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Description</label>
                    <textarea className="form-control" name="description" value={tour.description} onChange={handleChange} required></textarea>
                </div>
                <div className="form-group">
                    <label>Tour Package ID</label>
                    <input type="number" className="form-control" name="tourPackageId" value={tour.tourPackageId} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Date</label>
                    <input type="date" className="form-control" name="date" value={tour.date} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Available Slots</label>
                    <input type="number" className="form-control" name="availableSlots" value={tour.availableSlots} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Tour Images</label>
                    <input type="file" className="form-control" name="imageFile" multiple onChange={handleImageChange} required />
                </div>
                <button type="submit" className="btn btn-primary">Add Tour</button>
            </form>
        </div>
    );
};

export default TourForm;
