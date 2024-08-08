import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

const BookDetail = () => {
  const { id } = useParams();
  const [book, setBook] = useState(null);

  useEffect(() => {
    axios.get(`/api/books/${id}`)
    .then(response => setBook(response.data))
    .catch(error => console.error("There was an error fetching the book data!", error));
  }, [id]);

  if (!book) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>{book.title}</h1>
      <p>{book.description}</p>
      <p>{book.price}</p>
    </div>
  );
};

export default BookDetail;
