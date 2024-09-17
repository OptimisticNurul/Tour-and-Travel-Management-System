import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';

const TourEdit = () => {
    const { id } = useParams();
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

    useEffect(() => {
        const fetchTour = async () => {
            const response = await axios.get(`http://localhost:5000/api/Tours/${id}`);
            const fetchedTour = response.data;
            setTour({
                tourName: fetchedTour.tourName,
                destination: fetchedTour.destination,
                duration: fetchedTour.duration,
                departureTime: new Date(fetchedTour.departureTime).toISOString().split('T')[0],
                arrivalTime: new Date(fetchedTour.arrivalTime).toISOString().split('T')[0],
                description: fetchedTour.description,
                tourPackageId: fetchedTour.tourPackageId,
                date: new Date(fetchedTour.tourAvailabilities[0].date).toISOString().split('T')[0],
                availableSlots: fetchedTour.tourAvailabilities[0].availableSlots,
                imageFile: []
            });
        };
        fetchTour();
    }, [id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setTour({ ...tour, [name]: value });
    };

    // Convert dates to ISO format if needed
    const handleDateChange = (e) => {
        const { name, value } = e.target;
        setTour({ ...tour, [name]: new Date(value).toISOString() });
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

        // Log FormData entries for debugging
        for (let [key, value] of formData.entries()) {
            console.log(`${key}: ${value}`);
        }

        try {
            await axios.put(`http://localhost:5000/api/Tours/${id}`, formData);
            navigate('/tours');
        } catch (error) {
            console.error(error);
            alert("Error updating tour");
        }
    };

    return (
        <div>
            <h2>Edit Tour</h2>
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
                    <input type="date" className="form-control" name="departureTime" value={tour.departureTime.split('T')[0]} onChange={handleDateChange} required />
                </div>
                <div className="form-group">
                    <label>Arrival Time</label>
                    <input type="date" className="form-control" name="arrivalTime" value={tour.arrivalTime.split('T')[0]} onChange={handleDateChange} required />
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
                    <input type="date" className="form-control" name="date" value={tour.date} onChange={handleDateChange} required />
                </div>
                <div className="form-group">
                    <label>Available Slots</label>
                    <input type="number" className="form-control" name="availableSlots" value={tour.availableSlots} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Tour Images</label>
                    <input type="file" className="form-control" name="imageFile" multiple onChange={handleImageChange} />
                </div>
                <button type="submit" className="btn btn-primary">Update Tour</button>
            </form>
        </div>
    );
};

export default TourEdit;
