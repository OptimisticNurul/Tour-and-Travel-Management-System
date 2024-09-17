import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';

const TourList = () => {
    const [tours, setTours] = useState([]);

    useEffect(() => {
        const fetchTours = async () => {
            try {
                const response = await axios.get('http://localhost:5000/api/Tours');
                console.log(response.data); // For debugging
                setTours(response.data);
            } catch (error) {
                console.error('Error fetching tours:', error);
            }
        };
        fetchTours();
    }, []);

    const deleteTour = async (tourId) => {
        if (window.confirm("Are you sure you want to delete this tour?")) {
            try {
                await axios.delete(`http://localhost:5000/api/Tours/${tourId}`);
                setTours(tours.filter(tour => tour.tourId !== tourId));
            } catch (error) {
                console.error('Error deleting tour:', error);
            }
        }
    };

    const sliderSettings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        adaptiveHeight: true,
        autoplay: true,
        autoplaySpeed: 3000 // Change this value to set the autoplay speed (in milliseconds)
    };

    return (
        <div>
            <h2>Tour List</h2>
            <Link to="/add-tour" className="btn btn-primary mb-3">Add New Tour</Link>
            {tours.length > 0 ? (
                tours.map(tour => (
                    <div key={tour.tourId} className="card mb-3">
                        <div className="card-body">
                            <h5 className="card-title">{tour.tourName}</h5>
                            <p className="card-text">Destination: {tour.destination}</p>
                            <p className="card-text">Duration: {tour.duration} days</p>
                            <p className="card-text">Departure: {new Date(tour.departureTime).toLocaleString()}</p>
                            <p className="card-text">Arrival: {new Date(tour.arrivalTime).toLocaleString()}</p>
                            <p className="card-text">Description: {tour.description}</p>
                            <p className="card-text">Total Amount: ${tour.totalAmount.toFixed(2)}</p>
                            {tour.tourAvailabilities && tour.tourAvailabilities.length > 0 && (
                                <p className="card-text">Available Slots: {tour.tourAvailabilities[0].availableSlots}</p>
                            )}
                            {tour.tourImages && tour.tourImages.length > 0 && (
                                <Slider {...sliderSettings} className="tour-images mb-3">
                                    {tour.tourImages.map((img, index) => (
                                        <div key={index}>
                                            <img
                                                src={`http://localhost:5000/Images/${img.picture}`}
                                                alt={tour.tourName}
                                                className="img-fluid"
                                                style={{ width: '100%', height: '300px', objectFit: 'cover' }}
                                            />
                                        </div>
                                    ))}
                                </Slider>
                            )}
                            <Link to={`/edit-tour/${tour.tourId}`} className="btn btn-warning">Edit</Link>
                            <button className="btn btn-danger ml-2" onClick={() => deleteTour(tour.tourId)}>Delete</button>
                        </div>
                    </div>
                ))
            ) : (
                <p>No tours found.</p>
            )}
        </div>
    );
};

export default TourList;
