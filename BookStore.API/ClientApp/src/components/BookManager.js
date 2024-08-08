import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
const BookManager = () => {
  const [books, setBooks] = useState([]);
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState('');

  useEffect(() => {
    fetchBooks();
  }, []);

  const fetchBooks = async () => {
    try {
      const response = await axios.get('/api/books');
      setBooks(response.data);
    } catch (error) {
      console.error('Error fetching books:', error);
    }
  };

  const addBook = async () => {
    if (title && description && price) {
      const newBook = { title, description, price: parseInt(price) };
      try {
        await axios.post('/api/books', newBook);
        setBooks([...books, newBook]);
        setTitle('');
        setDescription('');
        setPrice('');
      } catch (error) {
        console.error('Error adding book:', error);
      }
    }
  };

  const deleteBook = async (id) => {
    try {
      await axios.delete(`/api/books/${id}`);
      setBooks(books.filter(book => book.id !== id));
    } catch (error) {
      console.error('Error deleting book:', error);
    }
  };

  const handlePriceChange = (e) => {
    const value = e.target.value;
    if (Number.isInteger(+value) && +value >= 0) {
      setPrice(value);
    }
  };

  return (
    <div>
      <h1>Book Manager</h1>
      <div>
        <input
          type="text"
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
        <input
          type="text"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
        <input
          type="number"
          placeholder="Price"
          value={price}
          onChange={handlePriceChange}
          min="0"
          step="1"
        />
        <button onClick={addBook}>Add Book</button>
      </div>
      <ul>
      {books.map((book,index) => (
        <li key={index}>
          <h2>{book.title}</h2>
          <p>{book.description}</p>
          <p>{book.price}</p>
          <button onClick={() => deleteBook(book.id)}>Delete</button>
          <p><Link to={`/books/${book.id}`}>View Details</Link></p>
        </li>
      ))}
    </ul>
    </div>
  );
};


export default BookManager;
