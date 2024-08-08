import React, { Component } from 'react';
import axios from 'axios';
import '../styles/card.css'
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      books: []
    };
  }

  componentDidMount() {
    this.fetchBooks();
  }

  fetchBooks() {
    axios.get('/api/books')
      .then(response => {
        const allBooks = response.data;
        const latestBooks = allBooks.slice(-5).reverse(); // Получаем последние 5 книг и реверсируем их порядок
        this.setState({ books: latestBooks });
      })
      .catch(error => {
        console.error('There was an error fetching the books!', error);
      });
  }

  render() {
    const { books } = this.state;

    // Настройки слайдера
    const settings = {
      dots: true,
      infinite: true,
      speed: 500,
      slidesToShow: 1,
      slidesToScroll: 1
    };

    return (
      <div>
        <h2>Latest Books</h2>
        <Slider {...settings}>
          {books.map((book, index) => (
            <div className="card" key={index}>
              <h3>{book.title}</h3>
              <p>{book.description}</p>
              <p>Price: ${book.price}</p>
            </div>
          ))}
        </Slider>
      </div>
    );
  }
}
